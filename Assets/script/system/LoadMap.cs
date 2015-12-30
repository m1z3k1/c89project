using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;
using System;

public class LoadMap : MonoBehaviour {

    Transform mapTrans;
    private int exp;
    private bool[] notCreate = new bool[4];

	// Use this for initialization
	void Start () {
       
	}

    void LoadMapData(string stageData)
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/data/" + stageData + ".json");//Jsonファイルの読み込み
        StreamReader mapInfo = new StreamReader(fi.OpenRead());
        string mapDataString = mapInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary mapData = (IDictionary)Json.Deserialize(mapDataString);
        GameObject map = Resources.Load<GameObject>("prefabs/map/" + (string)mapData["name"]);
        mapTrans = map.transform;
        exp = (int)((long)mapData["exp"]);
        Instantiate(map,transform.position,transform.rotation);
    }

    public void enemyPoint()
    {
        int createPoint; 
        if(Array.IndexOf(notCreate,false) == -1){
            notCreate.Initialize();
        }
        do{
           createPoint = UnityEngine.Random.Range(1, 5);
        } while (notCreate[createPoint - 1]);
        notCreate[createPoint - 1] = true;
        Transform point = mapTrans.FindChild("creater" + createPoint);
        GameObject.Find("System/enemyManeger").BroadcastMessage("createEnemy", point);
    }

    void setEXP()
    {
        PlayerPrefs.SetInt("stageExp",exp);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
