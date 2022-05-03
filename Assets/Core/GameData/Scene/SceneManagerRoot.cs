namespace Core
{
    public sealed class SceneManagerRoot:SceneManagerBase
    {
        public override void InitSceneMap()
        {
            this._sceneConfigsMap[ConfigEx.SC_NAME] = new ConfigEx();  
            this._sceneConfigsMap[HomeConfig.SC_NAME] = new HomeConfig();  
        }
    }
}