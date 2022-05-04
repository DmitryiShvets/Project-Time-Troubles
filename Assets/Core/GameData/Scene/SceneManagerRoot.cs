namespace Core
{
    public sealed class SceneManagerRoot : SceneManagerBase
    {
        //Инициализирует все карты (репозитории и интеракторы у каждой сцены)
        public override void InitSceneMap()
        {
            this._sceneConfigsMap[WorldConfig.SC_NAME] = new WorldConfig();
            this._sceneConfigsMap[HomeConfig.SC_NAME] = new HomeConfig();
            this._sceneConfigsMap[TempleConfig.SC_NAME] = new TempleConfig();
            this._sceneConfigsMap[CampConfig.SC_NAME] = new CampConfig();
            this._sceneConfigsMap[CavesConfig.SC_NAME] = new CavesConfig();
            this._sceneConfigsMap[ForestConfig.SC_NAME] = new ForestConfig();
            this._sceneConfigsMap[FrozenMountainConfig.SC_NAME] = new FrozenMountainConfig();
            this._sceneConfigsMap[MenuConfig.SC_NAME] = new MenuConfig();
        }
    }
}