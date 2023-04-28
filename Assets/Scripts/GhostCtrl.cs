using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostCtrl : MonoBehaviour
{
    NavMeshAgent Nav;
    public Transform Player;
    Animator Anim;
    bool isGhostCatch = false;
    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        Anim.SetBool("IsWalk", true);
        WanderRandomly();
    }

    // Update is called once per frame
    void Update()
    {
        Nav.speed = GameManager.Instance.GhostSpeed;

        if (GameManager.Instance.isDoll)
        {
            //if (GameManager.Instance.isZombieCool)
            //{
            //    return;
            //}

            Nav.SetDestination(Player.position);
            //Nav.speed = GameManager.Instance.GhostSpeed;
            isGhostCatch = true;
            
        }
        else
        {
            if (!isGhostCatch)
            {
                return;
            }
            isGhostCatch = false;
            Vector3 randomDirection = Random.insideUnitSphere * 10;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 10, 1);
            Vector3 finalPosition = hit.position;
            Nav.SetDestination(finalPosition);
            //WanderRandomly();
        }

    }

    void WanderRandomly()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10, 1);
        Vector3 finalPosition = hit.position;
        Nav.SetDestination(finalPosition);
        Invoke("WanderRandomly", 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RHand"))
        {
            GameManager.Instance.isGameOver = true;
        }
    }

}
