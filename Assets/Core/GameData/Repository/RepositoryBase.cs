using System;
using System.Collections.Generic;


namespace Core
{
    public class RepositoryBase
    {
        private Dictionary<Type, Repository> _repositoriesMap;
        private SceneConfig _sceneConfig;

        public RepositoryBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
            _repositoriesMap = _sceneConfig.CreateAllRepositories();
        }

        private void CreateRepository<T>() where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);
            _repositoriesMap[type] = repository;
        }

        public void OnCreateAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnCreate();
            }
        }

        public void OnInitializeAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnInitialize();
            }
        }

        public void OnStartAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T) _repositoriesMap[type];
        }
    }
}