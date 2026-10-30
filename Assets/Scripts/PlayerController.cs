using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Vector3 volacity;
    public float gravity = -9.15f;

    [SerializeField] private CharacterController player;
    [SerializeField] private Vector3 playerMovement = new Vector3 (0f,0f,0f);
    [SerializeField] private Vector3 playerRotation = new Vector3(0f, 0f, 0f);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(0f,playerRotation.y,0f);

        //transform.Rotate(playerRotation);
        //playerMovement = transform.TransformDirection(playerMovement);
        volacity.y = gravity * Time.deltaTime;
        player.transform.Rotate(Vector3.up * playerMovement.x);

        Vector3 movement = player.transform.forward * playerMovement.z;

        player.Move(volacity);

        player.Move(speed * Time.deltaTime * movement);
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovement.z = context.ReadValue<Vector2>().y;
        playerMovement.x = context.ReadValue<Vector2>().x;
        //playerRotation = new Vector3(0f, context.ReadValue<Vector2>().x, 0f);
    }
}