/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;
using Betari.AirSeaBattle.Scripts.Settings;
using UnityEngine.Networking;
using System.Collections;

namespace Betari.AirSeaBattle.Scripts.Common
{
    /// <summary>
    /// Class that retrieves the game configuration or sets a default one.
    /// </summary>
    public sealed class ConfigureGame : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private JsonSettings dataSettings;

        private UnityWebRequest webRequest; // Reusable web request object.
        private float timeout;

        void Awake()
        {
#if UNITY_EDITOR
            gameSettings.InitDefaults();
#endif
            ClearLastScore(); // Delete the last score pref if it exists.
            RetrieveConfig();
        }

        void ClearLastScore()
        {
            PlayerPrefs.DeleteKey(Constants.Keys.LAST_SCORE);
        }

        void RetrieveConfig()
        {
            timeout = dataSettings.maxTimeout;
            StartCoroutine(RetrieveConfigCoroutine());
        }

        // Attempts to retrieve JSON from endpoint before timeout.
        IEnumerator RetrieveConfigCoroutine()
        {
            while (timeout > 0)
            {
                webRequest = UnityWebRequest.Get(dataSettings.endpointURL);
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError || webRequest.isHttpError)
                {
                    Debug.LogWarning(webRequest.error);
                }
                else
                {
                    JsonUtility.FromJsonOverwrite(webRequest.downloadHandler.text, gameSettings);
                    yield break;
                }

                timeout -= Time.deltaTime;
            }

            yield break;
        }
    }
}