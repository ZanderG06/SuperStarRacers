using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupRotator : MonoBehaviour
{
    public PlayerController player;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            player.speed += 10;
            gameObject.SetActive(false);
        }
    }
}
