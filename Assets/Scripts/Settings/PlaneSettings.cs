/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Settings
{
    /// <summary>
    /// Settings for the planes in the game, accessible in game settings.
    /// </summary>
    [CreateAssetMenu(fileName = "PlaneSettings", menuName = "Settings/PlaneSettings", order = 2)]
    public sealed class PlaneSettings : ScriptableObject
    {
        [Tooltip("Minimum number of planes (configure before game)"), Range(1, 10)]
        public int minPlanes = 3;

        [Tooltip("Maximum number of planes (configure before game)"), Range(1, 10)]
        public int maxPlanes = 5;

        [Tooltip("Plane speed (can be adjusted during game)"), Range(0.1f, 10)]
        public float speed = 1.5f;
    }
}