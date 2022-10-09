using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public AudioSource musicSource;
  public AudioSource soundSource;

  public bool isMute
  {
    get
    {
      int pref = PlayerPrefs.GetInt("mute", 0);
      return pref == 1 ? true : false;
    }
    set
    {
      if (musicSource != null) musicSource.mute = value;
      if (soundSource != null) soundSource.mute = value;
      PlayerPrefs.SetInt("mute", value ? 1 : 0);
    }
  }

  public float musicVolume
  {
    get
    {
      if (musicSource)
      {
        return musicSource.volume;
      }

      return PlayerPrefs.GetFloat("musicVolume", 1f);
    }

    set
    {
      if (musicSource != null) musicSource.volume = value;
      PlayerPrefs.SetFloat("musicVolume", value);
    }
  }

  void Awake()
  {
    int mutePref = PlayerPrefs.GetInt("mute", 0);
    isMute = mutePref == 1 ? true : false;

    float musicVolumePref = PlayerPrefs.GetFloat("musicVolume", 1f);
    musicVolume = musicVolumePref;
  }
}
