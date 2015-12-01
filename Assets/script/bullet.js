#pragma strict




function Start () {
    
}

function setSpeed (){

    var rb : Rigidbody = gameObject.GetComponent.<Rigidbody>();
    var muzzle : Transform = transform.parent;
    var bullel : Transform = muzzle.parent;
    var dir : Vector3 = (muzzle.position - bullel.position).normalized;
    rb.velocity = dir * 20;
    transform.parent = null;
}

function Update () {
    
}