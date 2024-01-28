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
                TipsText.text = "ʱ�䵽������ʾ��������90s�ڵ����յ㣩";
            }

            if (Global.GetEat.Value)
            {
                TipsText.text = "�����ˣ�����ʾ����Ҫ������ߣ�";

                //AudioKit.PlaySound(Sfx.BEARATTACK);
                SFX.Play();
            }
        }
    }
}
