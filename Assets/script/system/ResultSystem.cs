using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class ResultSystem : MonoBehaviour {

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
        IDictionary bullelsData = (IDictionary)allWeaponData["releaseWeaponData"];
        playerData = (IDictionary)allWeaponData["player"];
        foreach(DictionaryEntry bul in playerData){
            IDictionary b = (IDictionary)playerData[bul.Key];
            IDictionary bd = (IDictionary)bullelsData[(string)b["name"]];
            int exp = PlayerPrefs.GetInt("stageExp");
            int weaponExp = (int)((long)bd["exp"]);
            bd["exp"] = weaponExp + exp;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
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
