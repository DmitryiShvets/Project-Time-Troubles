using Core.Actions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Actions
{
    public class CustomEventSys : MonoBehaviour, ActionsManager.IUiActions
    {
        private ActionsManager actionsManager;

        public UnityEvent PauseEvent;
        public UnityEvent AddEvent;
        public UnityEvent SpendEvent;

        private void Awake()
        {
            actionsManager = new ActionsManager();
            actionsManager.Ui.SetCallbacks(this);
        }

        private void OnEnable()
        {
            actionsManager.Enable();
        }

        private void OnDisable()
        {
            actionsManager.Disable();
        }

        public void OnPauseGame(InputAction.CallbackContext context)
        {
            PauseEvent.Invoke();
        }

        public void OnPressAdd(InputAction.CallbackContext context)
        {
            AddEvent.Invoke();
        }

        public void OnPressRem(InputAction.CallbackContext context)
        {
            SpendEvent.Invoke();
        }
    }
}