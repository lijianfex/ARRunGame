using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimChange : MonoBehaviour
{

    Animation anim;

    public List<string> animNameList;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    public void ChangAnim()
    {
        if (animNameList != null)
        {
            int index = Random.Range(0, animNameList.Count);
            anim.Play(animNameList[index]);
        }
    }

}
