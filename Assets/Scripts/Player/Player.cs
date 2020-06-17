/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Common;
using Betari.AirSeaBattle.Scripts.Enums;
using Betari.AirSeaBattle.Scripts.Game;
using Betari.AirSeaBattle.Scripts.Utilities;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Player
{
    /// <summary>
    /// Controls the player and shooting.
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public sealed class Player : MonoBehaviour
    {
        private PlayerInput input;
        private float shootAngle;

        void Awake()
        {
            input = GetComponent<PlayerInput>();
            SetPlayerStartPos();

            input.OnAim += SetAimDirection;
            input.OnFirePress += FireMissile;

            SetAimDirection(AimDirection.Centre); // Begin by aiming centre
        }

        void SetPlayerStartPos()
        {
            float xPos = ScreenBounds.Instance.GetPlayerStartPosition();
            transform.localPosition = new Vector3(xPos, Constants.Layout.PLAYER_Y_POSITION, 0);
        }

        // Changes shooting angle when detecting a change in aim direction.
        void SetAimDirection(AimDirection dir)
        {
            switch (dir)
            {
                case AimDirection.Up:
                    shootAngle = Constants.GameSetup.ANGLE_UP;
                    break;
                case AimDirection.Centre:
                    shootAngle = Constants.GameSetup.ANGLE_CENTRE;
                    break;
                case AimDirection.Down:
                    shootAngle = Constants.GameSetup.ANGLE_DOWN;
                    break;
            }
        }

        // Fires missile if one is available.
        void FireMissile()
        {
            Missile missile = MissilePool.Instance.Get();

            if (!missile)
                return;

            missile.transform.position = transform.position;
            missile.RotateBy(shootAngle);
            missile.gameObject.SetActive(true);
            AudioManager.Instance.PlayAudio(Sound.Shot);
        }
    }
}