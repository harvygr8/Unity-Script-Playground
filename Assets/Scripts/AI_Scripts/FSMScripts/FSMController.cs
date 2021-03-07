using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMController : MonoBehaviour
{
    [SerializeField] private enum State

    {
        IDLE,
        ATTACK
    }

    [SerializeField] private float EnemyDetectionRange=5f;
    [SerializeField] private State CurrentState;

    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = State.IDLE;
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case State.IDLE:
                //Debug.Log("IDLING");

                if (isPlayerDetected())
                {
                    Debug.Log("Player Detected");
                    CurrentState = State.ATTACK;
                }
                break;

            case State.ATTACK:
                //Debug.Log("ATTACKING!");
                ChasePlayer();
                if (!isPlayerDetected())
                {
                    Debug.Log("Player Out of Range");
                    CurrentState = State.IDLE;
                }
                break;

            default:
                break;

        }
    }


    private void ChasePlayer()
    {
        //Debug.Log("Chasing");
        nav.SetDestination(player.transform.position);
    }

    private bool isPlayerDetected()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position)<=EnemyDetectionRange)
        {
            return true;

        }
        else
        {
            return false;
        }

    }
}
