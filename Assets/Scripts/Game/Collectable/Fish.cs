using UnityEngine;
using QFramework;

namespace SquirmealPup
{
    public partial class Fish : ViewController
    {
        public float MinJumpForce = 500f;
        public float MaxJumpForce = 750f;
        public float MinAngle = -45f;
        public float MaxAngle = 45f;

        private void OnEnable()
        {
            float randomAngle = Random.Range(MinAngle, MaxAngle);
            Vector2 jumpDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
            float randomForce = Random.Range(MinJumpForce, MaxJumpForce);

            SelfRigidbody2D.AddForce(jumpDirection * randomForce);

            Destroy(gameObject, 3f);
        }

        private void Update()
        {
            // ������ĳ�����ƥ���˶�����
            if (SelfRigidbody2D.velocity != Vector2.zero)
            {
                float angle = Mathf.Atan2(SelfRigidbody2D.velocity.y, SelfRigidbody2D.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            }
        }
    }
}
