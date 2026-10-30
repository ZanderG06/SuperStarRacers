using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private CharacterController player;
    [SerializeField] private Vector3 playerMovement;
    [SerializeField] private Vector3 playerRotation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(0f,playerRotation.y,0f);

        transform.Rotate(playerRotation);
        //playerMovement = transform.TransformDirection(playerMovement);
        player.Move(speed * Time.deltaTime * playerMovement);
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovement = new Vector3(0f,0f,context.ReadValue<Vector2>().y);
        playerRotation = new Vector3(0f, context.ReadValue<Vector2>().x, 0f);
    }
}