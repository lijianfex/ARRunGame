using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceTrackableEventHandler : BaseTrackbleEventHandler {

    public GameObject ModlePrefab; //模型预制

    public GameObject EffectPrefab; //特效预制

    public GameObject UIEffectPrefab;//UI特效预制

    public string clipName = "AR";

    private GameObject modle;
    private GameObject effect;
    private GameObject uieffect;



    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        InstantiateModle();
        InstantiateEffect();
        InstantiateUIEffect();
        Game.Instance.Sound.PlayEffect(clipName);
    }


    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        DestroyImmediate(modle);
        DestroyImmediate(effect);
        DestroyImmediate(uieffect);

    }

    private void InstantiateModle()
    {
        if (ModlePrefab != null)
        {
            modle = GameObject.Instantiate(ModlePrefab, transform.localPosition, transform.localRotation);
            modle.transform.SetParent(this.transform);
        }

    }

    private void InstantiateEffect()
    {
        if (EffectPrefab != null)
        {
            effect = GameObject.Instantiate(EffectPrefab, transform.localPosition, transform.localRotation);
            effect.transform.SetParent(this.transform);
        }        
    }

    private void InstantiateUIEffect()
    {
        if (UIEffectPrefab != null)
        {
            uieffect = GameObject.Instantiate(UIEffectPrefab, transform.localPosition, transform.localRotation);
            uieffect.transform.SetParent(this.transform);
        }        
    }


}
