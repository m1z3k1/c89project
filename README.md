# c89project
***
##重要フォルダ

1.Assetsフォルダ：使用するものは全てこの下に。
2.Assets/jsonフォルダ：データを管理するjsonファイルの置き場
3.Assets/Pluginsフォルダ：外部ファイル
4.Assets/prefabsフォルダ：prefabをまとめるフォルダ
5.Assets/scriptフォルダ：.csファイルをまとめるフォルダ
***
## weapon

武器(弾丸)はステータスをjson、動作をweapon.csを継承したclassを用いて作成します。また、武器名=class名=prefavb名とするように。
###JSON
  jsonでのステータス設定は以下の要領。
    "武器名":{
    "attack":"int型 攻撃力",
    "other parameter":"処理に必要な値",
    "next":[{
    "name":"強化後の武器名",
    "exp":"int型 強化に必要な経験値"
    }]
    },
  
###動作
  武器は製作時にStartAttack()が呼ばれます。このとき、砲身->銃口->弾丸という親子関係になっているので、
必要があれば各種データを利用し、必要が無く自機に関係なく動かしたいなら親子関係を解消してください。
  接触した際に呼ばれるfunctionはAttackです。何も追記しなければ、当たった対象にダメージを与えるだけです。
  
  JSON解析にMiniJSONを使用しています。JSONで解析したデータは整数型はlongで、実数型はdoubleでキャストしないと使用できません。
  
  MiniJSON(github):<https://gist.github.com/darktable/1411710>
