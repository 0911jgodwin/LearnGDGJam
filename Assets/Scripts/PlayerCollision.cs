using UnityEngine;

namespace Learn.PlayerController
{
    public class PlayerCollision : MonoBehaviour
    {
        public bool onGround;
        public bool onWall;
        public bool onLeftWall;
        public bool onRightWall;

        [Header("Layers")]
        public LayerMask groundLayer;

        [Header("Collision")]
        public float collisionRadius;
        public Vector2 bottomOffset, leftOffset, rightOffset;

        // Update is called once per frame
        void Update()
        {
            onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
            onWall = CheckWalls(leftOffset)
                  || CheckWalls(rightOffset);
            onLeftWall = CheckWalls(leftOffset);
            onRightWall = CheckWalls(rightOffset);
        }

        bool CheckWalls(Vector2 offset)
        {
            if(Physics2D.OverlapCircle((Vector2)transform.position + offset, collisionRadius, groundLayer))
            {
                Collider2D collider = Physics2D.OverlapCircle((Vector2)transform.position + offset, collisionRadius, groundLayer);
                if (collider.CompareTag("Passthrough"))
                    return false;
                else return true;
            }
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
            Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        }
    }
}
