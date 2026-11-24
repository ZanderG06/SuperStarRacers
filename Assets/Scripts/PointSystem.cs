using UnityEngine;

public class PointSystem : MonoBehaviour
{
    int playerPoints;
    public PlayerController playerController;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPoints();
    }

    void CheckPoints()
    {
        if (playerController.currentLap >= 4)
        {
            if (ServiceHub.Instance.CarProgress.playerPosition == 1)
            {
                playerPoints += 1;
            }
        }
        Debug.Log(playerPoints);
        
    }
}
