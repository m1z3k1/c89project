using UnityEngine;
using System.Collections;

public class unit : MonoBehaviour {

    protected Vector3 vec;
    protected float speed;
    private Rigidbody rb;
    protected float hitpoint;

	// Use this for initialization
	virtual public void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    virtual public void Update()
    {
        rb.velocity = vec * speed;
	}

    public void Damage(float attack)
    {
        hitpoint -= attack;
        Debug.Log(hitpoint);
        if(hitpoint <= 0){
            this.DestroyEvent();
        }
    }

    virtual protected void DestroyEvent()
    {
        Destroy(this.gameObject);
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
