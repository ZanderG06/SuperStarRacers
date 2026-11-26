using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class CarProgress : MonoBehaviour
{
    public Transform[] racers;
    public Transform[] checkpoints;
    public int currentCheckpointIndex;
    public int playerPosition;
    public TMP_Text positionText;
    float closestDistance;

    public List<Transform> cars = new List<Transform>();

    
    public float[] racerDistances;

    private void FixedUpdate()
    {
        
        racerDistances = new float[racers.Length];
        for (int i = 0; i < racers.Length; i++)
        {
            racerDistances[i] = Vector3.Distance(checkpoints[currentCheckpointIndex].position, racers[i].position);

        }
        Array.Sort(racerDistances);

        int closestRacerIndex = 0;
        


         closestDistance = racerDistances[0];

        for (int i = 0; i < racerDistances.Length; i++)
        {
            if (racerDistances[i] == Vector3.Distance(checkpoints[currentCheckpointIndex].position, racers[3].position)) //3 is Player
            {
                playerPosition = i +1; //+1 to account for array starting at 0
            }

            if (racerDistances[i] < closestDistance)
            {
                closestDistance = racerDistances[i];
                closestRacerIndex = i;
            }
        }

        positionText.text = ($"{playerPosition}/4");
       // playerInFirst = racers[closestRacerIndex].gameObject;

    }
    public void CheckPositon(GameObject racer)
    {
        //float checkPosition = Vector3.Distance(checkpoints[currentCheckpointIndex].position, racer.position);
        //for (int i = 0; racerDistances.Length; i++)
        //{
        //    if (checkPosition != closestDistance)
        //    {

        //    }
        //}
        
    }
}
