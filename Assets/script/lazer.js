#pragma strict

var lineRenderer : LineRenderer;
var range :float = 20;
var muzzle : Transform;
var dir : Vector3;
var time : float;

function Start () {
 
}

function setSpeed (){
    time = 4;
    //LineRendererオブジェクトを作成し、lineRendererを取得
    lineRenderer = this.GetComponent.<LineRenderer>();
    muzzle = transform.parent;
    //LinRendererを設定する。
    //始点と終点の2つの座標で線を引く
    lineRenderer.enabled = true;
    lineRenderer.SetVertexCount(2);
    var bullel : Transform = muzzle.parent;
    dir = (muzzle.position - bullel.position).normalized;
    transform.parent = null;
     
}

function Update () {
    time -= Time.deltaTime;
    if(time > 0){
        SetLaser();
    }else{
        Destroy(this.gameObject);
    }
}

function SetLaser(){
 
        //始点
        var start : Vector3;
      //始点を設定
         start = muzzle.position;
 
        lineRenderer.SetPosition(0,start);
 
      //終点
        var end : Vector3;
        //終点を設定する（終点は始点からmuzzuleの前方向にrange分伸ばした先に設定される）
         end = start + (dir * range);
 
     //終点を設定する
        lineRenderer.SetPosition(1,end);
        }