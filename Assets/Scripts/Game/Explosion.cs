/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Interfaces;
using Betari.AirSeaBattle.Scripts.Utilities;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Game
{
    /// <summary>
    /// A poolable explosion object.
    /// </summary>
    [RequireComponent(typeof(ParticleSystem))]
    public sealed class Explosion : MonoBehaviour, IPoolableEntity<Explosion>
    {
        private ParticleSystem particles;
        private Pool<Explosion> pool;

        public void SetSourcePool(Pool<Explosion> pool)
        {
            this.pool = pool;
        }

        void Awake()
        {
            particles = GetComponent<ParticleSystem>();
        }

        void OnEnable()
        {
            // Play when game object is enabled.
            particles.Play();
        }

        void Update()
        {
            // Return particles to pool when effect has finished.
            if (!particles.isEmitting)
            {
                pool.Put(this);
            }
        }
    }
}