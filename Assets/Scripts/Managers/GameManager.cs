/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using System.Collections;
using Betari.AirSeaBattle.Scripts.Common;
using Betari.AirSeaBattle.Scripts.Enums;
using Betari.AirSeaBattle.Scripts.Game;
using Betari.AirSeaBattle.Scripts.Settings;
using Betari.AirSeaBattle.Scripts.Utilities;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Managers
{
    /// <summary>
    /// Controller handling the main game loop.
    /// </summary>
    public sealed class GameManager : Manager<GameManager>
    {
        [SerializeField] private GameSettings gameSettings;

        #region Gameplay events

        public event GamePausedHandler OnGamePaused;
        public event GameResumedHandler OnGameResumed;
        public event GameOverHandler OnGameOver;
        public event PlaneDestroyedHandler OnPlaneDestroyed;
        public event TimeChangedHandler OnTimeChanged;

        #endregion

        private int score, time;

        /// <summary>
        /// Returns if the game is paused or not.
        /// </summary>
        public bool GamePaused { get; private set; }

        /// <summary>
        /// Returns if the game is over or not.
        /// </summary>
        public bool InputBlocked { get; private set; }

        public override void Awake()
        {
            base.Awake();

            time = gameSettings.time_limit;
            StartCoroutine(Timer());

            // Play the game's rocking tune.
            AudioManager.Instance.PlayAudio(Sound.ArcadeMusic);
            AudioManager.Instance.PlayAudio(Sound.VoiceStart);
        }

        IEnumerator Timer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                if (time <= 0)
                {
                    break;
                }

                time--;
                OnTimeChanged?.Invoke(time);
            }

            EndGame();
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void PauseGame()
        {
            GamePaused = true;
            OnGamePaused?.Invoke();
            Time.timeScale = 0f;
        }

        /// <summary>
        /// Resumes the paused game.
        /// </summary>
        public void ResumeGame()
        {
            GamePaused = false;
            OnGameResumed?.Invoke();
            Time.timeScale = 1f;
        }

        /// <summary>
        /// Adds score for a destroyed plane.
        /// </summary>
        public void PlaneDestroyed()
        {
            score += gameSettings.points_per_plane;
            OnPlaneDestroyed?.Invoke(score);
        }

        // Game ends when time has run out.
        void EndGame()
        {
            PlayerPrefs.SetInt(Constants.Keys.LAST_SCORE, score); // Set last score player pref to score achieved.

            if (score > gameSettings.default_high_score)
            {
                gameSettings.default_high_score = score;
            }

            AudioManager.Instance.PlayAudio(Sound.VoiceGameOver);

            InputBlocked = true;
            OnGameOver?.Invoke();
            Time.timeScale = 0f;
        }
    }
}