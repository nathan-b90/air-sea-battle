/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Interfaces;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Managers
{
    /// <summary>
    /// Base class for controllers.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Manager<T> : MonoBehaviour, IManager where T : Manager<T>
    {
        public static T Instance;

        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}