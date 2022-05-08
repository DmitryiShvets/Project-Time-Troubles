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

        private Button _saveButton;

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
            _saveButton = _rootMenu.Q<Button>("save-button");

            //_startCheck = _rootMenu.Q<VisualElement>("start-check");

            _startButton.clicked += StartBtnPressed;
            _exitButton.clicked += ExitBtnPressed;
            _saveButton.clicked += SaveBtnPressed;

            if (Game.CanContinue())
                _continueButton.SetEnabled(true);
            else _continueButton.SetEnabled(false);

            _continueButton.clicked += ContinueBtnPressed;

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

        void SaveBtnPressed()
        {
            Game.SaveScene();   
        }
        void ExitBtnPressed()
        {
            Game.SaveScene();
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