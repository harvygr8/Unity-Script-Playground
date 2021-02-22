using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Vector3 CamDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CamDistance = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + CamDistance;
    }
}
