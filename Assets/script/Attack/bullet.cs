using UnityEngine;
using System.Collections;

public class bullet : AttackObject {

    public float speed;

	// Use this for initialization
	public override void Start () {
        
	}

    public override void StartAttack()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Transform muzzle = this.transform.parent;
        Transform bullel = muzzle.transform.parent;
        Vector3 dir = (muzzle.position - bullel.position).normalized;
        rb.velocity = dir * speed;
        this.transform.parent = null;
        attackPoint = 10;
    }
	
	// Update is called once per frame
	public override void Update () {
	
	}

    public override void Attack(GameObject targetObject)
    {
        base.Attack(targetObject);
        Destroy(this.gameObject);
    }
}
