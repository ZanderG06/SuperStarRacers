using UnityEngine;
using UnityEngine.AI;

public class CPURacer : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform target;
    public CPURacer[] instance;
    public GameObject[] enemies;
    public PickupRotator test;

    public int currentTargetIndex = 0;
    public GameObject[] checkpoints;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
         
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(checkpoints[currentTargetIndex].transform.position);

        /*
        if(target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }*/
        if(Vector3.Distance(this.transform.position, enemies[0].transform.position) <= 1)
        {

        }

        if(currentTargetIndex >= 3)
        {
            currentTargetIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("it works");
            currentTargetIndex += 1;
        }

        if (other.transform == ServiceHub.Instance.CarProgress.checkpoints[ServiceHub.Instance.CarProgress.currentCheckpointIndex])
        {
            ServiceHub.Instance.CarProgress.currentCheckpointIndex += 1;
        }
    }
    public void SetSpeed(float speed)
    {
        navMeshAgent.speed = speed;
    }
}