using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;

    public AudioSource musicSource, sfxSource;
    
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound should play here lol");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)

    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found 404");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
