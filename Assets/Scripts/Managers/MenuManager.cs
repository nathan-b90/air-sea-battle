/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Utilities;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Betari.AirSeaBattle.Scripts.Enums;
using Betari.AirSeaBattle.Scripts.Common;
using Betari.AirSeaBattle.Scripts.Settings;

namespace Betari.AirSeaBattle.Scripts.Managers
{
    /// <summary>
    /// Controller handling main menu functionality and interaction.
    /// </summary>
    public class MenuManager : Manager<MenuManager>
    {
        [SerializeField] private GameSettings gameSettings;

        // High score elements
        [SerializeField] private TextMeshProUGUI highscoreDisplay;

        // Last score elements
        [SerializeField] private GameObject lastScore;
        [SerializeField] private TextMeshProUGUI lastScoreDisplay;

        public override void Awake()
        {
            base.Awake();
            InitialiseMenu();
        }

        void InitialiseMenu()
        {
            Time.timeScale = 1f;
            AudioManager.Instance.PlayAudio(Sound.PatrioticMusic);

            // Update main menu scores on scene awake
            highscoreDisplay.text = gameSettings.default_high_score.ToString();

            // Show last score if one has been achieved this session
            if (PlayerPrefs.HasKey(Constants.Keys.LAST_SCORE))
            {
                ShowLastScore();
            }
        }

        void ShowLastScore()
        {
            lastScoreDisplay.text = PlayerPrefs.GetInt(Constants.Keys.LAST_SCORE, 0).ToString();
            lastScore.SetActive(true);
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        [UsedImplicitly] // by the play button.
        public void StartGame()
        {
            SceneLoader.Instance.LoadScenes(new[] { GameScene.Game, GameScene.UI });
        }
    }
}