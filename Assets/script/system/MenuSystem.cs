using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator StageStart()
    {
        AsyncOperation async = Application.LoadLevelAsync(2);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log(async.progress);
            yield return null;
        }
        async.allowSceneActivation = true;
    }

    IEnumerator Customize()
    {
        AsyncOperation async = Application.LoadLevelAsync(4);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log(async.progress);
            yield return null;
        }
        async.allowSceneActivation = true;
    }
}
