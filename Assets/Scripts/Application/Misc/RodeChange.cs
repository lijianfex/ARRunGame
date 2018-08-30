using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodeChange : MonoBehaviour {

    public GameObject roadNow;
    public GameObject roadNext;

    private GameObject parent;
	
	void Start () {
		if(parent==null)
        {
            parent = new GameObject();
            parent.transform.position = Vector3.zero;
            parent.name = "Road";
        }

        roadNow = Game.Instance.Pool.Spawn("Pattern_1", parent.transform);
        roadNext = Game.Instance.Pool.Spawn("Pattern_2", parent.transform);
        roadNext.transform.position += new Vector3(0, 0, 160);
    }
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==Tag.road)
        {
            //回收
            Game.Instance.Pool.UnSpawn(other.gameObject);

            //创建新跑道
            SpawnNewRoad();
        }
    }

    void SpawnNewRoad()
    {
        roadNow = roadNext;
        roadNext = Game.Instance.Pool.Spawn("Pattern_4",parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0, 0, 160);
    }
}
