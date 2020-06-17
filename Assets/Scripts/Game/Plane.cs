using System;
using Betari.AirSeaBattle.Scripts.Enums;
using Betari.AirSeaBattle.Scripts.Managers;
using Betari.AirSeaBattle.Scripts.Utilities;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Game
{
    /// <summary>
    /// A plane object, handles hit from missile.
    /// </summary>
    public sealed class Plane : MonoBehaviour
    {
        private event Action OnDestroyed;

        /// <summary>
        /// Set callback when plane has been destroyed.
        /// </summary>
        /// <param name="callback"></param>
        public void SetDestroyCallback(Action callback)
        {
            OnDestroyed += callback;
        }

        /// <summary>
        /// Called by the colliding missile.
        /// </summary>
        public void MissileHit()
        {
            // Get explosion prefab and then "destroy" self
            Explosion explosion = ExplosionPool.Instance.Get();

            if (!explosion)
                return;

            explosion.transform.position = transform.position;
            explosion.gameObject.SetActive(true);
            Destroy();
        }

        void Destroy()
        {
            gameObject.SetActive(false);
            AudioManager.Instance.PlayAudio(Sound.Boom);
            GameManager.Instance.PlaneDestroyed();
            OnDestroyed?.Invoke();
        }
    }
}