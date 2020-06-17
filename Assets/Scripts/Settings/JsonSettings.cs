/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Settings
{
    /// <summary>
    /// Json config settings.
    /// </summary>
    [CreateAssetMenu(fileName = "JsonSettings", menuName = "Settings/JsonSettings", order = 1)]
    public sealed class JsonSettings : ScriptableObject
    {
        [Tooltip("The URL where the json config can be found")]
        public string endpointURL;

        [Tooltip("Max number of seconds to attempt to retrieve config before defaulting")]
        public float maxTimeout;
    }
}