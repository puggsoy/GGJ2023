using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource MusicSource;
    public AudioSource EffectsSource;
   
    public AudioClip GameMusic;

    public static SoundManager Instance = null;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        SoundManager.Instance.PlayMusic(GameMusic);
    }

    public void Play(AudioClip clip, float volume)
    {
        EffectsSource.clip = clip;
        EffectsSource.PlayOneShot(clip, volume);
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void RandomSoundEffect(float volume, params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.PlayOneShot(EffectsSource.clip, volume);
    }
}
