using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyHit : MonoBehaviour
{
    public float attackTime;
    public float nextAttack;
    public float maxHitDistance;
    public GameObject target;
    public new Rigidbody rigidbody;
    [HideInInspector]public Vector3 directionToHit;
    public float hitStrength;
    public PlayerController playerController;
    public Animator animator;

    public abstract IEnumerator DoHit(float time);

    public abstract void HitTarget();

    public abstract void GetObjectsFromInspector();
}
