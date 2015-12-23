using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class EnemyManeger : MonoBehaviour {

    private int enemyCount;

	// Use this for initialization
	void Start () {
        
	}

    void LoadMapData(string stageData)
    {
        /*FileInfo fi = new FileInfo(Application.dataPath + "/Resources/json/" + stageData +".json");//Jsonファイルの読み込み
        StreamReaderenemyInfo = new StreamReader(fi.OpenRead());
        string enemyDataString =enemyInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary allEnemyData = (IDictionary)Json.Deserialize(enemyDataString);
        */

        enemyCount = 1;
    }

    private void DestoryEnemy()
    {
        enemyCount--;
    }

	// Update is called once per frame
	void Update () {
	    if(enemyCount == 0){
            enemyCount = -1;
            gameObject.transform.parent.gameObject.BroadcastMessage("GameEnd");
        }
	}
}
