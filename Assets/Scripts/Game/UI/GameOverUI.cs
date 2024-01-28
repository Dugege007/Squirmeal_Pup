using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace SquirmealPup
{
    public partial class GameOverUI : ViewController
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


        }
    }
}
