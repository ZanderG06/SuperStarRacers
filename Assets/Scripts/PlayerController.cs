using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool isDrifting = false;
    public float speed = 5f;
    public float rotationSpeed = 190f;
    public float gravity = -9.15f;
    public float minRotation = -90f;
    public float maxRotation = 90f;
    public float currentRotation;

    Vector3 velocity;
    bool test = false;

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

        currentRotation = transform.localEulerAngles.y;
        if (currentRotation > 180)
        {
            currentRotation -= 360;
        }

        if (currentRotation >= minRotation)
        {
            if (currentRotation <= maxRotation)
            {
                player.transform.Rotate(Vector3.up * playerRotation.y * Time.deltaTime * rotationSpeed);
            }
        }

        // Handles turning of the player
        //currentRotation <= maxRotation
        //if (currentRotation >= minRotation.y)
        //{
        //    if(currentRotation <= maxRotation.y)
        //    {
        //        player.transform.Rotate(Vector3.up * playerRotation.y * Time.deltaTime * rotationSpeed);
        //        currentRotation = player.transform.rotation.y;
        //    }



        //}
        //if(test)
        //{
        //    minRotation.y = gameObject.transform.rotation.y - 45f;
        //    maxRotation.y = player.transform.rotation.y + 45f;
        //    test = false;
        //}

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

        if(context.ReadValue<Vector2>().x == 0)
        {
            //currentRotation = transform.localEulerAngles.y;
            if (!isDrifting)
            {
                maxRotation = currentRotation + 90;
                minRotation = currentRotation - 90;
            }
            
        }
        
        //if (context.ReadValue<Vector2>().x == 0)
        //{
        //    test = true;

        //    //if (maxRotation.y > 1) maxRotation.y = 1;

        //    /*
        //    if(maxRotation == 0.5f)
        //    {
        //        maxRotation = 1f;
        //    }
        //    else if(maxRotation == 1f)
        //    {
        //        maxRotation = 0.5f;
        //    }*/
            
        //    Debug.Log("hi");
        //}
    }
    public void OnDrift(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(context);
            maxRotation = 180;
            minRotation = -180;
            isDrifting = true;
            rotationSpeed = rotationSpeed / 2f;
        }
        if (context.canceled)
        {
            maxRotation = currentRotation + 90;
            minRotation = currentRotation - 90;
            isDrifting = false;
            rotationSpeed = rotationSpeed * 2f;
        }
        
    }
}