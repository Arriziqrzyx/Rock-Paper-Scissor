using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSlider : SliderSettings
{

  private AudioManager audioManager
  {
    get
    {
      return GameSystem.Instance.audioManager;
    }
  }

  void Start()
  {
    SyncSlider();
  }

  public void SetVolume(float value)
  {
    audioManager.musicVolume = value;
    SyncSlider();
  }

  private void SyncSlider()
  {
    slider.value = audioManager.musicVolume;
  }

}
