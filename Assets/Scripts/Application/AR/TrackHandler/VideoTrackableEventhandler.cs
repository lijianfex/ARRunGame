using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTrackableEventhandler : BaseTrackbleEventHandler {

    public VideoController Video;

    public string ClipName;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();        
        Game.Instance.Sound.PlayEffect(ClipName);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Video.Pause();
    }
}
