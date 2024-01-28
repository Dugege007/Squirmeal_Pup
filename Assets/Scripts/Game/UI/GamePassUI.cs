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
                SceneManager.LoadScene("Game");
            });

            ScoreText.text = "���ַ�����" + Global.Score.Value;
        }
    }
}
