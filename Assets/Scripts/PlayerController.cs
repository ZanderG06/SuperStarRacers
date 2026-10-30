using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController player;

    [SerializeField] Vector3 playerMovement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovement = new Vector3(0f,0f,context.ReadValue<Vector2>().y);
        player.Move(playerMovement);
    }
}
