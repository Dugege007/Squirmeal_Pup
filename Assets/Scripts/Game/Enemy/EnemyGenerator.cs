using UnityEngine;
using QFramework;

namespace SquirmealPup
{
    public partial class EnemyGenerator : ViewController
    {
        public float MinGTime = 15f;
        public float MaxGTime = 30f;

        private float mCurrentGTime = 0;

        private void Awake()
        {
            WhiteBear.Hide();
        }

        private void Update()
        {
            if (!Global.IsInTipsArea.Value)
                mCurrentGTime += Time.deltaTime;

            if (mCurrentGTime > Random.Range(MinGTime, MaxGTime))
            {
                WhiteBear.InstantiateWithParent(this)
                    .Position(EnemyGPos.position)
                    .Show();

                mCurrentGTime = 0;
            }
        }
    }
}
