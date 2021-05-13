using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ZombieHealth zombieHealth;
    [SerializeField] private Animator animator;
    public ScoreCounter scoreCounter;
    private bool isDead;
  
    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        isDead = false;
    }
   
    void Update()
    {
        IsDead();
    }

    private void IsDead()
    {
        if(zombieHealth.healthBar.fillAmount <= 0 && isDead == false)
        {
            isDead = true;
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
            enemyMovement.agent.velocity = Vector3.zero;
            
            enemyMovement.agent.isStopped = true;
            animator.SetBool("die", true);
            Destroy(gameObject, 1f);
            scoreCounter.scoreCount++;
        }


    }
}
