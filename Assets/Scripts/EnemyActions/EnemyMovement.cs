using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    public float maxDistanceToFollow;

    public abstract IEnumerator FindPath(float time);
    public abstract void FindTarget();
    public abstract void GetObjectsFromInspector();
}
