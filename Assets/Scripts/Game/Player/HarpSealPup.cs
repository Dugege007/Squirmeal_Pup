using UnityEngine;
using QFramework;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using System;
using static SquirmealPup.HarpSealPup;

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

        public Queue<MoveMode> MoveSteps = new Queue<MoveMode>();
        [ShowInInspector]
        private MoveMode mMoveMode;

        [Title("״̬")]
        public bool mIsMovingUp = false;
        public float mMovingUpTime = 0;
        public bool mIsReady = false;
        public float mReadyTime = 0;
        public bool mCanMove = false;

        private void Update()
        {
            mReadyTime = 0f;

            // �ж����λ��
            mMousePos = Input.mousePosition;

            JudgeHorizontal();
            JudgeVertical();

            Debug.Log("MoveSteps����Ԫ�ظ�����" + MoveSteps.Count);

            ExecuteMoveStep();

            if (mCanMove)
                SelfRigidbody2D.velocity = Vector2.Lerp(SelfRigidbody2D.velocity, mTargetVelocity, 1 - Mathf.Exp(-Time.deltaTime * 5));
        }

        private void JudgeHorizontal()
        {
            if (mMousePos.x > Screen.width * 0.1f && mMousePos.x < Screen.width * 0.9f) return;

            MoveSteps.Clear();

            // ����
            if (mMousePos.x <= Screen.width * 0.1f)
            {
                mMoveMode = MoveMode.Left;
                Debug.Log("����");
            }
            // ����
            else if (mMousePos.x >= Screen.width * 0.9f)
            {
                mMoveMode = MoveMode.Right;
                Debug.Log("����");
            }

            AddMoveStep(mMoveMode);
        }

        private void JudgeVertical()
        {
            // ��Ծ�����
            if (mMousePos.y >= Screen.height * 0.9f)
            {
                mMoveMode = MoveMode.Jump;
                Debug.Log("��Ծ�����");
            }
            // ׼��
            else if (mMousePos.y <= Screen.height * 0.1f)
            {
                mMoveMode = MoveMode.Ready;
                Debug.Log("׼��");
            }
            // ����
            else if (mMousePos.y >= (Screen.height / 2 + Screen.height * 0.1f))
            {
                mMoveMode = MoveMode.Up;
                Debug.Log("����");
            }
            // ����
            else if (mMousePos.y <= (Screen.height / 2 - Screen.height * 0.1f))
            {
                mMoveMode = MoveMode.Down;
                Debug.Log("����");
            }
            else
                return;

            AddMoveStep(mMoveMode);
        }

        private void AddMoveStep(MoveMode moveMode)
        {
            // �ж϶������Ƿ�����ͬ���˶���������ֱ�ӷ���
            if (MoveSteps.Count > 0)
                foreach (var step in MoveSteps)
                    if (moveMode == step) return;

            MoveSteps.Enqueue(moveMode);
        }

        private void ExecuteMoveStep()
        {
            if (mIsMovingUp)
                CountMoveUpTime(0.5f);

            if (mIsReady)
                CountReadyTime(0.5f);

            if (MoveSteps.Count > 0)
            {
                switch (MoveSteps.First())
                {
                    case MoveMode.None:
                        mTargetVelocity = Vector2.zero;
                        break;

                    case MoveMode.Up:
                        if (!mCanMove)
                            mCanMove = true;
                        if (!mIsMovingUp)
                            mIsMovingUp = true;
                        break;

                    case MoveMode.Down:
                        mIsMovingUp = false;
                        mMovingUpTime = 0;
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
                        mIsReady = false;
                        mReadyTime = 0;
                        break;

                    case MoveMode.Ready:
                        if (!mIsReady)
                            mIsReady = true;
                        break;

                    default:
                        mTargetVelocity = Vector2.zero;
                        break;
                }

                MoveSteps.Dequeue();
            }
        }

        private void CountMoveUpTime(float moveTime)
        {
            mMovingUpTime += Time.deltaTime;

            if (mMovingUpTime > moveTime)
            {
                mIsMovingUp = false;
                mCanMove = false;
                mMovingUpTime = 0;
            }
        }

        private void CountReadyTime(float moveTime)
        {
            mReadyTime += Time.deltaTime;

            if (mReadyTime > moveTime)
            {
                mIsReady = false;
                mCanMove = false;
                mReadyTime = 0;
            }
        }

    }
}
