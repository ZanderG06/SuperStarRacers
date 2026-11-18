using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class CarProgress : MonoBehaviour
{
    public Transform[] racers;
    public Transform[] checkpoints;
    public int currentCheckpointIndex;
    public int playerPosition;

    public List<Transform> cars = new List<Transform>();

    //public GameObject playerInFirst = null;
    //public GameObject playerInSecond = null;
    //public GameObject playerInThird = null;
    //public GameObject playerInFourth = null;
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
        


        float closestDistance = racerDistances[0];

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

       // playerInFirst = racers[closestRacerIndex].gameObject;

    }
}
