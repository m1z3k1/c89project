using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class playerObject : unit {

    private GameObject[] bullels;

	// Use this for initialization
	public override void Start () {
        base.Start();
        speed = 5;
        hitpoint = 20;
        gameObject.transform.tag = "Attack";
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/json/saveData.json");//Jsonファイルの読み込み
        StreamReader bullelInfo = new StreamReader(fi.OpenRead());
        string bullelDataString = bullelInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary allWeaponData = (IDictionary)Json.Deserialize(bullelDataString);
        for(int bullelNumber = 1;bullelNumber < 7;bullelNumber++){
            bullels[bullelNumber].transform.name = "bullel" + bullelNumber;
        }
	}
	
	// Update is called once per frame
	public override void Update () {
        vec =  new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        base.Update();      
	}
}
