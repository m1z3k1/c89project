#pragma strict

var lineRenderer : LineRenderer;
var range :float = 20;
var muzzle : Transform;

function Start () {
 //LineRendererオブジェクトを作成し、lineRendererを取得
     lineRenderer = gameObject.GetComponent.<LineRenderer>();
 
      //LinRendererを設定する。
     //始点と終点の2つの座標で線を引く
      lineRenderer.SetVertexCount(2);
}

function Update () {
    SetLaser();
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
         end = start + (muzzle.forward * range);
 
     //終点を設定する
        lineRenderer.SetPosition(1,end);
    }