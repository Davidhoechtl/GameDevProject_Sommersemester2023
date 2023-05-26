
namespace Assets.YourMinigameName.Code.Scripts
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
    {
        public float speed = 20;
        private Vector2 movementInput;


        private void Update()
        {
            transform.Translate(new Vector3 (movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            movementInput = ctx.ReadValue<Vector2>();
        }

        public void OnPause(InputAction.CallbackContext ctx)
        {
            MenuHandler.Instance.PauseGame();
        }
    }
}
