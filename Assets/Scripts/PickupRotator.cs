using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupRotator : MonoBehaviour, IMyIntract
{
    public PlayerController player;
    public CPURacer Racers;

    public GameObject cube;

    public GameObject objectGame;

    public GameObject blindObject;

    float distanceBehind = 2f;
    // speed boost, banaa/stop movement, switch position, blind player and slow oppents
    public int RandomItemNum;

    void Start()
    {
        blindObject.SetActive(false);
    }
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Racers = other.gameObject.GetComponent<CPURacer>();
        if (other.gameObject.CompareTag("Player"))
        {
            
            //gameObject.TryGetComponent<IMyIntract>(out IMyIntract interactable);

            //interactable.MyIntract();

            player = other.gameObject.GetComponent<PlayerController>();
            player.test = gameObject.GetComponent<PickupRotator>();
            objectGame = other.gameObject;


            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

            Racers = other.gameObject.GetComponent<CPURacer>();
            Racers.test = gameObject.GetComponent<PickupRotator>();
            objectGame = other.gameObject;

            gameObject.SetActive(false);
        }
    }
    public void MyIntract()
    {
        
        RandomItemNum = 1;
        if(objectGame == gameObject.CompareTag("Enemy"))
        {
            switch (RandomItemNum)
            {
                case 1: 
                    Racers.SetSpeed(20);
                    break;
                case 2:
                    Vector3 spawnPosition = objectGame.transform.position -(objectGame.transform.forward * distanceBehind);
                    Instantiate(cube, spawnPosition, objectGame.transform.rotation);
                    break;
                case 3:
                    Racers.SetSpeed(5);
                    break;
                case 4: 
                    
                    break;
                default:
                   
                    break;
            }
        }
        else if (objectGame == gameObject.CompareTag("Player"))
        {
            
            switch (RandomItemNum)
            { 
                case 1:
                    player.maxSpeed += 10;
                    break;
                case 2: 
                    Vector3 spawnPosition = objectGame.transform.position - (objectGame.transform.forward * distanceBehind);
                    Instantiate(cube, spawnPosition, objectGame.transform.rotation);
                    break;
                case 3:
                    blindObject.SetActive(true);
                    break;
                case 4:
                    ServiceHub.Instance.CarProgress.CheckPositon(objectGame);
                    break;
                default: 
                
                    break;
            }
        }
       


    }
}