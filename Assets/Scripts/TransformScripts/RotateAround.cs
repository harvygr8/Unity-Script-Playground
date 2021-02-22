using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    [SerializeField] private GameObject target;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pos = target.transform.position;
        transform.RotateAround(pos, Vector3.up, 30 * Time.deltaTime);

    }
}
