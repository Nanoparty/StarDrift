using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private float movementScale;

    private GameObject player;
    //private MeshRenderer mr;

    private Vector3 startingPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //mr = GetComponent<MeshRenderer>();
        startingPosition = player.transform.position;
    }

    void Update()
    {
        if (player == null) return;

        //transform.position =
        //    new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        Vector3 offset = player.transform.position - startingPosition;
        transform.position = (offset * movementScale);
        // mr.material.SetTextureOffset("_MainTex", movementScale * offset);
    }
}
