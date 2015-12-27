using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class LoadMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}

    void LoadMapData(string stageData)
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/json/" + stageData + ".json");//Jsonファイルの読み込み
        StreamReader mapInfo = new StreamReader(fi.OpenRead());
        string mapDataString = mapInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary mapData = (IDictionary)Json.Deserialize(mapDataString);
        GameObject map = Resources.Load<GameObject>("prefabs/map/" + (string)mapData["name"]);
        Instantiate(map,transform.position,transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
