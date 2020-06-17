/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using UnityEngine;
using System.Collections.Generic;
using Betari.AirSeaBattle.Scripts.Interfaces;

namespace Betari.AirSeaBattle.Scripts.Utilities
{
    /// <summary>
    /// Generic object pool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Pool<T> : Utility<Pool<T>> where T : MonoBehaviour
    {
        // The object that will be pooled, assign in editor
        [SerializeField] protected T prefab;

        [SerializeField] protected int quantity;

        protected Queue<T> queue;

        public override void Awake()
        {
            base.Awake();

            queue = new Queue<T>(quantity);

            for (var i = 0; i < quantity; i++)
            {
                var newObject = Instantiate(prefab, transform);
                newObject.gameObject.SetActive(false);
                queue.Enqueue(newObject);
                newObject.GetComponent<IPoolableEntity<T>>().SetSourcePool(this);
            }
        }

        /// <summary>
        /// Returns an object if there is one available.
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            if (queue.Count == 0)
                return null;

            var outObj = queue.Dequeue();
            outObj.gameObject.SetActive(true);
            return outObj;
        }

        /// <summary>
        /// Returns an inbound object to the pool.
        /// </summary>
        /// <param name="inObj"></param>
        public void Put(T inObj)
        {
            queue.Enqueue(inObj);
            inObj.transform.localPosition = Vector3.zero;
            inObj.transform.localRotation = Quaternion.identity;
            inObj.gameObject.SetActive(false);
        }
    }
}