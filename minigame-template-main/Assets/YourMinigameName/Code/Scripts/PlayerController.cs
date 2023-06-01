namespace Assets.YourMinigameName.Code.Scripts
{
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using static UnityEngine.InputSystem.InputAction;

    public class PlayerController : MonoBehaviour
    {
        public float speed = 20;
        private Vector2 movementInput;
        private PlayerConfiguration playerConfiguration;


        private void Update()
        {
            transform.Translate(new Vector3 (movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            Debug.Log(movementInput);
            movementInput = ctx.ReadValue<Vector2>();
        }

        public void OnPause(InputAction.CallbackContext ctx)
        {
            MenuHandler.Instance.PauseGame();
        }

        public void InitializePlayer(PlayerConfiguration playerConfig)
        {
            playerConfiguration = playerConfig;
            //material change
            playerConfig.Input.onActionTriggered += Input_onActionTriggered;
        }

        private void Input_onActionTriggered(CallbackContext obj)
        {
            Debug.Log(obj.action.name);
            //.actions
            if (obj.action.name == playerConfiguration.Input.actions.actionMaps[2].actions[0].name)
            {
                OnMove(obj);
            }
            else if (obj.action.name == playerConfiguration.Input.actions.actionMaps[2].actions[1].name)
            {
                OnPause(obj);
            }
        }
    }
}
