using UnityEngine;
using System.Collections;

public class miniMap : MonoBehaviour {

    private GameObject[] enemys;
    private GameObject player;
    private Color playerColor = Color.green;
    private Color enemyColor = Color.red;
    private int pointSize = 1;
    private Camera miniMapCamera;

	// Use this for initialization
	void Start () {
        
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        LineRenderer playerPoint = player.AddComponent<LineRenderer>();
        setPointData(playerPoint,true);
        foreach(var en in enemys){
            LineRenderer enemyPoint = en.AddComponent<LineRenderer>();
            setPointData(enemyPoint, false);
        }
	}

    private void setPointData(LineRenderer point ,bool pl)
    {
        point.enabled = true;
        point.SetVertexCount(2);
        Color pointColor = pl ? playerColor : enemyColor;
        point.SetColors(pointColor, pointColor);
    }

    void UpdateMap()
    {
        enemys = null;
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        foreach (var en in enemys)
        {
            LineRenderer enemyPoint = en.AddComponent<LineRenderer>();
            setPointData(enemyPoint, false);
        }
    }

    void GeneratePoint(LineRenderer point, Vector3 pos)
    {
        Vector3 cameraPos = Camera.main.WorldToViewportPoint(pos);
        point.SetPosition(0, cameraPos);
        point.SetPosition(1, cameraPos + Vector3.forward);
    }

	// Update is called once per frame
	void Update () {
        GeneratePoint(player.GetComponent<LineRenderer>(),player.transform.position);
	}
}
