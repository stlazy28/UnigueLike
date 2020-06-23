using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterBase
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

        return false;
    }

    protected override bool AttackCheck()
    {
        return false;
    }
}
