using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] racers;
    public Transform[] checkpoints;
    public int currentCheckpointIndex;
    
    public GameObject playerInFirst = null;
    public GameObject playerInSecond = null;
    public GameObject playerInThird = null;
    public GameObject playerInFourth = null;

    private void FixedUpdate()
    {
        float[] racerDistances = new float[racers.Length];
        for (int i = 0; i < racers.Length; i++)
        {
            racerDistances[i] = Vector3.Distance(checkpoints[currentCheckpointIndex].position, racers[i].position);
        }

        int closestRacerIndex = 0;
        int secondRacerIndex = 0;
        int thirdRacerIndex = 0;
        int fourthRacerIndex = 0;

        float closestDistance = racerDistances[0];
        for (int i = 1; i < racerDistances.Length; i++)
        {
            if (racerDistances[i] < closestDistance)
            {
                closestDistance = racerDistances[i];
                closestRacerIndex = i;
            }
        }

        playerInFirst = racers[closestRacerIndex].gameObject;
        
    }
}