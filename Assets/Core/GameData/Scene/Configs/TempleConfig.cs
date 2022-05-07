using System;
using System.Collections.Generic;

namespace Core
{
    public class TempleConfig : SceneConfig
    {
        //Имя сцены.. используеся в коцфиге для загрузки
        public const string SC_NAME = "Temple";

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();
           // FillInteractorMap(ref interactorsMap);
            CreateInteractor<BankInteractor>(interactorsMap);
            return interactorsMap;
        }

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();
            FillRepositoryMap(ref repositoriesMap);
            //CreateRepository<BankRepository>(repositoriesMap);
            return repositoriesMap;
        }

        public override string sceneName => SC_NAME;
    }

}