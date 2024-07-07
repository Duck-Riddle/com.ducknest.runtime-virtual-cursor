using DuckNest.Core.Common;
using DuckNest.Core.DesignPatterns;
using UnityEngine;

namespace DuckNest.RuntimeVirtualCursor
{
    public class VirtualCursor : MonoBehaviour, IVirtualCursor
    {
        IStateMachine<IVirtualCursor> stateMachine;
        [SerializeField] Camera viewCamera;

        SpatialData spatialData;
        public ReadOnlyTransform Transform { get; private set; }
        
        ICursorPosition cursorPosition;
        ICursorMovementHandler movementHandler;
        
        void Awake()
        {
            Transform = spatialData = this.transform;
            cursorPosition = new CursorPosition(spatialData, viewCamera);
            
            stateMachine = new CursorStateMachine(this);
            stateMachine.ChangeState<CursorIdleState>();
            
            movementHandler = new MouseMovementHandler();
        }

        void Update()
        {
            
        }

        IReadOnlyStateMachine IVirtualCursor.CursorStateMachine => stateMachine;
    }
    
    public interface IVirtualCursor
    {
        IReadOnlyStateMachine CursorStateMachine { get; }
        ReadOnlyTransform Transform { get; }
       
    }
}