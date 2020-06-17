/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using System;
using System.Linq;
using Betari.AirSeaBattle.Scripts.Enums;
using Betari.AirSeaBattle.Scripts.Settings;
using UnityEngine;
using UnityEngine.Audio;

namespace Betari.AirSeaBattle.Scripts.Utilities
{
    /// <summary>
    /// Class that handles the loading and playing of game audio.
    /// </summary>
    public sealed class AudioManager : Utility<AudioManager>
    {
        [SerializeField] private SoundSettings[] sounds;
        [SerializeField] private AudioMixerGroup soundMixerGroup;
        [SerializeField] private AudioSource musicSource; // Existing music source which plays one track at a time.

        public override void Awake()
        {
            base.Awake();
            InitialiseGameAudio();
        }

        // Creates a unique AudioSource for each sound to allow for overlapping fx.
        void InitialiseGameAudio()
        {
            if (musicSource == null)
                Debug.LogError($"Music source must be set up in inspector!");

            var soundFX = sounds
                .Select(sound => sound)
                .Where(sound => !sound.isMusic)
                .ToList();

            foreach (SoundSettings sound in soundFX)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.outputAudioMixerGroup = soundMixerGroup;
                sound.source.volume = sound.volume;
            }
        }

        /// <summary>
        /// Plays an audio clip from id, if it exists.
        /// </summary>
        /// <param name="soundClip"></param>
        public void PlayAudio(Sound soundClip)
        {
            SoundSettings sound = Array.Find(sounds, t => t.id == soundClip);

            if (sound == null)
                Debug.LogError($"Sound {sound} not found!");

            if (sound.isMusic)
            {
                musicSource.Stop();
                musicSource.clip = sound.clip;
                musicSource.volume = sound.volume;
                musicSource.Play();
            }
            else
            {
                sound.source.Play();
            }
        }
    }
}