using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMatChanger : MonoBehaviour
{
    [SerializeField] private Material originalMat;
    [SerializeField] private Material changedMat;
    [SerializeField] private bool isChanged;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeMaterial()
    {
        gameObject.GetComponent<Renderer>().material = changedMat;
    }

    void ResetMaterial()
    {
        gameObject.GetComponent<Renderer>().material = originalMat;
    }

    //Custom action to change material
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls") && !isChanged)
        {
            ChangeMaterial();
            isChanged = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls") && isChanged)
        {
            ResetMaterial();
            isChanged = false;
        }
    }

}
