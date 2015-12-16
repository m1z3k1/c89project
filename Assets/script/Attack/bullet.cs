using UnityEngine;
using System.Collections;

public class bullet : weapon
{
	// Use this for initialization
	public override void Start () {
        base.Start();
	}

    public override void StartAttack()
    {
        base.StartAttack();
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Transform muzzle = this.transform.parent;
        Transform bullel = muzzle.transform.parent;
        Vector3 dir = (muzzle.position - bullel.position).normalized;
        float speed = (long)weaponData["speed"];
        rb.velocity = dir * speed;
        this.transform.parent = null;
        attackPoint = (long)weaponData["attack"];
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
