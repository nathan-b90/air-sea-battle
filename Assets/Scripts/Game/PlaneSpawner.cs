/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using System.Collections.Generic;
using UnityEngine;
using Betari.AirSeaBattle.Scripts.Common;
using Betari.AirSeaBattle.Scripts.Extensions;
using Betari.AirSeaBattle.Scripts.Settings;
using Betari.AirSeaBattle.Scripts.Utilities;

namespace Betari.AirSeaBattle.Scripts.Game
{
    /// <summary>
    /// Plane spawner, a type of mover. Responsible for creating plane waves.
    /// </summary>
    public sealed class PlaneSpawner : Mover
    {
        [SerializeField] private PlaneSettings planeSettings;
        [SerializeField] private Plane planePrefab;

        private readonly List<Plane> planes = new List<Plane>();
        private Vector3 origin;
        private int minPlanes, maxPlanes, planeCount;

        void Awake()
        {
            minPlanes = planeSettings.minPlanes;
            maxPlanes = planeSettings.maxPlanes;

            if (minPlanes > maxPlanes)
                Debug.LogError($"Min planes {minPlanes} cannot be more than max {maxPlanes}");

            origin = new Vector3(ScreenBounds.Instance.GetLeft(), 0);
            SetLeftScreenCallback(ResetOrigin); // set the mover left screen callback

            CreatePlanes();
            StartWave();
        }

        // Set up planes depending on max plane number.
        void CreatePlanes()
        {
            float planeArea = maxPlanes > 5 ? Constants.Layout.PLANE_MAX_AREA : Constants.Layout.PLANE_OPTIMAL_AREA;

            for (int i = 0; i < maxPlanes; i++)
            {
                Vector3 pos = new Vector3(0, Constants.Layout.PLANE_TOP_BOUNDARY - (planeArea / (maxPlanes - 1) * i));
                Plane plane = Instantiate(planePrefab, pos, Quaternion.identity, transform);
                plane.SetDestroyCallback(PlaneDestroyed);
                plane.gameObject.SetActive(false);
                planes.Add(plane);
            }
        }

        // Prepares a random configuration of planes and begins moving.
        void StartWave()
        {
            planeCount = Random.Range(minPlanes, maxPlanes + 1);
            planes.Shuffle();

            for (int i = 0; i < planeCount; i++)
            {
                planes[i].gameObject.SetActive(true);
            }

            ResetOrigin();
        }

        void Update()
        {
            speed = planeSettings.speed; // adjust speed if changed in settings during play
        }

        // Called on plane destruction, check if new wave is needed
        void PlaneDestroyed()
        {
            if (--planeCount == 0)
            {
                StartWave();
            }
        }

        // Moves spawner back to left of screen when mover has left screen area.
        void ResetOrigin()
        {
            transform.position = origin;
        }
    }
}