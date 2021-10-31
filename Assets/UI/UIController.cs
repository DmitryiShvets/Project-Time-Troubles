using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class UIController : MonoBehaviour
{
    public Button startButton;

    public Button exitButton;

    public ActionsManager actions;

    private VisualElement root;

    private bool _menuVisible = false;

    private void Awake()
    { 
        root = GetComponent<UIDocument>().rootVisualElement;
        actions = new ActionsManager();
        root.visible = _menuVisible;
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    // Start is called before the first frame update
    void Start()
    { 
       // root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("Menu-StartButton");
        exitButton = root.Q<Button>("Menu-ExitButton");
        startButton.clicked += StartBtnPressed;
        exitButton.clicked += ExitBtnPressed;

        actions.Ui.PauseGame.performed += (context) => { ActivateMenu(); };
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartBtnPressed()
    {
        SceneManager.LoadScene("Scenes/world");
        // ActivateMenu();
        Debug.Log("Game started");
    }

    void ExitBtnPressed()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    private void ActivateMenu()
    {
        if (_menuVisible)
        {
            root.visible = false;
            _menuVisible = false;
        }
        else
        {
            root.visible = true;
            _menuVisible = true;
        }
    }
}