using UnityEngine;
using System.Collections;

public class unit : MonoBehaviour {

    protected Vector3 vec;
    protected float speed;
    private Rigidbody rb;

	// Use this for initialization
	virtual public void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    virtual public void Update()
    {
        rb.velocity = vec * speed;
	}
}
