using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace SquirmealPup
{
	public partial class GameOverUI : ViewController
	{
        private void Start()
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
