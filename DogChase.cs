using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class DogChase : MonoBehaviour
 {
    Rigidbody rb;
    public Transform Player;
    public Transform guardSpot;
    public Transform target;
    Animator animator;
    public AudioSource dogBarkingSound;

    public float dogRange;
    float distanceFromPlayer;
    public int MoveSpeed = 4;
    int MinDist = 90;

    void Awake(){
        target = guardSpot;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        animator.SetFloat("Velocity", rb.velocity.magnitude);
        distanceFromPlayer = Vector3.Distance(transform.position, Player.position);
        transform.LookAt(target);
        print(rb.velocity.magnitude);
 
        if (distanceFromPlayer < dogRange)
        {
            animator.SetBool("TargetingPlayer", true);
            animator.SetBool("Awake", true);
            target = Player;
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            dogBarkingSound.Play();
        }else{
            animator.SetBool("TargetingPlayer", false);
            target = guardSpot;
            if(Vector3.Distance(transform.position, guardSpot.position) >= MinDist){
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }else{
                animator.SetBool("Awake", false);
            }
        }
    }
 }
