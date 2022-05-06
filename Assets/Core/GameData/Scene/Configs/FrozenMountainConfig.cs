using System;
using System.Collections.Generic;

namespace Core
{
    public class FrozenMountainConfig : SceneConfig
    {
        //Имя сцены.. используеся в коцфиге для загрузки
        public const string SC_NAME = "FrozenMountain";

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