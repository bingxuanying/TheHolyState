using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    internal class SelectableCharacterController : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler
    {
        public static HashSet<SelectableCharacterController> AllSelectable =
            new HashSet<SelectableCharacterController>();

        private NavMeshAgent _agent;

        private bool _selected;

        private SpriteRenderer _spriteRenderer;

        public void OnDeselect(BaseEventData eventData)
        {
            _selected = false;
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
            _selected = true;
            _spriteRenderer.color = Color.grey;
        }

        private void Update()
        {
            if (_selected && Input.GetMouseButtonDown(1))
            {
                Debug.Log("Time to go");
                _agent.destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
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
            foreach (var selectableCharacterController in AllSelectable.Where(t => t._selected).ToList())
                selectableCharacterController.OnDeselect(eventData);
        }

        private void Awake()
        {
            AllSelectable.Add(this);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }
    }
}