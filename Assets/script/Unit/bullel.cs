using UnityEngine;
using System.Collections;

public class bullel : MonoBehaviour {

    private string trigger;
    private bool fire;

	// Use this for initialization
	void Start () {
        trigger = transform.name;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(trigger)) fire = true;
        else if (Input.GetButtonUp(trigger)) fire = false;
        if (fire)
        {
            // マウスの座標をスクリーン座標系に変換  (1)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 mousePos = ray.origin;

            // マウスから矢印へのベクトルを正規化  (2)
            Vector3 diff = mousePos - transform.position;
            Vector3 norm = diff.normalized;

            // マウスの方向を向かせる (4)
            float deg = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(90, 0, deg - 90);
        }
	}

    public void fireCheck(GameObject muzzle)
    {
        if (fire)
        {
            muzzle.BroadcastMessage("fire");
        }
    }

    public void SetFire()
    {
        fire = true;
    }
}
