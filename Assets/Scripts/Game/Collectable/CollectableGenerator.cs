using UnityEngine;
using QFramework;
using System.Collections.Generic;

namespace SquirmealPup
{
    public partial class CollectableGenerator : ViewController
    {
        public float MinFishGTime = 3f;
        public float MaxFishGTime = 10f;
        private float mCurrentFishGTime = 0;

        public float MinPenguinGTime = 5f;
        public float MaxPenguinGTime = 15f;
        private float mCurrentPenguinGTime = 0;

        public float MinStarGTime = 2f;
        public float MaxStarGTime = 5f;
        private float mCurrentStarGTime = 0;

        public List<Transform> StarGPoss = new List<Transform>();

        private void Awake()
        {
            Fish.Hide();
            SmallPenguin.Hide();
            Star.Hide();
        }

        private void Update()
        {
            mCurrentFishGTime += Time.deltaTime;
            if (mCurrentFishGTime > Random.Range(MinFishGTime, MaxFishGTime))
            {
                Fish.InstantiateWithParent(this)
                    .Position(FishGPos.position)
                    .Show();
                mCurrentFishGTime = 0;
            }

            mCurrentPenguinGTime += Time.deltaTime;
            if (mCurrentPenguinGTime > Random.Range(MinPenguinGTime, MaxPenguinGTime))
            {
                SmallPenguin.InstantiateWithParent(this)
                    .Position(PenguinGPos.position)
                    .Show();
                mCurrentPenguinGTime = 0;
            }

            mCurrentStarGTime += Time.deltaTime;
            if (mCurrentStarGTime > Random.Range(MinStarGTime, MaxStarGTime))
            {
                Vector3 randomGPos = StarGPoss[Random.Range(0, StarGPoss.Count - 1)].position;
                Star.InstantiateWithParent(this)
                    .Position(randomGPos)
                    .Show();
                mCurrentStarGTime = 0;
            }
        }
    }
}
