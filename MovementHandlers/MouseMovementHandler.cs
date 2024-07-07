using UnityEngine;

namespace DuckNest.RuntimeVirtualCursor
{
    public class MouseMovementHandler : ICursorMovementHandler
    {
        public Vector2 Delta { get; } = Vector2.zero;
        public void Update(ref Vector2 position)
        {
            position += Delta;
        }
    }
}