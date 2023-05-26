
namespace Assets.YourMinigameName.Code.Scripts
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
    {
        public float speed = 20;
        public float jumpAmount = 10;
        private Vector2 movementInput;


        public Rigidbody rb;

        private void Start()
        {
        }



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

        public void OnJump(InputAction.CallbackContext ctx)
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
            
        }

    
    }
}
