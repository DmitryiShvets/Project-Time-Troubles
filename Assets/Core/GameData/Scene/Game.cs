using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public abstract class Game
    {
        private static SceneManagerBase sceneManager { get; set; }

        private static ActualSceneState _scriptableObject;

        public static void Run()
        {
            sceneManager = new SceneManagerRoot();
            Coroutines.StartRoutine(InitializeGameRoutine());
            _scriptableObject = Resources.Load<ActualSceneState>("LastScene");
        }
        
        public static void AddItem()
        {   MessageBar.Show($"You collected: questItem x 2");
            GameModel model = Schedule.GetModel<GameModel>();
            Sprite[] sprite = Resources.LoadAll<Sprite>("Items");
            model.AddInventoryItem("questItem",2,sprite.First());
            model.AddInventoryItem("questItem1",2,sprite[1]);
            model.AddInventoryItem("questItem2",2,sprite.First());
            model.AddInventoryItem("questItem3",2,sprite.First());
            model.AddInventoryItem("questItem4",2,sprite.First());
        }
        
        public static string GetActualScene()
        {
            return sceneManager.actyalScene.GetActualScene();
        }

        public static string GetLastScene()
        {
            return _scriptableObject.lastScene;
        }

        //Загружает новую сцену
        public static void LoadScene(string sceneName)
        {
            sceneManager.LoadNewSceneAsync(sceneName);
            _scriptableObject.lastScene = sceneName;
        }

        private static IEnumerator InitializeGameRoutine()
        {
            sceneManager.InitSceneMap();
            yield return sceneManager.LoadCurrentSceneAsync();
        }

        public static T GetInteractor<T>() where T : Interactor
        {
            return sceneManager.GetInteractor<T>();
        }


        public static T GetRepository<T>() where T : Repository
        {
            return sceneManager.GetRepository<T>();
        }
    }
}