using UnityEngine;
using QFramework;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

namespace SquirmealPup
{
    public partial class DetectionZone : ViewController, IPointerEnterHandler, IPointerClickHandler
    {
        [ShowInInspector]
        private bool mMouseEnteredUpper = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 mousePosition = eventData.position;
            Debug.Log("���������: " + gameObject.name + " ��λ��: " + mousePosition);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector2 mousePosition = eventData.position;
            Debug.Log("����������: " + gameObject.name + " ��λ��: " + mousePosition);

            if (eventData.pointerEnter == MEnterDetZone_Up)
            {
                Debug.Log("������ �Ϸ� ����");
                mMouseEnteredUpper = true;
            }
            else if (eventData.pointerEnter == MEnterDetZone_Down && mMouseEnteredUpper)
            {
                Debug.Log("������ �·� ����");
                mMouseEnteredUpper = false;

                MovePlayer();
            }
        }

        private void MovePlayer()
        {
            Player.position += Vector3.right;
        }
    }
}
