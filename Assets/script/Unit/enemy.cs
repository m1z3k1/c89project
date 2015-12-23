using UnityEngine;
using System.Collections;

public class enemy : unit {

    public override void Start()
    {
        base.Start();
        speed = 0;
        hitpoint = 30;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void DestroyEvent()
    {
        GameObject.Find("System/enemyManeger").gameObject.BroadcastMessage("DestoryEnemy");
        base.DestroyEvent();
    }
}
