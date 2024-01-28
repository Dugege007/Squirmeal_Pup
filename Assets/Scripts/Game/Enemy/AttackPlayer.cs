using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquirmealPup
{
    public class AttackPlayer : MonoBehaviour
    {
        private void Start()
        {
        }

        private void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Global.GetEat.Value = true;
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
