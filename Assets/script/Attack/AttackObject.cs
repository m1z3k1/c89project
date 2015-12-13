using UnityEngine;
using System.Collections;

public class AttackObject : MonoBehaviour {

    protected int attackPoint;

	// Use this for initialization
	public virtual void Start () {
	
	}
	
	// Update is called once per frame
    public virtual void Update()
    {
	
	}

    public virtual void StartAttack()
    {
    }

    public virtual void Attack(GameObject targetObject)
    {
        targetObject.BroadcastMessage("Damage",attackPoint);
    }
}
