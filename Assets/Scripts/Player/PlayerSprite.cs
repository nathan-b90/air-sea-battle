/*
 * By Nathan Barrett
 * Copyright Betari 1977
 */

using Betari.AirSeaBattle.Scripts.Enums;
using UnityEngine;

namespace Betari.AirSeaBattle.Scripts.Player
{
    /// <summary>
    /// Controls the player sprite according to input.
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public sealed class PlayerSprite : MonoBehaviour
    {
        [SerializeField] private Sprite aimUpSprite;
        [SerializeField] private Sprite aimCentreSprite;
        [SerializeField] private Sprite aimDownSprite;

        private PlayerInput input;
        private SpriteRenderer spriteRenderer;

        void Awake()
        {
            input = GetComponent<PlayerInput>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            input.OnAim += SetAimDirection;
        }

        // Changes player sprite when detecting a change of aim direction.
        void SetAimDirection(AimDirection dir)
        {
            switch (dir)
            {
                case AimDirection.Up:
                    spriteRenderer.sprite = aimUpSprite;
                    break;
                case AimDirection.Centre:
                    spriteRenderer.sprite = aimCentreSprite;
                    break;
                case AimDirection.Down:
                    spriteRenderer.sprite = aimDownSprite;
                    break;
            }
        }
    }
}