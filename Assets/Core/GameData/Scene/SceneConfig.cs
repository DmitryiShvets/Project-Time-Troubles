using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace Core
{
    public abstract class SceneConfig
    {
        public abstract Dictionary<Type, Interactor> CreateAllInteractors();
        public abstract Dictionary<Type, Repository> CreateAllRepositories();

        public abstract string sceneName { get; }

        public void FillInteractorMap(ref Dictionary<Type, Interactor> map)
        {
            CreateInteractor<BankInteractor>(map);
            CreateInteractor<PlayerHealthInteractor>(map);
          
        }
        public void FillRepositoryMap(ref Dictionary<Type, Repository> map)
        {
            CreateRepository<BankRepository>(map);
            CreateRepository<PlayerHealthRepository>(map);
          
        }

        public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsMap)
            where T : Interactor, new()
        {
            var interactor = new T();
            var type = typeof(T);
            interactorsMap[type] = interactor;
        }

        public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap)
            where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);
            repositoriesMap[type] = repository;
        }
    }
}