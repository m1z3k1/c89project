﻿using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {

   

	// Use this for initialization
	void Start () {
        gameObject.transform.FindChild("enemyManeger").gameObject.BroadcastMessage("LoadMapData","demo");
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
        async.allowSceneActivation = true;
    }
}