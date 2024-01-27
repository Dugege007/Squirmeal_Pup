using UnityEngine;

namespace SquirmealPup
{
    public class Trigger2DCheck : MonoBehaviour
    {
        public LayerMask TargetLayers;
        public int EnterCount;

        public bool IsTriggered
        {
            get
            {
                return EnterCount > 0;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsInLayerMask(collision.gameObject, TargetLayers))
            {
                EnterCount++;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsInLayerMask(collision.gameObject, TargetLayers))
            {
                EnterCount--;
            }
        }

        private bool IsInLayerMask(GameObject obj, LayerMask mask)
        {
            int objLayerMask = 1 << obj.layer;
            return (mask.value & objLayerMask) > 0;
        }
    }
}
