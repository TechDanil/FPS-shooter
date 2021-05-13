using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : EnemyHit
{
    private void Start()
    {
        GetObjectsFromInspector();
        StartCoroutine(DoHit(2f));
    }

    public override void GetObjectsFromInspector()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        playerController = target.GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public override IEnumerator DoHit(float time)
    {
        while (true)
        {
            if (target != null)
            {
                HitTarget();
                yield return new WaitForSeconds(time);
            }
        }
    }

    public override void HitTarget()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < maxHitDistance && Time.time > attackTime)
        {
            directionToHit = (transform.position - target.transform.position).normalized;
            rigidbody.AddForce(directionToHit * hitStrength);
            animator.SetBool("attack", true);
           
            playerController.playerHealth.TakeHealth();
            Debug.Log("Taking health");
            nextAttack = Time.time + attackTime;
        }
        else
            animator.SetBool("attack", false);
    }
}
