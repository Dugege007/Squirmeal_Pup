using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace SquirmealPup
{
    public partial class GameUI : ViewController
    {
        private void Awake()
        {
            Global.Score.RegisterWithInitValue(score =>
            {
                Score.text = score.ToString();

            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.CurrentTime.RegisterWithInitValue(currentSeconds =>
            {
                // ÿ 20 ֡����һ��
                if (Time.frameCount % 20 == 0)
                {
                    int currentSecondsInt = Mathf.FloorToInt(currentSeconds);
                    int seconds = currentSecondsInt % 60;
                    int minutes = currentSecondsInt / 60;

                    CurrentTime.text = $"{minutes:00}:{seconds:00}";
                }

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            Global.CurrentTime.Value += Time.deltaTime;

            if (Global.CurrentTime.Value > 90)
            {
                SceneManager.LoadScene("GamePass");
            }
        }
    }
}
