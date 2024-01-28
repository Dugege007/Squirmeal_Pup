using UnityEngine;
using QFramework;
using QAssetBundle;

namespace SquirmealPup
{
    public partial class Star : ViewController
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //AudioKit.PlaySound(Sfx.EAT);
                Eat.Play();

                Global.Score.Value++;
                Destroy(gameObject);
            }
        }
    }
}
