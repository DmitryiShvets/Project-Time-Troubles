using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScriptableObjects;
using StorageSystem;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public abstract class Game
    {
        private static SceneManagerBase sceneManager { get; set; }

        private static ActualSceneState _scriptableObject;

        private static PositionState _positionState;

        private static string saveFile = "save1.xml";
        public static string SaveFile => saveFile;

        public static void Run()
        {
            sceneManager = new SceneManagerRoot();
            Coroutines.StartRoutine(InitializeGameRoutine());
            _scriptableObject = Resources.Load<ActualSceneState>("LastScene");
            _positionState = Resources.Load<PositionState>("PositonState");
        }

        public static void StartGame()
        {
            var filePath = $"{Application.persistentDataPath}/Saves/{saveFile}";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                LoadSceneNoSave("home");
            }
            else
            {
                LoadSceneNoSave("home");
            }
        }


        public static void PlayerDie()
        {
            LoadSceneNoSave("Menu");
        }

        public static void ContinueGame()
        {
            LoadSceneNoSave(GetLastScene());
        }

        public static bool CanContinue()
        {
            var filePath = $"{Application.persistentDataPath}/Saves/{saveFile}";
            return File.Exists(filePath);
        }

        public static void AddItem()
        {
            MessageBar.Show($"You collected: questItem x 2");
            GameModel model = Schedule.GetModel<GameModel>();
            Sprite[] sprite = Resources.LoadAll<Sprite>("Items");
            // model.AddInventoryItem("questItem", 2, sprite.First());
            // model.AddInventoryItem("questItem1",2,sprite[1]);
            // model.AddInventoryItem("questItem2",2,sprite.First());
            // model.AddInventoryItem("questItem3",2,sprite.First());
            // model.AddInventoryItem("questItem4",2,sprite.First());
        }

        public static string GetActualScene()
        {
            return sceneManager.actyalScene.GetActualScene();
        }

        public static string GetLastScene()
        {
            return _scriptableObject.lastScene;
        }

        public static Vector3 GetPlayerPosition()
        {
            return _positionState.pos;
        }

        public static void SaveScene()
        {
            sceneManager.Save();
        }

        //Загружает новую сцену c сохранением старой
        public static void LoadSceneSave(string sceneName)
        {
            SaveScene();
            sceneManager.LoadNewSceneAsync(sceneName);
            _scriptableObject.lastScene = sceneName;
        }

        //Загружает новую сцену без сохранения старой
        public static void LoadSceneNoSave(string sceneName)
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