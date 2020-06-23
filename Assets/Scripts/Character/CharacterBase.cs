using Assets.Scripts.DesignPattern;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;
using static GlobalInstance;

public abstract class CharacterBase : MonoBehaviour
{
    protected enum State
    {
        Idle,
        Move,
        Attack,
        React
    };

    protected CharacterManager _manager = null;

    protected StateMachine<State> _stateMachine = new StateMachine<State>();

    Animator _animator = null;

    CharacterMove _move;

    protected Direction dir = Direction.Down;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _manager = transform.parent.GetComponent<CharacterManager>();
        _move = GetComponent<CharacterMove>();
        _animator = GetComponent<Animator>();

        _stateMachine.AddStateInstance(State.Idle, new Idle(this));
        _stateMachine.AddStateInstance(State.Move, new Move(this));
        _stateMachine.AddStateInstance(State.Attack, new Attack(this));
        _stateMachine.AddStateInstance(State.React, new React(this));

        _stateMachine.Initialize(State.Idle);

        Debug.Log("CharacterBase: Start()");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _stateMachine.Update();   
    }

    protected abstract bool MoveCheck();
    protected abstract bool AttackCheck();

    protected void FaceTo(Direction direction)
    {
        _animator.SetInteger("Direction", (int)direction);
    }

    public void BackToIdle()
    {
        _animator.SetTrigger("Idle");
        _stateMachine.ChangeState(State.Idle);
    }

    class Idle : IState
    {
        CharacterBase _main;

        public Idle(CharacterBase main)
        {
            _main = main;

        }

        public void Initialize()
        {

        }

        public void Update()
        {
            if (_main.MoveCheck())
            {
                return;
            }
            if (_main.AttackCheck())
            {
                return;
            }
        }
    }

    class Move : IState
    {
        CharacterBase _main;

        public Move(CharacterBase main)
        {
            _main = main;
        }

        public void Initialize()
        {
            _main.FaceTo(_main.dir);

            Vector2 deltaPos = GlobalInstance.GetInstance.dirToVec[_main.dir];
            _main._move.Move(deltaPos);
        }

        public void Update()
        {
            if (_main._move.IsWalked)
            {
                _main._stateMachine.ChangeState(State.Idle);
            }
        }
    }

    class Attack : IState
    {
        CharacterBase _main;

        public Attack(CharacterBase main)
        {
            _main = main;
        }

        public void Initialize()
        {
            _main.FaceTo(_main.dir);
            _main._animator.SetTrigger("Attack");
        }

        public void Update()
        {

        }
    }

    class React : IState
    {
        CharacterBase _main;

        public React(CharacterBase main)
        {
            _main = main;
        }

        public void Initialize()
        {

        }

        public void Update()
        {

        }
    }
}
