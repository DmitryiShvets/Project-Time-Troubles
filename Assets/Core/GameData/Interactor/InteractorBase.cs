using System;
using System.Collections.Generic;

namespace Core
{
    public class InteractorBase
    {
        private Dictionary<Type, Interactor> _interactorsMap;
        private SceneConfig _sceneConfig;

        public InteractorBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllInteractors()
        {
            _interactorsMap = _sceneConfig.CreateAllInteractors();
            // this.CreateInteractor<BankInteractor>();
        }

        private void CreateInteractor<T>() where T : Interactor, new()
        {
            var interactor = new T();
            var type = typeof(T);
            _interactorsMap[type] = interactor;
        }

        public void OnCreateAllInteractors()
        {
            var allInteractors = _interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnCreate();
            }
        }

        public void OnInitializeAllInteractors()
        {
            var allInteractors = _interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnInitialize();
            }
        }

        public void OnStartAllInteractors()
        {
            var allInteractors = _interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnStart();
            }
        }

        public T GetInteractor<T>() where T : Interactor
        {
            var type = typeof(T);
            return (T) _interactorsMap[type];
        }
    }
}