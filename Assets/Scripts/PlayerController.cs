using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int currentLap;
    public TMP_Text lapUI;
    bool isDrifting = false;
    Vector3 movement;
    Vector3 movementTracker;
    bool isMovingForward;
    bool isMovingBackward;
    public float speed = 0f;
    public float rotationSpeed = 190f;
    public float gravity = -9.15f;
    public float minRotation = -90f;
    public float maxRotation = 90f;
    public float currentRotation;
    public float acceleraction = 2f;
    public float deceleraction = 2f;
    public float maxSpeed = 10f;
    public float minFOV = 60f;
    public float maxFOV = 80f;
    public float fovChangeSpeed = 1.5f;
    Vector3 velocity;

    bool[] checkpoints = new bool[4];
    public PickupRotator test;

    [SerializeField] private CharacterController player;
    [SerializeField] private Vector3 playerMovement = new Vector3 (0f,0f,0f);
    [SerializeField] private Vector3 playerRotation = new Vector3 (0f,0f,0f);

    void Start()
    {
        //finds the characterController
        player = gameObject.GetComponent<CharacterController>();
        currentLap = 1;
    }

    void Update()
    {
        if (isMovingForward)
        {
            speed = Mathf.MoveTowards(speed, maxSpeed, acceleraction * Time.deltaTime);

            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
            movement = player.transform.forward;
            movementTracker = movement;

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOV, Time.deltaTime * fovChangeSpeed);
        }
        else if (isMovingBackward)
        {
            speed = Mathf.MoveTowards(speed, maxSpeed, acceleraction * Time.deltaTime);

            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
             movement = -player.transform.forward;
            movementTracker = movement;

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, minFOV, Time.deltaTime * fovChangeSpeed);
        }
        else
        {
            speed = Mathf.MoveTowards(speed, 0f, deceleraction * Time.deltaTime);

            if (speed <= 0)
            {
                speed = 0;
            }
            if(movementTracker.z > 0)
            {
                movement = player.transform.forward;
            }
            if (movementTracker.z < 0)
            {
                movement = -player.transform.forward;
            }




            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, minFOV, Time.deltaTime * fovChangeSpeed);
        }
        

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
                player.transform.Rotate(playerRotation.y * rotationSpeed * Time.deltaTime * Vector3.up);
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
        

        // keeps player on the ground
        player.Move(velocity);

        // moves the player
        player.Move(speed * Time.deltaTime * movement);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // gets the players input
        playerMovement = new Vector3(0f, 0f, context.ReadValue<Vector2>().y);
        //if (context.ReadValue<Vector2>().y != 0f)
        playerRotation = new Vector3(0f, context.ReadValue<Vector2>().x, 0f);

        if(playerRotation.y < 1 && playerRotation.y > -1)
        {
            //currentRotation = transform.localEulerAngles.y;
            if (!isDrifting)
            {
                maxRotation = currentRotation + 120;
                minRotation = currentRotation - 120;
            }
        }

        if (context.ReadValue<Vector2>().y > 0)
        {
            isMovingForward = true;
        }
        else if(context.ReadValue<Vector2>().y < 0)
        {
            isMovingBackward = true;
        }
        else
        {
            isMovingForward = false;
            isMovingBackward = false;
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
            rotationSpeed /= 2f;
            Debug.Log("drifting");
        }
        if (context.canceled)
        {
            maxRotation = currentRotation + 90;
            minRotation = currentRotation - 90;
            isDrifting = false;
            rotationSpeed *= 2f;
            Debug.Log("Stopped drifting");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            if (other.gameObject.name == "CheckPoint(1)") checkpoints[0] = true;
            if (other.gameObject.name == "CheckPoint(2)") checkpoints[1] = true;
            if (other.gameObject.name == "CheckPoint(3)") checkpoints[2] = true;
            if (other.gameObject.name == "CheckPoint(4)") checkpoints[3] = true;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            int checkpointsCompleted = 0;
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (checkpoints[i] == false) return;

                checkpointsCompleted++;
            }

            if (checkpointsCompleted == checkpoints.Length)
            {
                currentLap++;
                lapUI.text = $"Lap {currentLap}/3";

                checkpoints = new bool[4]; //Resets all to false
            }
            if (currentLap >= 3)
            {
                Debug.Log("Race Finished");
                ServiceHub.Instance.PointSystem.CheckPoints();
            }
        }

        if (other.transform == ServiceHub.Instance.CarProgress.checkpoints[ServiceHub.Instance.CarProgress.currentCheckpointIndex])
        {
            ServiceHub.Instance.CarProgress.currentCheckpointIndex += 1;
           
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        test.MyIntract();
    }
}