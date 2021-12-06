using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        private Button _startButton;

        private Button _exitButton;

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
            // root = GetComponent<UIDocument>().rootVisualElement;
            _startButton = _rootMenu.Q<Button>("start-button");
            _exitButton = _rootMenu.Q<Button>("exit-button");
            _startButton.clicked += StartBtnPressed;
            _exitButton.clicked += ExitBtnPressed;
        }

        // Update is called once per frame
        void Update()
        {
        }

        void StartBtnPressed()
        {
            // var scene = SceneManager.GetSceneByBuildIndex(1); 
            // SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Player"),scene);
            SceneManager.LoadScene("Scenes/home");

            // ActivateMenu();
            Debug.Log("Game started");
        }

        void ExitBtnPressed()
        {
           
                Application.Quit();
                Debug.Log("Game Closed");
         
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