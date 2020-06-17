/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Utilities
{
    /// <summary>
    /// Object that provides the screen boundaries in world units.
    /// </summary>
    public sealed class ScreenBounds : Utility<ScreenBounds>
    {
        private Camera rootCamera;
        private Bounds bounds;
        private float left, right, top, bottom;

        public override void Awake()
        {
            base.Awake();

            rootCamera = Camera.main;
            CalculateBoundsOnAwake();
        }

        // Calculates bounds according to the screen height and aspect ratio.
        void CalculateBoundsOnAwake()
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            float cameraHeight = rootCamera.orthographicSize * 2;
            bounds = new Bounds(rootCamera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

            left = bounds.min.x;
            right = bounds.max.x;
            top = bounds.max.y;
            bottom = bounds.min.y;
        }

        #region screen bound get functions

        /// <summary>
        /// Returns left of screen in world units.
        /// </summary>
        /// <returns></returns>
        public float GetLeft()
        {
            return left;
        }

        /// <summary>
        /// Returns right of screen in world units.
        /// </summary>
        /// <returns></returns>
        public float GetRight()
        {
            return right;
        }

        /// <summary>
        /// Returns top of screen in world units.
        /// </summary>
        /// <returns></returns>
        public float GetTop()
        {
            return top;
        }

        /// <summary>
        /// Returns bottom of screen in world units.
        /// </summary>
        /// <returns></returns>
        public float GetBottom()
        {
            return bottom;
        }

        /// <summary>
        /// Returns screen width in world units.
        /// </summary>
        /// <returns></returns>
        public float GetWidth()
        {
            return Mathf.Abs(left) + Mathf.Abs(right);
        }

        /// <summary>
        /// Returns screen height in world units.
        /// </summary>
        /// <returns></returns>
        public float GetHeight()
        {
            return Mathf.Abs(top) + Mathf.Abs(bottom);
        }

        /// <summary>
        /// Returns player start position.
        /// </summary>
        /// <returns></returns>
        public float GetPlayerStartPosition()
        {
            return -(GetWidth() / 4);
        }

        #endregion
    }
}