﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class sound  {

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
}