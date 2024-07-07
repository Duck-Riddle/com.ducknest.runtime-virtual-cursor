using UnityEngine;

namespace DuckNest.RuntimeVirtualCursor
{
    public interface ICursorMovementHandler
    {
        Vector2 Delta { get; }

        void Update(ref Vector2 position);
    }
}