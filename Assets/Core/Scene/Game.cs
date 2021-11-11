using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Core
{
    public abstract class Game
    {
        private static SceneManagerBase sceneManager { get;  set; }

        public static void Run()
        {
            sceneManager = new SceneManagerRoot();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine()
        {
            sceneManager.InitSceneMap();
            yield return sceneManager.LoadCurrentSceneAsync();
        }

        public static T GetInteractor<T>() where T : Interactor
        {
            return sceneManager.GetInteractor<T>();
        }


        public static T GetRepository<T>() where T : Repository
        {
            return sceneManager.GetRepository<T>();
        }
    }
}