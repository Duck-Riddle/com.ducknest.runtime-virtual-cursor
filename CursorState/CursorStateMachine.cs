#nullable enable
using DuckNest.Core.DesignPatterns;

namespace DuckNest.RuntimeVirtualCursor
{
    public class CursorStateMachine : IStateMachine<IVirtualCursor>
    {
        ICursorStateFactory StateFactory { get; }
        public IVirtualCursor Context { get; }
        public CursorStateMachine(IVirtualCursor virtualCursor, ICursorStateFactory? stateFactory = default)
        {
            Context = virtualCursor;
            StateFactory = stateFactory ?? new CursorStateFactory(virtualCursor);
        }

        #region ITypeSafeStateMachine Implementation

        IState? state;
        IState? IStateMachine.State => state;
        void IStateMachine.SetState<TState>()
        {
            if ((this as IStateMachine).IsCurrentState<TState>()) return;
            
            state?.Exit();
            state = StateFactory.Get<TState>();
            state?.Enter();
        }

        #endregion
    }
    
}