using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class playerObject : unit {

    private float baseSpeed = 5;

	// Use this for initialization
	public override void Start () {
        base.Start();
        transform.name = "player";
        speed = baseSpeed;
        hitpoint = 20;
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/json/saveData.json");//Jsonファイルの読み込み
        StreamReader bullelInfo = new StreamReader(fi.OpenRead());
        string bullelDataString = bullelInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary allBullelData = (IDictionary)Json.Deserialize(bullelDataString);
        allBullelData = (IDictionary)allBullelData["player"];
        for(int bullelNumber = 1;bullelNumber <= 7;bullelNumber++){
            IDictionary bullelDataNumber = (IDictionary)allBullelData["bullel" + bullelNumber];
            Debug.Log((string)bullelDataNumber["name"]);
            GameObject bullelData = Resources.Load<GameObject>("prefabs/attack/bullel/" + (string)bullelDataNumber["name"]);
            float positionX = (float)((double)bullelDataNumber["positionX"]);
            float positionY = (float)((double)bullelDataNumber["positionY"]);
            Vector3 position = new Vector3(positionX, positionY, 1.5f);
            GameObject setBullel = (GameObject)Instantiate(bullelData,transform.position,transform.rotation);
            setBullel.transform.parent = this.transform;
            setBullel.transform.localPosition = position;
            setBullel.transform.localRotation = Quaternion.Euler(90, 0, 0);
            setBullel.transform.localScale = new Vector3(1,2,1);
            setBullel.transform.name = "bullel" + bullelNumber;
        }
	}
	
	// Update is called once per frame
	public override void Update () {
        speed = Input.GetAxisRaw("Vertical") * baseSpeed;
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        //vec =  new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        // 自身の向きベクトル取得
        float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
        vec = new Vector3(Mathf.Sin(angleDir),0.0f , Mathf.Cos(angleDir));
        base.Update();      
	}

    protected override void DestroyEvent()
    {
        Destroy(transform.FindChild("BabyMugunum").gameObject);
        GameObject.Find("System").gameObject.BroadcastMessage("GameEnd");
    }
}
