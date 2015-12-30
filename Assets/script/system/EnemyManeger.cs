using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class EnemyManeger : MonoBehaviour {

    private int enemyCount;
    private int enemyLimit;
    private List<GameObject> enemyList;

	// Use this for initialization
	void Start () {
        
	}

    void LoadMapData(string stageData)
    {
        enemyList = new List<GameObject>();
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/data/" + stageData +".json");//Jsonファイルの読み込み
        StreamReader enemyInfo = new StreamReader(fi.OpenRead());
        string enemyDataString = enemyInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary allEnemyData = (IDictionary)Json.Deserialize(enemyDataString);
        IDictionary allEnemyList = (IDictionary)allEnemyData["enemy"];

        for (int enCount = 0; enCount < allEnemyList.Count;enCount++)
        {
            IDictionary enemyData = (IDictionary)allEnemyList[enCount.ToString()];
            GameObject v = Resources.Load<GameObject>("prefabs/unit/" + (string)enemyData["name"]);
            enemyList.Add(v);
        }
        enemyLimit = (int)((long)allEnemyData["enemyLimit"]);
        enemyCount = (int)((long)allEnemyData["enemyCount"]);
        for (int enCount = 0; enCount < enemyLimit;enCount++ )
        {
            GameObject.Find("System/MapGenerator").BroadcastMessage("enemyPoint");
        }
    }

    public void createEnemy(Transform point)
    {
        Instantiate(enemyList[Random.Range(0, enemyList.Count)], point.position, point.rotation);
    }

    private void DestoryEnemy()
    {
        enemyCount--;
        if (enemyCount > enemyLimit)
        {
            GameObject.Find("System/MapGenerator").BroadcastMessage("enemyPoint");
        }
        
    }

	// Update is called once per frame
	void Update () {
	    if(enemyCount == 0){
            enemyCount = -1;
            gameObject.transform.parent.gameObject.BroadcastMessage("GameEnd");
        }
	}
}
