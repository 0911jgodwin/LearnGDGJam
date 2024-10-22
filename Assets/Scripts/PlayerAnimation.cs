using UnityEngine;

namespace Learn.PlayerController
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] PlayerCollision _playerCollision;
        [SerializeField] PlayerController _playerController;

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
        }

        void Update()
        {
            UpdateAnimationState();
        }

        private void UpdateAnimationState()
        {
            _animator.SetBool(isGroundedHash, _playerCollision.onGround);
            _animator.SetBool(isOnWallHash, _playerCollision.onWall);
            _animator.SetBool(isWallSlidingHash, false);
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
    }
}
