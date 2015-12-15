using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using MiniJSON;

public class weapon : MonoBehaviour {

    protected float attackPoint;
    protected IDictionary weaponData;

	// Use this for initialization
	public virtual void Start () {
        
	}
	
	// Update is called once per frame
    public virtual void Update()
    {
	
	}

    public virtual void StartAttack()
    {
        gameObject.transform.tag = "Attack";
        FileInfo fi = new FileInfo(Application.dataPath + "/json/weaponData.json");//Jsonファイルの読み込み
        StreamReader weaponInfo = new StreamReader(fi.OpenRead());
        string weaponDataString = weaponInfo.ReadToEnd();//Jsonファイルをstringに変換
        IDictionary allWeaponData = (IDictionary)Json.Deserialize(weaponDataString);
        string attackName = gameObject.transform.name;
        attackName = attackName.Substring(attackName.IndexOf("("));
        weaponData = (IDictionary)allWeaponData[attackName];
        Debug.Log(attackName);
    }

    public virtual void Attack(GameObject targetObject)
    {
        targetObject.BroadcastMessage("Damage",attackPoint);
    }
}