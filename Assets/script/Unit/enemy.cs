using UnityEngine;
using System.Collections;

public class enemy : unit {

    public override void Start()
    {
        base.Start();
        speed = 6;
        hitpoint = 30;
    }

    public override void Update()
    {
        Transform player = GameObject.Find("player").transform;
        Vector3 playerPosition = player.position;
        vec = (playerPosition - transform.position).normalized;
        transform.LookAt(player);
        base.Update();
    }

    protected override void DestroyEvent()
    {
        GameObject.Find("System/enemyManeger").gameObject.BroadcastMessage("DestoryEnemy");
        base.DestroyEvent();
    }
}
