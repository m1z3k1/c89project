using UnityEngine;
using System.Collections;

public class muzzle : MonoBehaviour {

    public GameObject attackObject;
    private string trigger;

	// Use this for initialization
	void Start () {
        if(transform.parent.tag == "Player"){
            trigger = transform.parent.gameObject.name;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (trigger != null && Input.GetButtonDown(trigger))
        {
            GameObject attack = (GameObject)Instantiate(attackObject,transform.position,transform.rotation);
            attack.transform.parent = this.transform;
            attack.BroadcastMessage("StartAttack", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            //TODO enemy attack
        }
	}
}
