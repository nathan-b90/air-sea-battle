/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using System;
using Betari.AirSeaBattle.Scripts.Common;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Game
{
    /// <summary>
    /// Base mover class to control movement and collisions.
    /// </summary>
    public abstract class Mover : MonoBehaviour
    {
        /// <summary>
        /// The speed of the mover.
        /// </summary>
        [SerializeField] protected float speed;

        protected Vector3 dir = Vector3.right; // all movers move right by default.

        protected event Action OnLeftScreen;
        protected event Action<Collider> OnCollided;

        /// <summary>
        /// Determines direction, from default vector around z axis.
        /// </summary>
        /// <param name="angle"></param>
        public void RotateBy(float angle)
        {
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            var right = Vector3.right;
            dir = rotation * right;
        }

        protected void FixedUpdate()
        {
            transform.Translate(dir * speed * Time.deltaTime, Space.Self);
        }

        /// <summary>
        /// Set callback for when the mover leaves the screen.
        /// </summary>
        /// <param name="callback"></param>
        protected void SetLeftScreenCallback(Action callback)
        {
            OnLeftScreen += callback;
        }

        /// <summary>
        /// Set callback for when the mover collides with something.
        /// </summary>
        /// <param name="callback"></param>
        protected void SetCollidedCallback(Action<Collider> callback)
        {
            OnCollided += callback;
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Constants.Tags.SCREEN_AREA))
            {
                OnLeftScreen?.Invoke();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            OnCollided?.Invoke(other);
        }
    }
}