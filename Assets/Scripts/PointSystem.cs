using UnityEngine;
using TMPro;
using System.Collections;

public class PointSystem : MonoBehaviour
{
    int playerPoints;
    public PlayerController playerController;

    [SerializeField]private GameObject finishUI;
    [SerializeField] private TMP_Text pointsUi;

    void Start()
    {
        finishUI = GameObject.Find("finishUI");
        pointsUi = GameObject.Find("Points").GetComponent<TMP_Text>();
        finishUI.SetActive(false);
    }

    public void CheckPoints()
    {
        if (finishUI == null)
        {
            finishUI = GameObject.Find("finishUI");
            pointsUi = GameObject.Find("Points").GetComponent<TMP_Text>();
        }

        finishUI.SetActive(true);
        switch (ServiceHub.Instance.CarProgress.playerPosition)
        {
            case 1: //1st
                playerPoints += 9;
                break;
            case 2: //2nd
                playerPoints += 6;
                break;
            case 3: //3rd
                playerPoints += 3;
                break;
            default: //4th or below
                playerPoints += 1;
                break;
        }

        pointsUi.text = $"{playerPoints}Pts";
        Debug.Log(playerPoints);
    }
}