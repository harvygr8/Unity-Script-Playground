using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BallRollMovement : MonoBehaviour
{

    [SerializeField] private float speed = 4;
    [SerializeField] private bool inAir;
    private Rigidbody BallRigidbody;
    private Transform BallPositon;

    // Start is called before the first frame update
    void Start()
    {
        BallRigidbody = gameObject.GetComponent<Rigidbody>();
        BallPositon = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        BallRigidbody.AddForce(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            BallRigidbody.AddForce(new Vector3(0, 250, 0));
        }
    }


    //Ground Check
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            inAir = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            inAir = true;
        }
    }
}
