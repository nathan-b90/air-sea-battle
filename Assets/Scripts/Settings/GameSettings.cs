/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Common;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Settings
{
    /// <summary>
    /// Main game settings.
    /// </summary>
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings", order = 0)]
    public sealed class GameSettings : ScriptableObject
    {
        // Main values that the game configuration is based on, hidden in editor
        [HideInInspector] public int default_high_score;
        [HideInInspector] public int points_per_plane;
        [HideInInspector] public int time_limit;

        /// <summary>
        /// Initialises default values for editor only (a build wouldn't need this).
        /// </summary>
        public void InitDefaults()
        {
            default_high_score = Constants.DefaultConfig.HIGHSCORE;
            points_per_plane = Constants.DefaultConfig.POINT_PER_PLANE;
            time_limit = Constants.DefaultConfig.TIME_LIMIT;
        }
    }
}