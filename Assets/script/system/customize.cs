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
        FileInfo fi = new FileInfo(Application.dataPath + "/Resources/data/saveData.json");//Jsonファイルの読み込み
        StreamReader weaponInfo = new StreamReader(fi.OpenRead());
        string weaponDataString = weaponInfo.ReadToEnd();//Jsonファイルをstringに変換
        weaponInfo.Close();
        IDictionary allWeaponData = (IDictionary)Json.Deserialize(weaponDataString);
        IDictionary playerData = (IDictionary)allWeaponData["player"];
        option = gameObject.GetComponent<Dropdown>().options;
        option.Clear();
        IDictionary bullelData = (IDictionary)playerData[transform.name];
        transform.FindChild("Label").GetComponent<Text>().text = (string)bullelData["name"];
        option.Add(new Dropdown.OptionData((string)bullelData["name"]));
        IDictionary releaseBullels = (IDictionary)allWeaponData["ReleaseBullelData"];
        foreach (DictionaryEntry bul in releaseBullels)
        {
            IDictionary rb = (IDictionary)releaseBullels[bul.Key];
            if((bool)rb["use"]){
                string bullelName = (string)bullelData["name"];
                string weaponName = (string)bul.Key;
                
                option.Add(new Dropdown.OptionData(weaponName));
                
            }
            
        }
	}

    public void save()
    {
        Debug.Log(transform.FindChild("Label").GetComponent<Text>().text);
        string[] data = new string[2] {transform.name,transform.FindChild("Label").GetComponent<Text>().text};
        GameObject.Find("EventSystem").BroadcastMessage("customize",data);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
