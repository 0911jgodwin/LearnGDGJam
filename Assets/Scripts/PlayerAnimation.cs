using UnityEngine;

namespace Learn.PlayerController
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] PlayerCollision _playerCollision;
        [SerializeField] PlayerController _playerController;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] PlayerMovementInput _playerMovementInput;


        private static int inputXHash = Animator.StringToHash("inputX");
        private static int inputYHash = Animator.StringToHash("inputY");
        private static int verticalVelocityHash = Animator.StringToHash("verticalVelocity");
        private static int isGroundedHash = Animator.StringToHash("onGround");
        private static int isOnWallHash = Animator.StringToHash("onWall");
        private static int isWallSlidingHash = Animator.StringToHash("wallSliding");
        private static int isDashingHash = Animator.StringToHash("isDashing");
        private static int canMoveHash = Animator.StringToHash("canMove");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerCollision = GetComponent<PlayerCollision>();
            _playerController = GetComponent<PlayerController>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _playerMovementInput = GetComponent<PlayerMovementInput>();
        }

        void Update()
        {
            UpdateAnimationState();
        }

        private void UpdateAnimationState()
        {
            _animator.SetBool(isGroundedHash, _playerCollision.onGround);
            _animator.SetBool(isOnWallHash, _playerCollision.onWall);
            _animator.SetBool(isWallSlidingHash, _playerController.wallSliding);
            _animator.SetBool(isDashingHash, _playerController.isDashing);
            _animator.SetBool(canMoveHash, _playerController.canMove);
        }

        public void SetMovementValues(Vector2 input, float yVelocity)
        {
            _animator.SetFloat(inputXHash, input.x);
            _animator.SetFloat(inputYHash, input.y);
            _animator.SetFloat(verticalVelocityHash, yVelocity);
        }

        public void SetTrigger(string trigger)
        {
            _animator.SetTrigger(trigger);
        }

        public void Flip(int side)
        {

            if (_playerController.wallSliding)
            {
                if (side == -1 && _spriteRenderer.flipX || side == 1 && !_spriteRenderer.flipX)
                    return;
            }

            bool state = (side == 1) ? false : true;
            _spriteRenderer.flipX = state;
        }
    }
}
