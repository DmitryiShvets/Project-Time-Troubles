using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;
using Core;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        private Button _startButton;

        private Button _exitButton;

        private Button _continueButton;

        private VisualElement _rootMenu;

        //private VisualElement _startCheck;

        private bool _menuVisible = false;

        private void Awake()
        {
            _rootMenu = GetComponent<UIDocument>().rootVisualElement;
            _rootMenu.visible = _menuVisible;
        }

        // Start is called before the first frame update
        void Start()
        {
            // root = GetComponent<UIDocument>().rootVisualElement;
            _startButton = _rootMenu.Q<Button>("start-button");
            _exitButton = _rootMenu.Q<Button>("exit-button");
            _continueButton = _rootMenu.Q<Button>("continue-button");
            //_startCheck = _rootMenu.Q<VisualElement>("start-check");

            _startButton.clicked += StartBtnPressed;
            _exitButton.clicked += ExitBtnPressed;
            _continueButton.clicked += ContinueBtnPressed;

            if (Game.CanContinue())
                _continueButton.SetEnabled(true);
            else _continueButton.SetEnabled(false);
         
            //_startButton.RegisterCallback<ClickEvent>();
        }
    

        // Update is called once per frame
        void Update()
        {
        }

        void StartBtnPressed()
        {
            // var scene = SceneManager.GetSceneByBuildIndex(1); 
            // SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Player"),scene);    
            Game.StartGame();
            //SceneManager.LoadScene("Scenes/home");

            // ActivateMenu();
        }

        void ContinueBtnPressed()
        {
            Game.ContinueGame();
        }

        void ExitBtnPressed()
        {
            //  Game.SaveScene();
            Application.Quit();
        }


        public void ActivateMenu()
        {
            if (_menuVisible)
            {
                _rootMenu.visible = false;
                _menuVisible = false;
            }
            else
            {
                _rootMenu.visible = true;
                _menuVisible = true;
            }
        }
    }
}