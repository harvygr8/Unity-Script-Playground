using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateMatChanger : MonoBehaviour
{
    [SerializeField] private Material originalMat;
    [SerializeField] private Material changedMat;
    [SerializeField] private bool isChanged;
    [SerializeField] private float resetTimer;
    private float originalValue;
    // Start is called before the first frame update
    void Start()
    {
        originalValue=resetTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
            {
                ResetMaterial();
                resetTimer = originalValue;
            }
        }
    }

    void ChangeMaterial()
    {
        gameObject.GetComponent<Renderer>().material = changedMat;
        isChanged = true;
    }

    void ResetMaterial()
    {
        gameObject.GetComponent<Renderer>().material = originalMat;
        isChanged = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isChanged)
        {
            ChangeMaterial();
        }
    }
}
