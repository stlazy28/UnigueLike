using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalInstance;

public class PlayerController : CharacterBase
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

    protected override bool MoveCheck()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput == 0 && verticalInput == 0)
        {
            return false;
        }

        if (horizontalInput > 0)
        {
            dir = Direction.Right;
        }
        else if (horizontalInput < 0)
        {
            dir = Direction.Left;
        }

        if (verticalInput > 0)
        {
            dir = Direction.Up;
        }
        else if (verticalInput < 0)
        {
            dir = Direction.Down;
        }

        GlobalInstance GI = GlobalInstance.GetInstance;

        Vector2Int deltaPos = new Vector2Int((int)GI.dirToVec[dir].x, (int)GI.dirToVec[dir].y);
        Vector2Int currentPos = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        if(_manager.CanMove(currentPos + deltaPos))
        {
            _stateMachine.ChangeState(State.Move);
            return true;
        }

        FaceTo(dir);
        return false;
    }

    protected override bool AttackCheck()
    {
        if (Input.GetButton("Attack"))
        {
            _stateMachine.ChangeState(State.Attack);
            return true;
        }

        return false;
    }

}
