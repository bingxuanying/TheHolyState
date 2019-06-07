using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class DragSelectionHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        public Image SelectionBoxImage;

        private Vector2 _startPosition;
        private Rect _selectionRect;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ||
                  Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                SelectableCharacterController.DeselectAll(new BaseEventData(EventSystem.current));
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
            SelectionBoxImage.gameObject.SetActive(false);
            foreach (var selectable in SelectableCharacterController.AllSelectable)
            {
                if (_selectionRect.Contains(Camera.main.WorldToScreenPoint(selectable.transform.position)))
                {
                    selectable.OnSelect(eventData);
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ||
                  Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                SelectableCharacterController.DeselectAll(new BaseEventData(EventSystem.current));
        }
    }
}