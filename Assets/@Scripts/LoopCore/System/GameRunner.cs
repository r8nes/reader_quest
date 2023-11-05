﻿using UnityEngine;

namespace ChooseReader.Structure
{
    public class GameRunner : MonoBehaviour
    {
        public Bootstrap BootPrefab;

        private void Awake()
        {
            var bootstrap = FindObjectOfType<Bootstrap>();

            if (bootstrap == null)
                Instantiate(BootPrefab);
        }
    }
}

