using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{


    private VideoPlayer videoPlayer;

    public Button m_PlayButton;
    public RectTransform m_ProgressBar;

    public ARImageUI imageUI;

    private float videoTime = 29f;




    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        

    }

    void Update()
    {

        if (videoPlayer.isPlaying)
        {
            ShowPlayButton(false);

            if (videoPlayer.frameCount < float.MaxValue)
            {
                float frame = (float)videoPlayer.frame;
                float count = (float)videoPlayer.frameCount;

                float progressPercentage = 0;

                if (count > 0)
                    progressPercentage = (frame / count) * 100.0f;

                if (m_ProgressBar != null)
                    m_ProgressBar.sizeDelta = new Vector2((float)progressPercentage, m_ProgressBar.sizeDelta.y);

                


            }

            videoTime -= Time.deltaTime;
            if (videoTime <= 0.01f)
            {
                imageUI.VideoPlayEnd();
                videoTime = 29f;
            }

        }
        else
        {
            ShowPlayButton(true);
        }


        
    }



    /// <summary>
    /// 播放按钮事件
    /// </summary>
    public void Play()
    {

        PauseAudio(false);
        videoPlayer.Play();
        ShowPlayButton(false);
    }


    /// <summary>
    /// 暂停按钮事件
    /// </summary>
    public void Pause()
    {
        if (videoPlayer)
        {
            PauseAudio(true);
            videoPlayer.Pause();
            ShowPlayButton(true);
        }
    }

    /// <summary>
    /// 暂停音频
    /// </summary>
    /// <param name="pause"></param>
    private void PauseAudio(bool pause)
    {
        for (ushort trackNumber = 0; trackNumber < videoPlayer.audioTrackCount; ++trackNumber)
        {
            if (pause)
                videoPlayer.GetTargetAudioSource(trackNumber).Pause();
            else
                videoPlayer.GetTargetAudioSource(trackNumber).UnPause();
        }
    }

    /// <summary>
    /// 显示/隐藏 播放图片按钮
    /// </summary>
    /// <param name="enable"></param>
    private void ShowPlayButton(bool enable)
    {
        m_PlayButton.enabled = enable;
        m_PlayButton.GetComponent<Image>().enabled = enable;
    }



}
