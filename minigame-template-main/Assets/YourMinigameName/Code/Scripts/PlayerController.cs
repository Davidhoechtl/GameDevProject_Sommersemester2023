namespace Assets.YourMinigameName.Code.Scripts
{
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using static UnityEngine.InputSystem.InputAction;
    using System.Collections;

    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public float jumpAmount = 5;
        private Vector2 movementInput;
        private Vector2 lookInput;
        public AudioClip jumpSound;
        private AudioSource playerAudio;
        private PlayerConfiguration playerConfiguration;

        private bool isReady2Jump = true;
        private bool canMove = true;
        private int collisionCount = 0;
        public GameObject triangle;
        //private int jumpCount = 3;


        public Rigidbody rb;

        void Start()
        {
            playerAudio = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            rb.AddForce(Physics.gravity * rb.mass * 5);
        }


        private void Update()
        {
            Vector3 rotationAxis = new Vector3(0, lookInput.x, 0);
            triangle.transform.RotateAround(transform.position, rotationAxis, 200 * Time.deltaTime);
            if (canMove && (collisionCount > 0))
            {
                transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
            }
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            movementInput = ctx.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext ctx)
        {
            lookInput = ctx.ReadValue<Vector2>();
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
            if (obj.action.name == playerConfiguration.Input.actions.actionMaps[2].actions[0].name)
            {
                OnMove(obj);
            }
            else if (obj.action.name == playerConfiguration.Input.actions.actionMaps[2].actions[1].name)
            {
                OnPause(obj);
            }
            else if (obj.action.name == playerConfiguration.Input.actions.actionMaps[2].actions[2].name)
            {
                OnJump(obj);
            }
            else if(obj.action.name == playerConfiguration.Input.actions.actionMaps[2].actions[3].name)
            {
                OnLook(obj);
            }
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
            if (isReady2Jump)
            {
                Vector3 jumpDirection = (triangle.transform.position - transform.position).normalized;
                
                rb.AddForce(jumpDirection * jumpAmount, ForceMode.Impulse);
                isReady2Jump = false;
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                StartCoroutine(Wait(2));
            }
        }

        IEnumerator Wait(float time)
        {
            yield return new WaitForSecondsRealtime(time);

            isReady2Jump = true;
        }

        public void SetCanMove(bool value)
        {
            canMove = value;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Cube"))
            {
                collisionCount++;
                SetCanMove(true);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("Cube"))
            {
                collisionCount--;
                if (collisionCount == 0)
                {
                    SetCanMove(false);
                }
            }
        }

    }
}
