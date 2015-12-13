using UnityEngine;
using System.Collections;

public class playerObject : unit {

	// Use this for initialization
	public override void Start () {
        base.Start();
        speed = 5;
        hitpoint = 20;
	}
	
	// Update is called once per frame
	public override void Update () {
        vec =  new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        base.Update();      
	}
}
