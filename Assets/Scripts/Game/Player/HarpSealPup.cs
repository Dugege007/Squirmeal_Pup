using UnityEngine;
using QFramework;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

namespace SquirmealPup
{
    public partial class HarpSealPup : ViewController
    {
        public float MoveSpeed = 3.5f;

        public Rigidbody2D SelfRigidbody2D;

        [ShowInInspector]
        private bool mCanMove = false;
        private bool mTurnLeft = false;

        [ShowInInspector]
        private float horizontal = 0f;

        private void Update()
        {


            if (mCanMove)
            {
                if (mTurnLeft)
                    horizontal = -1f;
                else
                    horizontal = 1f;

                Vector2 targetVelocity = new Vector2(horizontal, 0).normalized * MoveSpeed; // float 先相乘，再乘向量，这样性能更高
                SelfRigidbody2D.velocity = Vector2.Lerp(SelfRigidbody2D.velocity, targetVelocity, 1 - Mathf.Exp(-Time.deltaTime * 5));
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }
    }
}
