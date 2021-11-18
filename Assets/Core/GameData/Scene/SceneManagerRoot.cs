namespace Core
{
    public sealed class SceneManagerRoot:SceneManagerBase
    {
        public override void InitSceneMap()
        {
            this._sceneConfigsMap[ConfigEx.SC_NAME] = new ConfigEx();  
        }
    }
}