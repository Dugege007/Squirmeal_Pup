using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquirmealPup
{
    public partial class Camera : ViewController
    {
        private void LateUpdate()
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        }
    }
}
