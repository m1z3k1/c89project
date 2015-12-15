﻿using UnityEngine;
using System.Collections;

public class unit : MonoBehaviour {

    protected Vector3 vec;
    protected float speed;
    private Rigidbody rb;
    protected int hitpoint;

	// Use this for initialization
	virtual public void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    virtual public void Update()
    {
        rb.velocity = vec * speed;
	}

    public void Damage(int attack)
    {
        hitpoint -= attack;
        if(hitpoint <= 0){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        string collisionTag = collision.transform.tag;

        switch(collisionTag){
            case "Attack":
                collision.gameObject.BroadcastMessage("Attack",this.gameObject);
                break;
            default:
                break;
        }

    }
}