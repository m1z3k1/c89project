using UnityEngine;
using System.Collections;

public class lazer : MonoBehaviour {

    private LineRenderer lineRenderer;
    private float range = 20;
    private Transform muzzle;
    private Vector3 dir;
    private float time;

	// Use this for initialization
	void Start () {
	
	}

    void StartAttack (){
    time = 4;
    //LineRendererオブジェクトを作成し、lineRendererを取得
    lineRenderer = gameObject.GetComponent<LineRenderer>();
    muzzle = transform.parent;
    //LinRendererを設定する。
    //始点と終点の2つの座標で線を引く
    lineRenderer.enabled = true;
    lineRenderer.SetVertexCount(2);
    Transform bullel  = muzzle.parent;
    dir = (muzzle.position - bullel.position).normalized;
     
}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
	    if(time <= 0){
            Destroy(this.gameObject);
        }
	}
}
