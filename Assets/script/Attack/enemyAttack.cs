using UnityEngine;
using System.Collections;

public class enemyAttack : weapon
{

    public override void Start()
    {
        attackPoint = 10;
        transform.tag = "Attack";
        base.Start();
    }

    public override void StartAttack()
    {
        //base.StartAttack();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Attack(GameObject targetObject)
    {
        base.Attack(targetObject);
    }
}
