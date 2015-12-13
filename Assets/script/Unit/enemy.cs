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
}
