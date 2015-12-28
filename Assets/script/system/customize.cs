using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class customize : MonoBehaviour {

    List<Dropdown.OptionData> option = new List<Dropdown.OptionData>();

	// Use this for initialization
	void Start () {
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/json/saveData.json");//Jsonファイルの読み込み
        StreamReader weaponInfo = new StreamReader(fi.OpenRead());
        string weaponDataString = weaponInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary allWeaponData = (IDictionary)Json.Deserialize(weaponDataString);
        IDictionary playerData = (IDictionary)allWeaponData["player"];
        option = gameObject.GetComponent<Dropdown>().options;
        option.Clear();
        IDictionary bullelData = (IDictionary)playerData[transform.name];
        transform.FindChild("Label").GetComponent<Text>().text = (string)bullelData["name"];
        IDictionary releaseBullels = (IDictionary)allWeaponData["ReleaseBullelData"];
        foreach (DictionaryEntry bul in releaseBullels)
        {
            if((bool)bul.Value){
                option.Add(new Dropdown.OptionData((string)bul.Key));
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
