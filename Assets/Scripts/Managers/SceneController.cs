using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DogukanKarabiyik.RunnerGame.Managers
{
    public static class SceneController
    {
        public static int UILevelIndex { get; private set; }
        private static int currentLevelIndex;

        private static List<int> playableSceneIndexes = new List<int>();

        private const string levelKey = "levelKey";
        private const string fakeLevelKey = "fakeLevelKey";

        public static Action onSceneLoaded;

        public static void InitiateThisClass()
        {
            GetCurrentPlayableScenes();
            GetLevelFromDisk();
        }

        public static IEnumerator CurrentLevel()
        {
            yield return SceneTransition();
        }

        public static IEnumerator NextLevel()
        {
            UILevelIndex++;

            if (currentLevelIndex < playableSceneIndexes.Count - 1)
                currentLevelIndex++;
            else
                currentLevelIndex = 0;

            SaveLevelToDisk();

            yield return SceneTransition();
        }

        private static void GetCurrentPlayableScenes()
        {
            int count = SceneManager.sceneCountInBuildSettings;

            for (int i = 0; i < count; i++)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(i);

                if (path.Contains("Level") || path.Contains("level"))
                    playableSceneIndexes.Add(i);
            }
        }

        private static void GetLevelFromDisk()
        {
            currentLevelIndex = PlayerPrefs.GetInt(levelKey);
            UILevelIndex = PlayerPrefs.GetInt(fakeLevelKey, 1);
        }

        private static void SaveLevelToDisk()
        {
            PlayerPrefs.SetInt(fakeLevelKey, UILevelIndex);
            PlayerPrefs.SetInt(levelKey, currentLevelIndex);
        }

        private static IEnumerator SceneTransition()
        {
            onSceneLoaded?.Invoke();
            yield return SceneManager.LoadSceneAsync(playableSceneIndexes[currentLevelIndex]);
        }
    }
}