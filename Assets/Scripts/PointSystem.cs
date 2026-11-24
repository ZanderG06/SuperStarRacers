using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSystem : MonoBehaviour
{
    int playerPoints;
    public PlayerController playerController;

    [SerializeField]private GameObject finishUI;
    [SerializeField] private TMP_Text pointsUi;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finishUI = GameObject.Find("finishUI");
        pointsUi = GameObject.Find("Points").GetComponent<TMP_Text>();
        finishUI.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPoints()
    {
        if (finishUI == null)
        {
            finishUI = GameObject.Find("finishUI");
            pointsUi = GameObject.Find("Points").GetComponent<TMP_Text>();
        }
        
            if (ServiceHub.Instance.CarProgress.playerPosition == 1)
            {
                finishUI.active = true;
                playerPoints += 1;
                pointsUi.text = $"{playerPoints}Pts";
            }
        
        Debug.Log(playerPoints);
        
    }
}
