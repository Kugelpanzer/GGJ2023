using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

using Random = UnityEngine.Random;
public class AudioManager : MonoBehaviour
{
    //   public Slider sl;
    public Sound[] sounds;
    public static AudioManager instance;
    bool mainFlag = true;



    // Start is called before the first frame update
    public void SetAllVolume()
    {
        /*foreach (Sound s in sounds)
        {
            // s.volume = PlayerPrefs.GetFloat("SoundVolume", 1f);
            if (s.type == Music.sound)
            {
                s.source.volume = PlayerPrefs.GetFloat("SoundVolume", 1f) * s.volume;
            }
            else if (s.type == Music.effects)
            {
                s.source.volume = PlayerPrefs.GetFloat("EffectVolume", 1f) * s.volume;
            }
        }*/
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = PlayerPrefs.GetFloat("SoundVolume", 1f) * s.volume;
            s.source.pitch = 1f;
            s.source.loop = s.loop;
        }

    }
    void Start()
    {
        //audio = GameObject.Find("MusicController").GetComponent<AudioMenager>(); //ŽEX
        // rand = Random.Range(200, 600);

        SetAllVolume();
        if (mainFlag)
        {
            Debug.Log("SADA start");
            PlaySound("main");
            mainFlag = false;
        }
    }


    public void PlaySound(string name)
    {
        Sound currSound = Array.Find(sounds, sound => sound.name == name);
        currSound.source.Play();
    }
    // Update is called once per frame
    void Update()
    {
    }
}