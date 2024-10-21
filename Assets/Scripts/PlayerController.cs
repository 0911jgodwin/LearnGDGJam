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

        [Header("Player Stats")]
        public float speed = 10f;
        public float jumpForce = 8f;
        public float slideSpeed = 5f;
        public float acceleration = 10f;

        [Header("Toggles")]
        public bool FancyMovement = false;
        public bool BasicJumping = false;
        public bool WallJumping = false;
        public bool WallSliding = false;


        public bool canMove = true;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            _playerMovementInput = GetComponent<PlayerMovementInput>();
            _rb = GetComponent<Rigidbody2D>();
            _playerCollision = GetComponent<PlayerCollision>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_playerMovementInput.JumpPressed)
            {
                if (_playerCollision.onGround && BasicJumping)
                    Jump(Vector2.up);
                else if (_playerCollision.onWall && WallJumping)
                    WallJump();
            }

            if (_playerCollision.onWall && !_playerCollision.onGround)
            {
                if (_playerMovementInput.MovementInput.x != 0 && WallSliding)
                    WallSlide();
            }
        }

        private void FixedUpdate()
        {
            Run(_playerMovementInput.MovementInput);
        }

        private void Run(Vector2 direction)
        {
            if (!canMove)
                return;
            if (!FancyMovement)
                _rb.linearVelocity = new Vector2(direction.x * speed, _rb.linearVelocity.y);
            else
                _rb.linearVelocity = Vector2.Lerp(_rb.linearVelocity, (new Vector2(direction.x * speed, _rb.linearVelocity.y)), acceleration * Time.deltaTime);
        }

        private void Jump(Vector2 direction)
        {
            float force = jumpForce;
            //counteracting falling speed to help ensure our jump works as expected
            if (_rb.linearVelocityY < 0)
                force -= _rb.linearVelocityY;
            _rb.linearVelocity += direction * force;
        }

        private void WallSlide()
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, -slideSpeed);
        }

        private void WallJump()
        {
            Vector2 wallDirection = _playerCollision.onRightWall ? Vector2.left : Vector2.right;
            StartCoroutine(DisableMovement(0.3f));
            //Trying to get a nice upward arc
            Jump(new Vector2(wallDirection.x*3, 5).normalized);
        }

        IEnumerator DisableMovement(float time)
        {
            canMove = false;
            yield return new WaitForSeconds(time);
            canMove = true;
        }
    }
}