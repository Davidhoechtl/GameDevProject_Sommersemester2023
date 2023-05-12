
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

        public InputAction playerInput;
        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            moveDirection = playerInput.ReadValue<Vector2>();
            Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y).normalized;
            playerRb.AddForce(movement * Speed * Time.deltaTime, ForceMode.Force);
        }

        private Rigidbody playerRb;
    }
}
