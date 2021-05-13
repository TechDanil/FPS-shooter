using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : EnemyMovement
{
    private void Start()
    {
        GetObjectsFromInspector();
        StartCoroutine(FindPath(1.5f));    
    }

    public override void GetObjectsFromInspector()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    public override IEnumerator FindPath(float time)
    {
        while (true)
        {
            if (target != null)
            {
                FindTarget();
                yield return new WaitForSeconds(time);
            }
        }
    }

    public override void FindTarget()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < maxDistanceToFollow)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
