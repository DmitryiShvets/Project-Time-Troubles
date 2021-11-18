using System;
using System.Collections.Generic;
using Core;

namespace Core
{
    public class ConfigEx : SceneConfig
    {
        public const string SC_NAME = "World";

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();
            CreateInteractor<BankInteractor>(interactorsMap);
            return interactorsMap;
        }

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();
            CreateRepository<BankRepository>(repositoriesMap);
            return repositoriesMap;
        }

        public override string sceneName => SC_NAME;
    }
}