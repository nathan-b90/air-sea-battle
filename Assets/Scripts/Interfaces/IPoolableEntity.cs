/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;
using Betari.AirSeaBattle.Scripts.Utilities;

namespace Betari.AirSeaBattle.Scripts.Interfaces
{
    /// <summary>
    /// Interface for poolable objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPoolableEntity<T> where T : MonoBehaviour
    {
        void SetSourcePool(Pool<T> pool);
    }
}