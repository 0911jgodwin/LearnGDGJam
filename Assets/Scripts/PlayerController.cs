using System.Collections;
using UnityEngine;

namespace Learn.PlayerController
{
    [DefaultExecutionOrder(-1)]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovementInput _playerMovementInput;
        private Rigidbody2D _rb;
        private PlayerCollision _playerCollision;
        private PlayerAnimation _playerAnimation;
        private GameObject _targetingReticule;
        public Projectile _projectilePrefab;

        [Header("Player Stats")]
        public float speed = 10f;
        public float jumpForce = 8f;
        public float slideSpeed = 5f;
        public float dashSpeed = 40f;
        public float acceleration = 10f;

        [Header("Toggles")]
        public bool FancyMovementEnabled = false;
        public bool BasicJumpingEnabled = false;
        public bool FancyJumpingEnabled = false;
        public bool WallJumpingEnabled = false;
        public bool WallSlidingEnabled = false;
        public bool DashingEnabled = false;

        [Header("Fall Options")]
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        [Header("Booleans")]
        public bool canMove = true;
        public bool isDashing;
        public bool wallSliding;

        private bool hasDashed;

        public int side = 1;

        private float lastShotFiredTime;
        private float reloadSpeed = 0.5f;

        void Awake()
        {
            _playerMovementInput = GetComponent<PlayerMovementInput>();
            _rb = GetComponent<Rigidbody2D>();
            _playerCollision = GetComponent<PlayerCollision>();
            _playerAnimation = GetComponent<PlayerAnimation>();
            _targetingReticule = gameObject.transform.GetChild(0).gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            _playerAnimation.SetMovementValues(_playerMovementInput.MovementInput, _rb.linearVelocityY);
            UpdateAim();

            if (lastShotFiredTime > 0)
            {
                lastShotFiredTime -= Time.deltaTime;
            }

            if ((_playerMovementInput.ShootPressed || _playerMovementInput.ShootHeld) && lastShotFiredTime <= 0)
            {
                FireSpell();
            }

            if (_playerMovementInput.JumpPressed)
            {
                if (_playerCollision.onGround && BasicJumpingEnabled)
                    Jump(Vector2.up);
                else if (_playerCollision.onWall && WallJumpingEnabled)
                    WallJump();
                else if (!_playerCollision.onGround && !hasDashed && _playerMovementInput.MovementInput != Vector2.zero && DashingEnabled)
                    StartCoroutine(DashLockout(_playerMovementInput.MovementInput));
            }

            if (_playerMovementInput.DashPressed && !hasDashed)
            {
                
                if (_playerMovementInput.MovementInput != Vector2.zero && DashingEnabled)
                    StartCoroutine(DashLockout(_playerMovementInput.MovementInput));
            }

            if (_playerCollision.onGround && !isDashing)
            {
                hasDashed = false;
            }

            #region AdjustingFallSpeed
            if (FancyJumpingEnabled)
            {
                if (_rb.linearVelocityY < 0)
                    _rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                else if (_rb.linearVelocityY > 0 && !_playerMovementInput.JumpHeld)
                    _rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            #endregion
            #region FlipSprite
            if (wallSliding || !canMove)
                return;

            if (_playerMovementInput.MovementInput.x > 0)
            {
                side = 1;
                _playerAnimation.Flip(side);
            }  
            else if (_playerMovementInput.MovementInput.x < 0)
            {
                side = -1;
                _playerAnimation.Flip(side);
            }
            #endregion
        }

        private void FixedUpdate()
        {
            Run(_playerMovementInput.MovementInput);

            if (!_playerCollision.onWall || _playerCollision.onGround || !canMove)
            {
                wallSliding = false;
            }

            if (_playerCollision.onWall && !_playerCollision.onGround)
            {
                if (_playerMovementInput.MovementInput.x != 0)
                {
                    wallSliding = true;
                    WallSlide();
                }            
            }
        }

        private void Run(Vector2 direction)
        {
            if (!canMove)
                return;

            if (!FancyMovementEnabled)
                _rb.linearVelocity = new Vector2(direction.x * speed, _rb.linearVelocity.y);
            else
                _rb.linearVelocity = Vector2.Lerp(_rb.linearVelocity, (new Vector2(direction.x * speed, _rb.linearVelocity.y)), acceleration * Time.deltaTime);
        }

        private void Jump(Vector2 direction)
        {
            _playerAnimation.SetTrigger("jump");
            float force = jumpForce;
            //counteracting falling speed to help ensure our jump works as expected
            if (_rb.linearVelocityY < 0)
                force -= _rb.linearVelocityY;
            _rb.AddForce(direction*force, ForceMode2D.Impulse);
        }

        private void WallSlide()
        {
            if (!canMove)
                return;
            if (WallSlidingEnabled)
                //Removing any remaining upwards impulse
                if (_rb.linearVelocityY > 0)
                    _rb.AddForce(_rb.linearVelocityY * Vector2.up, ForceMode2D.Impulse);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, -slideSpeed);
        }

        private void WallJump()
        {
            if ((side == 1 && _playerCollision.onRightWall) || side == -1 && !_playerCollision.onRightWall)
            {
                side *= -1;
                _playerAnimation.Flip(side);
            }

            Vector2 wallDirection = _playerCollision.onRightWall ? Vector2.left : Vector2.right;
            StartCoroutine(DisableMovement(0.15f));
            //Trying to get a nice upward arc
            Jump(new Vector2(wallDirection.x*3, 5).normalized);
        }

        private void UpdateAim()
        {
            if (_playerMovementInput.AimInput == Vector2.zero)
                return;

            float radValue = Mathf.Atan2(_playerMovementInput.AimInput.y, _playerMovementInput.AimInput.x);
            _targetingReticule.transform.eulerAngles = new Vector3(0,0,(radValue * (180/Mathf.PI))-90);
        }

        private void FireSpell()
        {
            lastShotFiredTime = reloadSpeed;
            Projectile shot = Instantiate(_projectilePrefab, _targetingReticule.transform.GetChild(0).transform.position, _targetingReticule.transform.rotation);
            shot.SetDirection(_targetingReticule.transform.GetChild(0).transform.position-transform.position);
        }

        IEnumerator DashLockout(Vector2 direction)
        {
            _playerAnimation.SetTrigger("dash");
            isDashing = true;
            hasDashed = true;
            bool isFancyJumping = FancyJumpingEnabled;
            if (isFancyJumping)
                FancyJumpingEnabled = false;
            _rb.gravityScale = 0f;
            float startTime = Time.time;

            //0.15 seconds of gravity free dashing
            while (Time.time - startTime <= 0.15f)
            {
                _rb.linearVelocity = direction.normalized * dashSpeed;
                yield return null;
            }

            startTime = Time.time;

            _rb.gravityScale = 3f;
            _rb.linearVelocity = direction.normalized * (dashSpeed*0.8f);

            //0.15 seconds of gravity back in the dash with reduced speed
            while (Time.time - startTime <= 0.15f)
                yield return null;

            FancyJumpingEnabled = isFancyJumping;
            isDashing = false;
        }

        IEnumerator DisableMovement(float time)
        {
            canMove = false;
            yield return new WaitForSeconds(time);
            canMove = true;
        }
    }
}