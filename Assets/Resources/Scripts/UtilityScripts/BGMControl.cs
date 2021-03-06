﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMControl : MonoBehaviour
{
    private AudioSource audioSrc;

    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void ChangeVolume(float V)
    {
        musicVolume = V;
    }
}
