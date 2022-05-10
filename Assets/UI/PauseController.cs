using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;


namespace UI
{
    public class PauseController : MonoBehaviour
    {

        private Button _startButton;

        private Button _exitButton;

        private Button _continueButton;

        private Button _saveButton;

        private VisualElement _rootMenu;

        private bool _menuVisible = false;

        private void Awake()
        {
            _rootMenu = GetComponent<UIDocument>().rootVisualElement;
            _rootMenu.visible = _menuVisible;

        }

        // Start is called before the first frame update
        void Start()
        {
            _startButton = _rootMenu.Q<Button>("start-button");
            _exitButton = _rootMenu.Q<Button>("exit-button");
            _continueButton = _rootMenu.Q<Button>("continue-button");
            _saveButton = _rootMenu.Q<Button>("save-button");

            _startButton.clicked += StartBtnPressed;
            _exitButton.clicked += ExitBtnPressed;
            _saveButton.clicked += SaveBtnPressed;
            _continueButton.clicked += ContinueBtnPressed;
        }

        void ContinueBtnPressed()
        {
           ActivateMenu();
        }
        void SaveBtnPressed()
        {
            Game.SaveScene();
        }

        void StartBtnPressed()
        { 
            Game.StartGame();
        }
        void ExitBtnPressed()
        {
         //   Game.SaveScene();
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