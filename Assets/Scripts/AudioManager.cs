using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  
  [Header("------------ Audio Source --------------")]
  [SerializeField] private AudioSource musicSource;
  [SerializeField] private AudioSource sfxSource;

  [Header("---------- Audio Clip ----------------")]
  public AudioClip background;

  private void Start()
  {
    musicSource.clip = background;
    musicSource.Play();
  }
}
