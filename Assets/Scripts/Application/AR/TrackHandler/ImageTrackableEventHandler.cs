using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTrackableEventHandler : BaseTrackbleEventHandler
{
    public GameObject ModlePrefab; //模型预制

    public GameObject EffectPrefab; //特效预制

    public string clipName = "AR";

    private GameObject modle;
    private GameObject effect;



    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        InstantiateModle();
        InstantiateEffect();
        Game.Instance.Sound.PlayEffect(clipName);
    }


    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        DestroyImmediate(modle);
        
    }

    private void InstantiateModle()
    {
        if(ModlePrefab!=null)
        {
            modle = GameObject.Instantiate(ModlePrefab, transform.localPosition, transform.localRotation);
            modle.transform.SetParent(this.transform);
        }

    }

    private void InstantiateEffect()
    {
        if(EffectPrefab!=null)
        {
            effect = GameObject.Instantiate(EffectPrefab, transform.localPosition, transform.localRotation);
        }
        Destroy(effect, 3f);
    }

}
