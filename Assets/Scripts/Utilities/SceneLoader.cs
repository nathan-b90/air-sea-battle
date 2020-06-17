/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using System.Collections;
using Betari.AirSeaBattle.Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Betari.AirSeaBattle.Scripts.Utilities
{
    /// <summary>
    /// Handles the loading of scenes.
    /// </summary>
    public class SceneLoader : Utility<SceneLoader>
    {
        [SerializeField] private Camera loadCamera;
        [SerializeField] private Canvas loadCanvas;

        private GameScene[] toScenes;

        /// <summary>
        /// Loads array of scenes, first being active, others additive.
        /// </summary>
        /// <param name="toScenes"></param>
        public void LoadScenes(GameScene[] toScenes)
        {
            this.toScenes = toScenes;

            ToggleLoadScreen(true);
            StartCoroutine(SceneTransitionCoroutine());
        }

        // Loads each scene in turn and then hides load screen.
        IEnumerator SceneTransitionCoroutine()
        {
            yield return new WaitForSecondsRealtime(0.5f);

            for (int i = 0; i < toScenes.Length; i++)
            {
                LoadSceneMode mode = i == 0 ? LoadSceneMode.Single : LoadSceneMode.Additive; // First scene active
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(toScenes[i].ToString(), mode);

                yield return new WaitUntil(() => loadOperation.isDone);
            }

            ToggleLoadScreen(false);
        }

        // Shows/hides black loading screen.
        void ToggleLoadScreen(bool enabled)
        {
            loadCamera.gameObject.SetActive(enabled);
            loadCanvas.gameObject.SetActive(enabled);
        }
    }
}