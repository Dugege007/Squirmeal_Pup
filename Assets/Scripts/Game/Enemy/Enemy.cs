using UnityEngine;
using QFramework;

namespace SquirmealPup
{
	public partial class Enemy : ViewController
	{
		public float MoveSpeed = 3f;

        private void FixedUpdate()
        {
            float scaleX = transform.localScale.x;

            // 如果在地面上、前方还有路、前方没有墙
            if (GroundCheck.IsTriggered && FallCheck.IsTriggered && !WallCheck.IsTriggered)
            {
                SelfRigidbody2D.velocity = new Vector2(scaleX * MoveSpeed, SelfRigidbody2D.velocity.y);
            }
            else
            {
                // 转向
                Vector3 localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }
    }
}
