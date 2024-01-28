using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquirmealPup
{
    public class AttackPlayer : MonoBehaviour
    {
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
