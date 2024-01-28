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

            ScoreText.text = "本局分数：" + Global.Score.Value;
            RemainTimeText.text = "剩余时间：" + (90 - Global.CurrentTime.Value);
        }
    }
}
