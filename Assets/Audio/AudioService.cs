using UnityEngine;
using System;
public class AudioService : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;

    public AudioSource musicSource, sfxSource;
    
    private void Start()
    {
        GameManager.Instance.EventService.InvokeOnAmbientAudioPlay(musicSounds[0].name);
    }
    
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
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }
}
