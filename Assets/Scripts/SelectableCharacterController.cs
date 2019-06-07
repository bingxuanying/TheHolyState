using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    internal class SelectableCharacterController : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler
    {
        public static HashSet<SelectableCharacterController> AllSelectable =
            new HashSet<SelectableCharacterController>();

        public static HashSet<SelectableCharacterController> CurrentSelected =
            new HashSet<SelectableCharacterController>();

        private SpriteRenderer _spriteRenderer;

        public void OnDeselect(BaseEventData eventData)
        {
            CurrentSelected.Remove(this);
            _spriteRenderer.color = Color.white;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ||
                  Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                DeselectAll(eventData);
            OnSelect(eventData);
        }

        public void OnSelect(BaseEventData eventData)
        {
            CurrentSelected.Add(this);
            _spriteRenderer.color = Color.grey;
        }

        public static void DeselectAll(BaseEventData eventData)
        {
            foreach (var selectableCharacterController in CurrentSelected.ToList())
                selectableCharacterController.OnDeselect(eventData);
        }

        private void Awake()
        {
            AllSelectable.Add(this);
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}