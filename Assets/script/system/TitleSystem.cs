using UnityEngine;
using System.Collections;

public class TitleSystem : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GameStart()
    {
        AsyncOperation async = Application.LoadLevelAsync(1);
        async.allowSceneActivation = false;
        while(async.progress < 0.9f){
            Debug.Log(async.progress);
            yield return null;
        }
        async.allowSceneActivation = true;
    }
}
