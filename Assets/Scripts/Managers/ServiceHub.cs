using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] private CarProgress carProgress;

    public CarProgress CarProgress => carProgress;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}