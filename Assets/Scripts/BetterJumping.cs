using UnityEngine;

namespace Learn.PlayerController
{
    public class BetterJumping : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private PlayerMovementInput _playerMovementInput;
        [Header("Jump Options")]
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerMovementInput = GetComponent<PlayerMovementInput>();
        }

        void Update()
        {
            if (_rb.linearVelocityY < 0)
                _rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            else if (_rb.linearVelocityY > 0 && !_playerMovementInput.JumpHeld)
                _rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
