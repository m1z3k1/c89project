using UnityEngine;
using System.Collections;

public class ResultSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator BackTitle()
    {
        AsyncOperation async = Application.LoadLevelAsync(0);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log(async.progress);
            yield return null;
        }
        async.allowSceneActivation = true;
    }
}
