
namespace Assets.YourMinigameName.Code.Scripts
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
    {
        public float Speed = 200f;

        public float horizontalInput;
        public float verticalInput;
        private Vector2 moveDirection = Vector2.zero;

        [SerializeField]
        private InputActionAsset playerControls;
        private InputAction pauseAction;
        private InputAction movementAction;
        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            movementAction = playerControls.FindActionMap("Player").FindAction("Move");
            movementAction.Enable();

            pauseAction = playerControls.FindActionMap("UI").FindAction("Pause");
            pauseAction.Enable();

            pauseAction.started += OnPauseButtonPress;
        }

        private void OnDisable()
        {
            movementAction.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            moveDirection = movementAction.ReadValue<Vector2>();
            Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y).normalized;
            playerRb.AddForce(movement * Speed * Time.deltaTime, ForceMode.Force);

        }

        private void OnPauseButtonPress(InputAction.CallbackContext obj)
        {
            MenuHandler.Instance.PauseGame();
        }

        private Rigidbody playerRb;
    }
}
