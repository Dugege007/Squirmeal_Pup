using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;
using QAssetBundle;

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
                Global.ResetData();
                SceneManager.LoadScene("Game");
            });
        }

        private void Start()
        {
            if (Global.TimeOver.Value)
            {
                TipsText.text = "时间到！（提示：本关需90s内到达终点）";
            }

            if (Global.GetEat.Value)
            {
                TipsText.text = "被吃了！（提示：不要往左边走）";

                //AudioKit.PlaySound(Sfx.BEARATTACK);
                SFX.Play();
            }
        }
    }
}
