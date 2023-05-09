using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 200f;

    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        playerRb.AddForce(movement * Speed * Time.deltaTime, ForceMode.Force);
    }

    private Rigidbody playerRb;
}
