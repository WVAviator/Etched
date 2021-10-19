using UnityEngine;

namespace Etched
{
    public class DragInformation
    {
        public Collider2D SelectedCollider { get; private set; }
        public bool IsNull { get; private set; }

        public Collider2D CurrentCollider { get; private set; }
        public Vector3 YIntersectionPoint { get; private set; }
        public Ray CurrentScreenRay { get; private set; }
        
        public DragInformation(Collider2D selectedCollider, Collider2D currentCollider)
        {
            SelectedCollider = selectedCollider;
            CurrentCollider = currentCollider;
            IsNull = SelectedCollider == null || CurrentCollider == null;
        }
    }
}