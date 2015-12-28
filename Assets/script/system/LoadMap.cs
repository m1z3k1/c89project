using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class LoadMap : MonoBehaviour {

    Transform mapTrans;

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
        mapTrans = map.transform;
        Instantiate(map,transform.position,transform.rotation);
    }

    public void enemyPoint()
    {
        Transform point = mapTrans.FindChild("creater" + Random.Range(0, 4));
        GameObject.Find("System/enemyManeger").BroadcastMessage("createEnemy", point);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
