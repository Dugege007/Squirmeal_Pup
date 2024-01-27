using UnityEngine;
using QFramework;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using static UnityEditor.VersionControl.Asset;

namespace SquirmealPup
{
    public partial class HarpSealPup : ViewController
    {
        public enum MoveMode
        {
            None,
            Up,
            Down,
            Left,
            Right,
            Jump,
            Ready,
        }

        public float MoveSpeed = 3.5f;
        private Vector2 mTargetVelocity = Vector2.zero;

        public float JumpForce = 300f;

        public Rigidbody2D SelfRigidbody2D;

        [ShowInInspector]
        private Vector2 mMousePos = Vector2.zero;
        private Vector2 mMouseLastPos = Vector2.zero;

        [ShowInInspector]
        private MoveMode mCurrentMoveMode;
        private MoveMode mLastMoveMode;

        public bool mMovingDown = false;
        public bool mMovingUp = false;
        public float mMoveTimer = 0;
        public bool mIsFreezing = false;
        public float mFreezingTime = 0;
        public bool mIsReady = false;
        public float mReadyTime = 0;

        public bool mJumping = false;

        private void Update()
        {
            if (mMovingUp)
                CountMovingTime(0.3f);
            if (mMovingDown)
                CountMovingTime(0.5f);
            if (mIsReady)
                CountReadyTime(0.5f);
            if (mIsFreezing)
                CountFreezingTime(1.5f);

            // 判断鼠标位置
            mMousePos = Input.mousePosition;
            if (Vector2.Distance(mMouseLastPos, mMousePos) > 0.05f)
                mMouseLastPos = mMousePos;
            else return;

            JudgeHorizontal();
            JudgeVertical();
        }

        private void FixedUpdate()
        {
            if (mMovingUp || mMovingDown)
                SelfRigidbody2D.velocity = Vector2.Lerp(SelfRigidbody2D.velocity, mTargetVelocity, 1 - Mathf.Exp(-Time.deltaTime * 5));

            if (mJumping)
            {
                mJumping = false;
                SelfRigidbody2D.AddForce(Vector2.up * JumpForce);
            }
        }

        private void JudgeHorizontal()
        {
            // 在范围外直接返回
            if (mMousePos.x > Screen.width * 0.1f && mMousePos.x < Screen.width * 0.9f) return;

            // 向左
            if (mMousePos.x <= Screen.width * 0.1f)
                mCurrentMoveMode = MoveMode.Left;
            // 向右
            else if (mMousePos.x >= Screen.width * 0.9f)
                mCurrentMoveMode = MoveMode.Right;

            ExecuteMoveStep();
        }

        private void JudgeVertical()
        {
            // 跳跃或大跳
            if (mMousePos.y >= Screen.height * 0.9f)
                mCurrentMoveMode = MoveMode.Jump;
            // 准备
            else if (mMousePos.y <= Screen.height * 0.1f)
                mCurrentMoveMode = MoveMode.Ready;
            // 向上
            else if (mMousePos.y >= (Screen.height / 2 + Screen.height * 0.1f))
                mCurrentMoveMode = MoveMode.Up;
            // 向下
            else if (mMousePos.y <= (Screen.height / 2 - Screen.height * 0.1f))
                mCurrentMoveMode = MoveMode.Down;

            ExecuteMoveStep();
        }

        private void ExecuteMoveStep()
        {
            // 判断上次是否为相同的运动，是则直接返回
            if (mCurrentMoveMode == mLastMoveMode) return;

            Debug.Log("执行移动模式：" + mCurrentMoveMode);

            switch (mCurrentMoveMode)
            {
                case MoveMode.None:
                    mTargetVelocity = Vector2.zero;
                    break;

                case MoveMode.Up:
                    if (!mMovingUp && !mIsFreezing)
                    {
                        mMovingUp = true;
                        mMoveTimer = 0;
                        mMovingDown = false;
                    }
                    break;

                case MoveMode.Down:
                    if (mMovingUp && !mMovingDown && !mIsFreezing)
                    {
                        mMovingDown = true;
                        mMoveTimer = 0;
                        mMovingUp = false;
                    }
                    break;

                case MoveMode.Left:
                    mTargetVelocity = Vector2.left * MoveSpeed;
                    break;

                case MoveMode.Right:
                    mTargetVelocity = Vector2.right * MoveSpeed;
                    break;

                case MoveMode.Jump:
                    if (mIsReady)
                        JumpForce = 600f;
                    else
                        JumpForce = 300f;
                    mJumping = true;
                    mIsReady = false;
                    mReadyTime = 0;
                    break;

                case MoveMode.Ready:
                    if (!mIsReady)
                    {
                        mIsReady = true;
                        mReadyTime = 0;
                    }
                    break;

                default:
                    mTargetVelocity = Vector2.zero;
                    break;
            }

            mLastMoveMode = mCurrentMoveMode;
        }

        private void CountMovingTime(float maxMoveTime)
        {
            mMoveTimer += Time.deltaTime;

            if (mMoveTimer > maxMoveTime)
            {
                mMovingUp = false;
                mMovingDown = false;
                mMoveTimer = 0;

                if (mCurrentMoveMode == mLastMoveMode)
                {
                    mIsFreezing = true;
                    mFreezingTime = 0;
                }
            }
        }

        private void CountFreezingTime(float maxFreezeTime)
        {
            mFreezingTime += Time.deltaTime;

            if (mFreezingTime > maxFreezeTime)
            {
                mIsFreezing = false;
                mFreezingTime = 0;
            }
        }

        private void CountReadyTime(float maxReadyTime)
        {
            mReadyTime += Time.deltaTime;

            if (mReadyTime > maxReadyTime)
            {
                mIsReady = false;
                mReadyTime = 0;
            }
        }
    }
}
