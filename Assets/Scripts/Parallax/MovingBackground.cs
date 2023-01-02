using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private float movementScale;

    private GameObject player;

    private Vector3 playerStart;
    private Vector3 localStart;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStart = player.transform.position;
        localStart = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 offset = player.transform.position - playerStart;
        transform.position = localStart + (offset * movementScale);
    }
}
