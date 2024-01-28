using UnityEngine;
using QFramework;

namespace SquirmealPup
{
	public partial class Star : ViewController
	{
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Global.Score.Value++;
                Destroy(gameObject);
            }
        }
    }
}
