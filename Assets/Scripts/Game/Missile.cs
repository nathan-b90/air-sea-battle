/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Common;
using Betari.AirSeaBattle.Scripts.Interfaces;
using Betari.AirSeaBattle.Scripts.Managers;
using Betari.AirSeaBattle.Scripts.Utilities;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Game
{
    /// <summary>
    /// Missile, a type of mover.
    /// </summary>
    public sealed class Missile : Mover, IPoolableEntity<Missile>
    {
        private Pool<Missile> pool;

        /// <summary>
        /// Sets missile pool so missile can return.
        /// </summary>
        /// <param name="pool"></param>
        public void SetSourcePool(Pool<Missile> pool)
        {
            this.pool = pool;
        }

        void Awake()
        {
            SetLeftScreenCallback(ReturnToPool);
            SetCollidedCallback(MissileCollision);
        }

        /// <summary>
        /// When mover detects collision, damage plane and return to pool.
        /// </summary>
        /// <param name="collider"></param>
        void MissileCollision(Collider collider)
        {
            if (collider.CompareTag(Constants.Tags.PLANE))
            {
                collider.GetComponent<Plane>().MissileHit();
                ReturnToPool();
            }
        }

        /// <summary>
        /// Returns missile to pool when mover has left screen area.
        /// </summary>
        void ReturnToPool()
        {
            pool.Put(this);
        }
    }
}