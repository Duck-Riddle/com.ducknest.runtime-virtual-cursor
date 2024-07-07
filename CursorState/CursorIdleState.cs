using DuckNest.Core.DesignPatterns;
using UnityEngine;

namespace DuckNest.RuntimeVirtualCursor
{
    public class CursorIdleState : CursorState
    {
        public CursorIdleState(VirtualCursor context) : base(context)
        {
        }

        public override void Enter()
        {
            Debug.Log(this.Context.CursorStateMachine.IsCurrentState<CursorState>());
        }

        public override void Exit()
        {
            
        }
    }
}