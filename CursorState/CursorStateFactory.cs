using System;
using System.Collections.Concurrent;
using DuckNest.Core.DesignPatterns;
using DuckNest.Core.Exceptions;

namespace DuckNest.RuntimeVirtualCursor
{
    internal class CursorStateFactory : ICursorStateFactory
    {
        readonly IVirtualCursor context;
        
        static readonly ConcurrentDictionary<Type, CursorState> StateCache = new();
        
        public CursorStateFactory(IVirtualCursor context)
        {
            this.context = context;
        }
        
        public IState Get<TState>() where TState : class, IState
        {
            var stateType = typeof(TState);

            if (StateCache.TryGetValue(stateType, out var state))
                return state;

            state = Activator.CreateInstance(stateType, args: context) as CursorState;

            if (state is null) throw new InvalidStateTransitionException();

            return StateCache[stateType] = state;
        }
    }
    
    public interface ICursorStateFactory
    {
        IState Get<TState>() where TState : class, IState;
    }
}