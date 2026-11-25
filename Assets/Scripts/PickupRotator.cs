using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PickupRotator : MonoBehaviour, IMyIntract
{
    public PlayerController player;
    public CPURacer Racers;

    private GameObject objectGame;
    // speed boost, banaa/stop movement, switch position, blind player and slow oppents
    int RandomItemNum;

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
        RandomItemNum = Random.Range(0, 6);
        if(objectGame == gameObject.CompareTag("Enemy"))
        {

        }
        if(objectGame == gameObject.CompareTag("Player"))
        {

        }
        player.maxSpeed += 10;
        
    }
}