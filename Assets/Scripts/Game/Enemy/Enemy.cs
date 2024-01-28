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

            // ����ڵ����ϡ�ǰ������·��ǰ��û��ǽ
            if (GroundCheck.IsTriggered && FallCheck.IsTriggered && !WallCheck.IsTriggered)
            {
                SelfRigidbody2D.velocity = new Vector2(scaleX * MoveSpeed, SelfRigidbody2D.velocity.y);
            }
            else
            {
                // ת��
                Vector3 localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }
    }
}
