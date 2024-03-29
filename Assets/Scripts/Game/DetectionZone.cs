using UnityEngine;
using QFramework;
using UnityEngine.EventSystems;

namespace SquirmealPup
{
    public partial class DetectionZone : ViewController, IPointerEnterHandler, IPointerClickHandler
    {
        private bool mMouseEnteredUpper = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 mousePosition = eventData.position;
            Debug.Log("鼠标点击区域: " + gameObject.name + " 在位置: " + mousePosition);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector2 mousePosition = eventData.position;
            Debug.Log("鼠标进入区域: " + gameObject.name + " 在位置: " + mousePosition);

            if (eventData.pointerEnter == MEnterDetZone_Up)
            {
                Debug.Log("鼠标进入了 上方 区域");
                mMouseEnteredUpper = true;
            }
            else if (eventData.pointerEnter == MEnterDetZone_Down && mMouseEnteredUpper)
            {
                Debug.Log("鼠标进入了 下方 区域");
                mMouseEnteredUpper = false;
            }
        }
    }
}
