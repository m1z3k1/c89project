#pragma strict
var attackObjet : GameObject;
var trigger : String;

function Start () {
    trigger = transform.parent.gameObject.name;
}

function Update () {
    //get parentName And Fire
    if(Input.GetButtonDown(trigger)){
         var attack : GameObject = Instantiate(attackObjet,transform.position,transform.rotation);
         attack.transform.parent = this.transform;
         attack.BroadcastMessage("setSpeed",SendMessageOptions.DontRequireReceiver);
    }
    var mouse : Vector3 = new Vector3(Input.mousePosition.x,0,Input.mousePosition.z);

}