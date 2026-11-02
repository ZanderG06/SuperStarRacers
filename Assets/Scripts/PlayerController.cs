using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Vector3 velocity;
    public float gravity = -9.15f;

    [SerializeField] private CharacterController player;
    [SerializeField] private Vector3 playerMovement = new Vector3 (0f,0f,0f);
    [SerializeField] private Vector3 playerRotation = new Vector3(0f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //finds the characterController
        player = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //gravity caluations
        velocity.y = gravity * Time.deltaTime;
        
        // Handles turning of the player
        player.transform.Rotate(Vector3.up * playerRotation.y);

        // Updates the player to move forward based on where it's facing
        Vector3 movement = player.transform.forward * playerMovement.z;

        // keeps player on the ground
        player.Move(velocity);

        // moves the player
        player.Move(speed * Time.deltaTime * movement);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        // gets the players input 
        playerMovement = new Vector3(0f, 0f, context.ReadValue<Vector2>().y);
        playerRotation = new Vector3(0f, context.ReadValue<Vector2>().x, 0f);
    }
}