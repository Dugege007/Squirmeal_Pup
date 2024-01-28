using UnityEngine;
using QFramework;
using UnityEngine.UI;

namespace SquirmealPup
{
    public partial class TipsController : ViewController
    {
        private void Awake()
        {
            // ����
            TipsArea.OnTriggerEnter2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    Global.IsInTipsArea.Value = true;
                }
            });

            Bear.OnTriggerEnter2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    BearText.Show();
                }
            });

            LeftAndRightAndUpAndDown.OnTriggerEnter2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    LeftText.Show();
                    RightText.Show();
                    StartRightText.Show();
                    UpText.Show();
                    DownText.Show();
                }
            });

            Jump.OnTriggerEnter2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    TopText.Show();
                }
            });

            BigJump.OnTriggerEnter2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    StartRightText.Show();
                    StartRightText.GetComponent<Text>().text = "�����յ�ǰ����";
                    BottomText.Show();
                }
            });

            // �뿪
            TipsArea.OnTriggerExit2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    Global.IsInTipsArea.Value = false;
                }
            });

            Bear.OnTriggerExit2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    BearText.Hide();
                }
            });

            LeftAndRightAndUpAndDown.OnTriggerExit2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    LeftText.Hide();
                    RightText.Hide();
                    StartRightText.Hide();
                    UpText.Hide();
                    DownText.Hide();
                }
            });

            Jump.OnTriggerExit2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    TopText.Hide();
                }
            });

            BigJump.OnTriggerExit2DEvent(collider2D =>
            {
                if (collider2D.CompareTag("Player"))
                {
                    BottomText.Hide();
                }
            });
        }
    }
}
