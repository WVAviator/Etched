using UnityEngine;

namespace Etched
{
    public class MouseController : InputHandler
    {
        protected override bool DownInput()
        {
            return Input.GetMouseButtonDown(0);
        }

        protected override bool UpInput()
        {
            return Input.GetMouseButtonUp(0);
        }

        protected override bool HoldInput()
        {
            return Input.GetMouseButton(0);
        }

        protected override Vector2 InputPosition()
        {
            return Input.mousePosition;
        }
    }
}