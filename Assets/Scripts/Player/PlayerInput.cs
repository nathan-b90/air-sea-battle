/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using System;
using Betari.AirSeaBattle.Scripts.Managers;
using Betari.AirSeaBattle.Scripts.Enums;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Player
{
    /// <summary>
    /// Listens for and handles player input.
    /// </summary>
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField, Tooltip("Seconds between when shots are allowed")]
        private float fireRate = 0.25f;

        // Input actions to be listened to.
        public event Action<AimDirection> OnAim;
        public event Action OnFirePress;

        private float fireTimer;
        private AimDirection aimDir;

        void Awake()
        {
            aimDir = AimDirection.Centre;
        }

        void Update()
        {
            // If game over, don't check for key input
            if (GameManager.Instance.InputBlocked)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return)) // Check for pause input.
            {
                if (!GameManager.Instance.GamePaused)
                {
                    GameManager.Instance.PauseGame();
                }
                else
                {
                    GameManager.Instance.ResumeGame();
                }
            }

            // Check for player input if game is not paused
            if (!GameManager.Instance.GamePaused)
            {
                CheckLeftRightInput();
                CheckFireInput();
            }
        }

        void CheckLeftRightInput()
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                SetAim(AimDirection.Up);
                return;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                SetAim(AimDirection.Down);
                return;
            }

            SetAim(AimDirection.Centre);
        }

        // Set aim direction if not already aiming in that direction.
        void SetAim(AimDirection dir)
        {
            if (dir == AimDirection.Up && aimDir != AimDirection.Up)
            {
                OnAim?.Invoke(AimDirection.Up);
            }
            else if (dir == AimDirection.Centre && aimDir != AimDirection.Centre)
            {
                OnAim?.Invoke(AimDirection.Centre);
            }
            else if (dir == AimDirection.Down && aimDir != AimDirection.Down)
            {
                OnAim?.Invoke(AimDirection.Down);
            }

            aimDir = dir;
        }

        void CheckFireInput()
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireRate)  // fire missile if timer is over fireRate.
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    OnFirePress?.Invoke();
                    fireTimer = 0;
                }
            }
        }
    }
}