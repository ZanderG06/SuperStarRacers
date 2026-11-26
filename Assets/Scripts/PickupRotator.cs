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

    float distanceBehind = 2f;
    // speed boost, banaa/stop movement, switch position, blind player and slow oppents
    public int RandomItemNum;

    void Start()
    {
        
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
                case 1: //1st
                    Racers.SetSpeed(20);
                    break;
                case 2: //2nd
                    Vector3 spawnPosition = objectGame.transform.position -(objectGame.transform.forward * distanceBehind);
                    Instantiate(cube, spawnPosition, objectGame.transform.rotation);
                    break;
                case 3: //3rd
                    
                    break;
                case 4: //3rd
                    
                    break;
                default: //4th or below
                   
                    break;
            }
        }
        else if (objectGame == gameObject.CompareTag("Player"))
        {
            switch (RandomItemNum)
            { 
                case 1: //1st
                    player.maxSpeed += 10;
                    break;
                case 2: //2nd
                    Vector3 spawnPosition = objectGame.transform.position - (objectGame.transform.forward * distanceBehind);
                    Instantiate(cube, spawnPosition, objectGame.transform.rotation);
                    break;
                case 3: //3rd
                
                    break;
                case 4: //3rd
                
                    break;
                default: //4th or below
                
                    break;
            }
        }
       


    }
}