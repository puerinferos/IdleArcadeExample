using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Character character;

        private void Start()
        {
            character.Initialize(joystick);
        }
    }
}