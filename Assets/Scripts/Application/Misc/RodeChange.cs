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
        AddItem(roadNow);
        AddItem(roadNext);

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

    //生成跑道
    void SpawnNewRoad()
    {
        int i = Random.Range(1, 5);//随机生成跑道

        roadNow = roadNext;
        roadNext = Game.Instance.Pool.Spawn("Pattern_"+i.ToString(),parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0, 0, 160);
        AddItem(roadNow);
        AddItem(roadNext);
    }


    //生成道路上的障碍物
    public void AddItem(GameObject obj)
    {
        var ItemChild = obj.transform.Find("Item");//放置物体的Item
        if(ItemChild!=null)
        {
            //取出一套方案生成物体到Item下
            var patternManager = PatternManager.Instance;
            if(patternManager!=null&&patternManager.Patterns!=null&&patternManager.Patterns.Count>0)
            {
                var pattern = patternManager.Patterns[Random.Range(0, patternManager.Patterns.Count)];
                if(pattern!=null&&pattern.PatterItems!=null&&pattern.PatterItems.Count>0)
                {
                    foreach(var item in pattern.PatterItems)
                    {
                        GameObject go = Game.Instance.Pool.Spawn(item.perfabName, ItemChild);
                        go.transform.SetParent(ItemChild);
                        go.transform.localPosition = item.pos;//设置其相对位置
                    }
                }
            }
        }
    }
}
