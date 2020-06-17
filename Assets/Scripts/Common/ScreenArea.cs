/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;
using Betari.AirSeaBattle.Scripts.Utilities;

namespace Betari.AirSeaBattle.Scripts.Common
{
    /// <summary>
    /// Script to resize the screen area collision box.
    /// </summary>
    public sealed class ScreenArea : MonoBehaviour
    {
        void Awake()
        {
            gameObject.transform.localScale = new Vector3(ScreenBounds.Instance.GetWidth(), ScreenBounds.Instance.GetHeight(), 1);
        }
    }
}
