using UnityEngine;
using UnityEngine.AI;

public class CPURacer : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform target;

    public int currentTargetIndex = 0;
    public GameObject[] checkpoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(checkpoints[currentTargetIndex].transform.position);

        /*
        if(target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("it works");
            currentTargetIndex = 1;
        }
            
    }
}