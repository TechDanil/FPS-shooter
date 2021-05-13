using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource audioSource;

    [Header("Directions")]
    private Vector3 directionToMove = Vector3.zero;
    private Vector2 velocity;
    // private Vector3 initialSpawnPosition;

    [Header("Objects")]
    public Animator animator;
    private CharacterController characterController;

    [Header("Gravity")]
    [SerializeField] private float jumpForce;

    [Header("Movement speeds")]
    public float speed;
    public float acceleration;
    private float maxAcceleration = 15f;
    public float maxSlowSpeed = 1.5f;

    [Header("Rays")]
    private RaycastHit hit;
    private float maxDistanceToHit = .1f;

    [Header("Other scripts")]
    [HideInInspector] public PlayerHealth playerHealth;
    [SerializeField] private PlayerShooting playerShooting;

    [Header("BoolVariables")]
    private bool isDead;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!IsDead())
        {
            DoMove();
            Jump();
        }
    }

    private void DoMove()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        if (movementZ != 0 || movementX != 0)
        {
            animator.SetBool("Walk", true);
            audioSource.Play();
        }

        else
        {
            animator.SetBool("Walk", false);
            audioSource.Stop();
        }

        characterController.SimpleMove(FindDirectionToMove(movementX, movementZ));
    }

    private Vector3 FindDirectionToMove(float movementX, float movementZ)
    {
        directionToMove = new Vector3(movementX, 0f, movementZ) * speed *
          Time.deltaTime * GetAcceleration() * GetSlowSpeed();

        directionToMove = transform.rotation * directionToMove;
        return directionToMove;
    }

    private float GetAcceleration()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (acceleration < maxAcceleration)
                acceleration += speed * Time.deltaTime;
        }

        else
        {
            acceleration = 6f;
        }

        return acceleration;
    }

    private float GetSlowSpeed()
    {
        float decrease = 0.5f;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (speed > maxSlowSpeed)
                speed -= decrease * Time.deltaTime;
        }

        else
        {
            speed = 6f;
        }

        return speed;
    }

    private void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistanceToHit))
        {
            if (hit.transform.tag == "Ground")
            {
                Debug.DrawLine(transform.position, Vector3.down * hit.distance, Color.red);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    velocity.y = jumpForce;
                    characterController.Move(velocity * Time.deltaTime);
                }

                else
                {
                    velocity.y = 0f;
                }
            }
        }
    }

    public bool IsDead()
    {
        if (playerHealth.healthBar.fillAmount <= 0 && isDead == false)
        {
            isDead = true;
            characterController.enabled = false;
            Debug.Log("died");
            animator.SetBool("Death", true);
            return true;
        }
        return false;
    }
}
