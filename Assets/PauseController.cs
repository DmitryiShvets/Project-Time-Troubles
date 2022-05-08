using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;
using Core;

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
            _rootMenu = GetComponent<UIDocument1>().rootVisualElement;
            _rootMenu.visible = _menuVisible;

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
