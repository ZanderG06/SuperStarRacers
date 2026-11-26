using UnityEngine;

public class StopSpeed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CPURacer enmey = other.GetComponent<CPURacer>();
            enmey.SetSpeed(0);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.speed = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
