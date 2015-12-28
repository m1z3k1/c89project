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
        Vector3 playerPosition = GameObject.Find("player").transform.position;
        vec = (playerPosition - transform.position).normalized;
        Vector3 diff = playerPosition - transform.position;
        float deg = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(deg, deg, 0);
        base.Update();
    }

    protected override void DestroyEvent()
    {
        GameObject.Find("System/enemyManeger").gameObject.BroadcastMessage("DestoryEnemy");
        base.DestroyEvent();
    }
}
