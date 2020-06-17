/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using System.Collections;
using Betari.AirSeaBattle.Scripts.Enums;
using Betari.AirSeaBattle.Scripts.Settings;
using Betari.AirSeaBattle.Scripts.Utilities;
using TMPro;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Common
{
    /// <summary>
    /// Class for the intro loading animation.
    /// </summary>
    public sealed class LoadingConsole : MonoBehaviour
    {
        [SerializeField] private JsonSettings jsonSettings;
        [SerializeField] private GameObject title;
        [SerializeField] private GameObject subtitle;
        [SerializeField] private TextMeshProUGUI inputDisplay;

        private readonly string systemReadyText = "SYSTEM READY... \n\n\n";
        private readonly string typedCommandText = "* load air sea battle";

        void Awake()
        {
            StartCoroutine(FauxLoadCoroutine());
        }

        // Coroutine controlling loading console text.
        IEnumerator FauxLoadCoroutine()
        {
            title.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            subtitle.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            inputDisplay.text += systemReadyText;
            yield return new WaitForSeconds(0.5f);

            int i = 0;
            AudioManager.Instance.PlayAudio(Sound.Keyboard);

            // Type the faux load command.
            while (i < typedCommandText.Length)
            {
                yield return new WaitForSeconds(0.125f);
                inputDisplay.text += typedCommandText.Substring(i, 1);
                i++;
            }

            // Wait until max timeout for json retriever is over.
            yield return new WaitUntil(() => Time.realtimeSinceStartup > jsonSettings.maxTimeout);

            SceneLoader.Instance.LoadScenes(new[] { GameScene.MainMenu });
        }
    }
}