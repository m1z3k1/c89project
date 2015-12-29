using UnityEngine;
using System.Collections;

public class muzzle : MonoBehaviour {

    public GameObject attackObject;
    private string trigger;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.parent.tag == "Player" && Input.GetButtonDown("Fire1"))
        {
            transform.parent.transform.parent.gameObject.BroadcastMessage("fireCheck",gameObject);
        }
        else
        {
            //TODO enemy attack
        }
	}

    public void fire()
    {
        GameObject attack = (GameObject)Instantiate(attackObject, transform.position, transform.rotation);
        attack.transform.parent = this.transform;
        attack.BroadcastMessage("StartAttack", SendMessageOptions.DontRequireReceiver);
    }
}
