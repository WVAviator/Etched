using System;
using UnityEngine;

namespace Etched
{
    public abstract class InputHandler : MonoBehaviour
    {
        [SerializeField] float minimumDragDistance = 10;

        Camera cam;
        bool isDragging;
        Ray screenRay;
        Vector2 clickedScreenPoint;
        Collider2D clickedCollider;
        [SerializeField] LayerMask inputLayer;

        public static event Action<DragInformation> OnDrag;
        public static event Action<DragInformation> OnRelease;

        void Awake()
        {
            cam = Camera.main;
        }

        protected abstract bool DownInput();
        protected abstract bool UpInput();
        protected abstract bool HoldInput();
        protected abstract Vector2 InputPosition();

        void Update()
        {

            if (DownInput())
            {
                clickedScreenPoint = InputPosition();
                clickedCollider = GetColliderUnderCursor();
            }

            if (UpInput())
            {
                if (isDragging) ProcessRelease();
                else ProcessClick();
                isDragging = false;
            }

            if (HoldInput())
                isDragging = (InputPosition() - clickedScreenPoint).sqrMagnitude >
                             (minimumDragDistance * minimumDragDistance);
            if (isDragging) ProcessDrag();
        }

        Collider2D GetColliderUnderCursor()
        {
            return Physics2D.OverlapPoint(cam.ScreenToWorldPoint(InputPosition()), inputLayer);
        }

        void ProcessClick()
        {
        
        }
        void ProcessDrag()
        {
            if (clickedCollider == null) return;

            OnDrag?.Invoke(new DragInformation(clickedCollider, GetColliderUnderCursor()));
        }

        void ProcessRelease()
        {
            if (clickedCollider == null) return;
            OnRelease?.Invoke(new DragInformation(clickedCollider, GetColliderUnderCursor()));
        }
    }
}