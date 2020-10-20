using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    //背景播放器
    private AudioSource m_Bg;

    //音效播放器
    private AudioSource m_Effect;

    //资源路径
    public string ResourcesSoundPath = "";

    //资源缓存字典
    Dictionary<string, AudioClip> m_BgClips = new Dictionary<string, AudioClip>();
    Dictionary<string, AudioClip> m_EffectClips = new Dictionary<string, AudioClip>();



    protected override void Awake()
    {
        base.Awake();
        m_Bg = gameObject.AddComponent<AudioSource>();
        m_Bg.playOnAwake = false;
        m_Bg.loop = true;

        m_Effect = gameObject.AddComponent<AudioSource>();
        
    }

    //切换播放背景音
    public void PlayBG(string clipName)
    {
        GameModel gm = MVC.GetModle<GameModel>();
        if(!gm.IsBgmPlay)
        {
            return;
        }
        string oldName;
        if (m_Bg.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = m_Bg.clip.name;
        }

        if (oldName != clipName)
        {
            AudioClip clip = null;
            if (!m_BgClips.ContainsKey(clipName))
            {
                string path = ResourcesSoundPath + "/" + clipName;

                clip = Resources.Load<AudioClip>(path);

                m_BgClips.Add(clipName, clip);
            }
            clip = m_BgClips[clipName];

            if (clip != null)
            {
                m_Bg.clip = clip;
                m_Bg.Play();
            }
        }
        PlayBGM();
        
    }

    //播放音效
    public void PlayEffect(string clipName)
    {
        AudioClip clip = null;
        if (!m_EffectClips.ContainsKey(clipName))
        {
            string path = ResourcesSoundPath + "/" + clipName;

            clip = Resources.Load<AudioClip>(path);

            m_EffectClips.Add(clipName, clip);
        }
        clip = m_EffectClips[clipName];

        if (clip != null)
        {
            m_Effect.PlayOneShot(clip);
        }
    }

    //播放背景音
    public void PlayBGM()
    {
        GameModel gm = MVC.GetModle<GameModel>();
        m_Bg.UnPause();
        gm.IsBgmPlay = true;
    }

    //暂停背景音
    public void PauseBGM()
    {
        GameModel gm = MVC.GetModle<GameModel>();
        m_Bg.Pause();
        gm.IsBgmPlay = false;
    }

    

}
