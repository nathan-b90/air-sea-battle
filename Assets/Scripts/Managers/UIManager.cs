/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Enums;
using Betari.AirSeaBattle.Scripts.Settings;
using Betari.AirSeaBattle.Scripts.Utilities;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Managers
{
    /// <summary>
    /// Controller handling game UI.
    /// </summary>
    public class UIManager : Manager<UIManager>
    {
        [SerializeField] private GameSettings gameSettings;

        // Top UI
        [SerializeField] private TextMeshProUGUI scoreDisplay;
        [SerializeField] private TextMeshProUGUI timeDisplay;
        [SerializeField] private TextMeshProUGUI highscoreDisplay;

        // Screen overlays
        [SerializeField] private GameObject pauseScreen;
        [SerializeField] private GameObject gameOverScreen;

        public override void Awake()
        {
            base.Awake();

            // Set UI on game start
            UpdateScore(0);
            UpdateTime(gameSettings.time_limit);
            highscoreDisplay.text = gameSettings.default_high_score.ToString();

            // Delegate listeners to update score/time
            GameManager.Instance.OnPlaneDestroyed += UpdateScore;
            GameManager.Instance.OnTimeChanged += UpdateTime;

            // Delegate listeners for main game loop
            GameManager.Instance.OnGamePaused += PauseGame;
            GameManager.Instance.OnGameResumed += ResumeGame;
            GameManager.Instance.OnGameOver += GameOver;
        }

        #region update UI methods

        void UpdateScore(int score)
        {
            scoreDisplay.text = score.ToString();
        }

        void UpdateTime(int time)
        {
            timeDisplay.text = time.ToString();
        }

        #endregion
        #region game loop methods

        void PauseGame()
        {
            pauseScreen.SetActive(true);
        }

        void ResumeGame()
        {
            pauseScreen.SetActive(false);
        }

        void GameOver()
        {
            gameOverScreen.SetActive(true);
        }

        #endregion

        /// <summary>
        /// Exits game back to menu.
        /// </summary>
        [UsedImplicitly] // by the exit button.
        public void ExitGame()
        {
            SceneLoader.Instance.LoadScenes(new[] { GameScene.MainMenu });
        }
    }
}