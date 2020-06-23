using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Scripts.DesignPattern
{
    public interface IState
    {
        void Initialize();
        void Update();
    }

    public class StateMachine<State>
    {
        private IState _state;
        protected State _currentState;

        protected Dictionary<State, IState> _stateInstances = new Dictionary<State, IState>();

        public StateMachine()
        {

        }

        public void AddStateInstance(State state, IState stateObject)
        {
            _stateInstances.Add(state, stateObject);
        }

        public void Initialize(State initialState)
        {
            ChangeState(initialState);
        }

        public void ChangeState(State nextState)
        {    
            _currentState = nextState;
            _state = _stateInstances[_currentState];
            _state.Initialize();
        }
            
        public void Update()
        {
            _state.Update();
        }
    }
}
