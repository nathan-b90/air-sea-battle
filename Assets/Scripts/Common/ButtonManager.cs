/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;
using Betari.AirSeaBattle.Scripts.Enums;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Betari.AirSeaBattle.Scripts.Utilities;
using JetBrains.Annotations;

namespace Betari.AirSeaBattle.Scripts.Common
{
    /// <summary>
    /// Script to play a button sound when pressed.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public sealed class ButtonManager : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Sound soundOnButtonDown;

        private Button button;

        void Awake()
        {
            button = GetComponent<Button>();

            if (!button)
                Debug.LogError("ButtonManager should be attached to a button!", this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (button.interactable)
            {
                AudioManager.Instance.PlayAudio(soundOnButtonDown);
            }
        }
    }
}