using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {

   

	// Use this for initialization
	void Start () {        
        gameObject.transform.FindChild("MapGenerator").gameObject.BroadcastMessage("LoadMapData", "demo");
        GameObject player = (GameObject)Resources.Load("prefabs/unit/player");
        Instantiate(player, new Vector3(0, 3, 0), transform.rotation);
        gameObject.transform.FindChild("enemyManeger").gameObject.BroadcastMessage("LoadMapData", "demo");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GameEnd()
    {
        AsyncOperation async = Application.LoadLevelAsync(3);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log(async.progress);
            yield return null;
        }

        gameObject.transform.FindChild("MapGenerator").BroadcastMessage("setEXP");

        async.allowSceneActivation = true;
    }
}
