using UnityEngine;

public class PickupRotator : MonoBehaviour, IMyIntract
{
    public PlayerController player;
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            //gameObject.TryGetComponent<IMyIntract>(out IMyIntract interactable);

            //interactable.MyIntract();

            player = other.gameObject.GetComponent<PlayerController>();
            
            gameObject.SetActive(false);
        }
    }
    public void MyIntract()
    {
        player.maxSpeed += 10;

    }
}