using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        
	}

    void StartAttack()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Transform muzzle = this.transform.parent;
        Transform bullel = muzzle.transform.parent;
        Vector3 dir = (muzzle.position - bullel.position).normalized;
        rb.velocity = dir * speed;
        this.transform.parent = null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
