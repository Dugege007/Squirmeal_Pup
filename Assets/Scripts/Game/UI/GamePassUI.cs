using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace SquirmealPup
{
    public partial class GamePassUI : ViewController
    {
        private void Awake()
        {
            BtnQuit.onClick.AddListener(() =>
            {
                Application.Quit();
            });

            BtnRestart.onClick.AddListener(() =>
            {
                Global.ResetData();
                SceneManager.LoadScene("Game");
            });

            ScoreText.text = "���ַ�����" + Global.Score.Value;
            RemainTimeText.text = "ʣ��ʱ�䣺" + (90 - Global.CurrentTime.Value);
        }
    }
}
