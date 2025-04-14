using UnityEngine;

namespace PI.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float jumpHeight;

        Rigidbody2D rb2D;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public void Move(float direction)
        {
            rb2D.velocity = new Vector2(direction * speed, rb2D.velocity.y);
        }

        public void Jump()
        {
            float gravity = Mathf.Abs(Physics2D.gravity.y);
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Sqrt(jumpHeight * gravity * 2));
        }

        public void HaltJump()
        {
            if (rb2D.velocity.y <= 0) { return; }

            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }
}