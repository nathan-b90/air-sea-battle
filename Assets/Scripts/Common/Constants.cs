/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

namespace Betari.AirSeaBattle.Scripts.Common
{
    /// <summary>
    /// Static game constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Default values for game config.
        /// </summary>
        public static class DefaultConfig
        {
            public const int HIGHSCORE = 100;
            public const int POINT_PER_PLANE = 1;
            public const int TIME_LIMIT = 30;
        }

        /// <summary>
        /// Constants for game setup and control.
        /// </summary>
        public static class GameSetup
        {
            public const float ANGLE_UP = 90f;
            public const float ANGLE_CENTRE = 60f;
            public const float ANGLE_DOWN = 30f;
        }

        /// <summary>
        /// Keys used for player prefs.
        /// </summary>
        public static class Keys
        {
            public const string LAST_SCORE = "LastScore";
        }

        /// <summary>
        /// Tags used for collision.
        /// </summary>
        public static class Tags
        {
            public const string SCREEN_AREA = "ScreenArea";
            public const string PLANE = "Plane";
        }

        /// <summary>
        /// World space helpers for game screen.
        /// </summary>
        public static class Layout
        {
            public const float PLAYER_Y_POSITION = -3.5f;
            public const float PLANE_TOP_BOUNDARY = 3f;
            public const float PLANE_OPTIMAL_AREA = 3f;
            public const float PLANE_MAX_AREA = 5f;
        }
    }
}