using Assets.YourMinigameName.Code.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class KnockBackPowerup : MonoBehaviour
{
    public float knockBackForce = 8;
    public float knockBackTime = 5;

    public float speed = 8f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new position using a sine wave to create an up-and-down movement
        Vector3 newPosition = startPosition + new Vector3(0f, (Mathf.Sin(Time.time * speed) + 1) * 0.5f, 0f);
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            StartCoroutine(player.CollectItem(this));
            Destroy(gameObject);
        }
    }
}
