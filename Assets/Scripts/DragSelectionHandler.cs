using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class DragSelectionHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
    {
        public Image SelectionBoxImage;

        private Vector2 _startPosition;
        private Rect _selectionRect;

        public void OnBeginDrag(PointerEventData eventData)
        {
            SelectionBoxImage.gameObject.SetActive(true);
            _startPosition = eventData.position;
            _selectionRect = new Rect();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.position.x < _startPosition.x)
            {
                _selectionRect.xMin = eventData.position.x;
                _selectionRect.xMax = _startPosition.x;
            }
            else
            {
                _selectionRect.xMin = _startPosition.x; 
                _selectionRect.xMax = eventData.position.x;
            }

            if (eventData.position.y < _startPosition.y)
            {
                _selectionRect.yMin = eventData.position.y;
                _selectionRect.yMax = _startPosition.y;
            }
            else
            {
                _selectionRect.yMin = _startPosition.y;
                _selectionRect.yMax = eventData.position.y;
            }

            SelectionBoxImage.rectTransform.offsetMin = _selectionRect.min;
            SelectionBoxImage.rectTransform.offsetMax = _selectionRect.max;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_selectionRect.Area() > 1)
            {
                if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ||
                      Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                    SelectableCharacterController.DeselectAll(new BaseEventData(EventSystem.current));
                foreach (var selectable in SelectableCharacterController.AllSelectable)
                {
                    if (_selectionRect.Contains(Camera.main.WorldToScreenPoint(selectable.transform.position)))
                    {
                        selectable.OnSelect(eventData);
                    }
                }
            }

            SelectionBoxImage.gameObject.SetActive(false);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ||
                      Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                    SelectableCharacterController.DeselectAll(new BaseEventData(EventSystem.current));
            }
        }
    }
}