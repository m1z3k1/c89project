#pragma strict

var vec : Vector3;
var speed : float;
var rb : Rigidbody;

function Start () {
    rb = gameObject.GetComponent.<Rigidbody>();    
}

function Update () {
    rb.velocity = vec * speed;
}

function SetVec(v : Vector3){
    vec = v;
}

function SetSpeed(sp : float){
    speed = sp;
}