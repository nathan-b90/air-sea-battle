/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;
using System;
using Betari.AirSeaBattle.Scripts.Enums;

namespace Betari.AirSeaBattle.Scripts.Settings
{
    /// <summary>
    /// Settings for a game sound.
    /// </summary>
    [Serializable]
    public sealed class SoundSettings
    {
        [Tooltip("The sound identifier")]
        public Sound id;

        [Tooltip("Sound clip")]
        public AudioClip clip;

        [Tooltip("Source that plays clip"), HideInInspector]
        public AudioSource source;

        [Tooltip("Volume of the sound"), Range(0.1f, 3f)]
        public float volume = 1f;

        [Tooltip("Is the sound looping music?")]
        public bool isMusic;
    }
}