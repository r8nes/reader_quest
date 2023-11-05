﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChooseReader.Structure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineLoader;

        public SceneLoader(ICoroutineRunner coroutineRunner) => _coroutineLoader = coroutineRunner;

        public void Load(string name, Action onLoaded = null) => _coroutineLoader.StartCoroutine(LoadScene(name, onLoaded));

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNexScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNexScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}

