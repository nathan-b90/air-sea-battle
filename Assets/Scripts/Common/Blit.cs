/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Common
{
    /// <summary>
    /// Camera effect.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    [ExecuteInEditMode]
    public class Blit : MonoBehaviour
    {
        public Material screenMaterial;

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, screenMaterial);
        }
    }
}