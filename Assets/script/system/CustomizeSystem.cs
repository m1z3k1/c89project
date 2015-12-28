using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class CustomizeSystem : MonoBehaviour {

    private IDictionary playerData;
    private IDictionary allWeaponData;
    FileInfo fi;

	// Use this for initialization
	void Start () {
        fi = new FileInfo(Application.dataPath + "/Resources/json/saveData.json");//Jsonファイルの読み込み
        StreamReader weaponInfo = new StreamReader(fi.OpenRead());
        string weaponDataString = weaponInfo.ReadToEnd();//Jsonファイルをstringに変換
        weaponInfo.Close();
        allWeaponData = (IDictionary)Json.Deserialize(weaponDataString);
        playerData = (IDictionary)allWeaponData["player"];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void customize(string[] data)
    {
        IDictionary bullelData = (IDictionary)playerData[data[0]];
        bullelData["name"] = data[1];
    }

    void save()
    {
        string saveData = Json.Serialize(allWeaponData);
        Debug.Log(saveData);
        StreamWriter fw = new StreamWriter(fi.OpenWrite());
        fw.WriteLine(saveData);
        fw.Close();
        fw.Dispose();
    }

    IEnumerator BackMenu()
    {
        AsyncOperation async = Application.LoadLevelAsync(1);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log(async.progress);
            yield return null;
        }
        save();
        async.allowSceneActivation = true;
    }
}
