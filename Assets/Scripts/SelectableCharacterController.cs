using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    internal class SelectableCharacterController : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler
    {
        public static HashSet<SelectableCharacterController> AllSelectable =
            new HashSet<SelectableCharacterController>();

        private SpriteRenderer _spriteRenderer;

        public bool Selected { get; private set; }

        public void OnDeselect(BaseEventData eventData)
        {
            Selected = false;
            _spriteRenderer.color = Color.white;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ||
                      Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                    DeselectAll(eventData);
                OnSelect(eventData);
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            Selected = true;
            _spriteRenderer.color = Color.grey;
        }

        private void OnMouseUp()
        {
            if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ||
                  Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                DeselectAll(null);
            OnSelect(null);
        }

        public static void DeselectAll(BaseEventData eventData)
        {
            foreach (var selectableCharacterController in AllSelectable.Where(t => t.Selected).ToList())
                selectableCharacterController.OnDeselect(eventData);
        }

        private void Awake()
        {
            AllSelectable.Add(this);
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnDestroy()
        {
            AllSelectable.Remove(this);
        }
    }
}