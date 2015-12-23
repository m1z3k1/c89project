using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class playerObject : unit {

    

	// Use this for initialization
	public override void Start () {
        base.Start();
        speed = 5;
        hitpoint = 20;
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/json/saveData.json");//Jsonファイルの読み込み
        StreamReader bullelInfo = new StreamReader(fi.OpenRead());
        string bullelDataString = bullelInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary allBullelData = (IDictionary)Json.Deserialize(bullelDataString);
        allBullelData = (IDictionary)allBullelData["player"];
        for(int bullelNumber = 1;bullelNumber < 3;bullelNumber++){
            IDictionary bullelDataNumber = (IDictionary)allBullelData["bullel" + bullelNumber];
            Debug.Log((string)bullelDataNumber["name"]);
            GameObject bullelData = Resources.Load<GameObject>("prefabs/attack/bullel/" + (string)bullelDataNumber["name"]);
            float positionX = (float)((long)bullelDataNumber["positionX"]);
            float positionY = (float)((long)bullelDataNumber["positionY"]);
            Vector3 position = new Vector3(positionX, positionY, 0);
            GameObject setBullel = (GameObject)Instantiate(bullelData,transform.position,transform.rotation);
            setBullel.transform.parent = this.transform;
            setBullel.transform.position = position;
            setBullel.transform.name = "bullel" + bullelNumber;
        }
	}
	
	// Update is called once per frame
	public override void Update () {
        vec =  new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        base.Update();      
	}

    protected override void DestroyEvent()
    {
        GameObject.Find("System").gameObject.BroadcastMessage("GameEnd");
        base.DestroyEvent();
    }
}
