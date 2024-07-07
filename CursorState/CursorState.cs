using DuckNest.Core.DesignPatterns;

namespace DuckNest.RuntimeVirtualCursor
{
    public abstract class CursorState : IState<IVirtualCursor>
    { 
        public IVirtualCursor Context { get; }
        
        protected CursorState(VirtualCursor context)
        {
            Context = context;
        }
        public abstract void Enter();
        public abstract void Exit();
    }
}