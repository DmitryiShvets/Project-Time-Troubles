using System.Collections;
using System.Collections.Generic;
using Core;

using Tools;
using UnityEngine;

namespace Core
{


    public class Scene
    {
        private InteractorBase _interactorBase;
        private RepositoryBase _repositoryBase;
        private SceneConfig _sceneConfig;

        public Scene(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
            _interactorBase = new InteractorBase(sceneConfig);
            _repositoryBase = new RepositoryBase(sceneConfig);
        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }
        private IEnumerator InitializeRoutine()
        {
            _interactorBase.CreateAllInteractors();
            _repositoryBase.CreateAllRepositories();
            yield return null;

            _interactorBase.OnCreateAllInteractors();
            _repositoryBase.OnCreateAllRepositories();
            yield return null;

            _interactorBase.OnInitializeAllInteractors();
            _repositoryBase.OnInitializeAllRepositories();
            yield return null;

            _interactorBase.OnStartAllInteractors();
            _repositoryBase.OnStartAllRepositories();
            yield return null;
            
          
        }

        public T GetRepository<T> ()where T:Repository
        {
            return _repositoryBase.GetRepository<T>();
        }
        
        public T GetInteractor<T> ()where T:Interactor
        {
            return _interactorBase.GetInteractor<T>();
        }
    }
}