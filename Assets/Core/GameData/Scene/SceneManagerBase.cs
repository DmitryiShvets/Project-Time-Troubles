using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public abstract class SceneManagerBase
    {
        public Scene actyalScene { get; private set; }

        public bool isLoading { get; private set; }

        protected Dictionary<string, SceneConfig> _sceneConfigsMap;

        public SceneManagerBase()
        {
            _sceneConfigsMap = new Dictionary<string, SceneConfig>();
            this.InitSceneMap();
        }

        public abstract void InitSceneMap();


        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (isLoading) throw new Exception("Scene is loading now!");
            var config = _sceneConfigsMap[sceneName];
            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;
            yield return Coroutines.StartRoutine(LoadSceneAsync(sceneConfig));
            yield return Coroutines.StartRoutine(InitializeSceneAsync(sceneConfig));
            isLoading = false;
        }

        public Coroutine LoadCurrentSceneAsync()
        {
            if (isLoading) throw new Exception("Scene is loading now!");

            var sceneName = SceneManager.GetActiveScene().name;
            
            var config = _sceneConfigsMap[sceneName];
            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
        }


        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;
            yield return Coroutines.StartRoutine(InitializeSceneAsync(sceneConfig));
            isLoading = false;
        }


        private IEnumerator LoadSceneAsync(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
            {
                yield return null;
            }

            async.allowSceneActivation = true;
        }

        private IEnumerator InitializeSceneAsync(SceneConfig sceneConfig)
        {
            actyalScene = new Scene(sceneConfig);
            yield return actyalScene.InitializeAsync();
        }

        public T GetRepository<T>() where T : Repository
        {
            return actyalScene.GetRepository<T>();
        }
        
        public T GetInteractor<T>() where T : Interactor
        {
            return actyalScene.GetInteractor<T>();
        }
    }
}