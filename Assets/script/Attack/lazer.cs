using UnityEngine;
using System.Collections;

public class lazer : weapon {

    private LineRenderer lineRenderer;
    private float baseRange;
    private float range;
    private Transform muzzle;
    private Vector3 dir;
    private float time;
    RaycastHit hit;

	// Use this for initialization
	public override void Start () {
        base.Start();
	}

    public override void StartAttack (){
        base.StartAttack();
        time = (long)weaponData["time"];
        baseRange = (long)weaponData["range"];
        range = baseRange;
        //LineRendererオブジェクトを作成し、lineRendererを取得
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        muzzle = transform.parent;
        //LinRendererを設定する。
        //始点と終点の2つの座標で線を引く
        lineRenderer.enabled = true;
        lineRenderer.SetVertexCount(2);
        //Transform bullel  = muzzle.parent;
        //dir = (muzzle.position - bullel.position).normalized;
        attackPoint = (long)weaponData["attack"] * Time.deltaTime;
        gameObject.GetComponent<ParticleSystem>().Play();
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Vector3 start;
            //始点を設定
            start = muzzle.position;

            lineRenderer.SetPosition(0, start);

            //終点
            Vector3 end;
            //終点を設定する（終点は始点からmuzzuleの前方向にrange分伸ばした先に設定される）
            end = start + (muzzle.up * range);

            //終点を設定する
            lineRenderer.SetPosition(1, end);
            if (Physics.Raycast(muzzle.position, muzzle.up, out hit, range))
            {
                Attack(hit.transform.gameObject);
            }
            else
            {
                range = baseRange;
            }
        }

	}
    public override void Attack(GameObject targetObject)
    {
        range = Vector3.Distance(gameObject.transform.position,targetObject.transform.position);
        base.Attack(targetObject);
    }
}
