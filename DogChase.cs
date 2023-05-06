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
    public float gravityScale = 5;
    int MinDist = 90;
    bool hasBarked = false;

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
        //print(rb.velocity.magnitude);
 
        if (distanceFromPlayer < dogRange)
        {
            animator.SetBool("TargetingPlayer", true);
            animator.SetBool("Awake", true);
            target = Player;
            rb.AddForce(MoveSpeed * Time.deltaTime * transform.forward);

            if(!hasBarked){
                dogBarkingSound.Play();
                hasBarked = true;
            }
        }else{
            animator.SetBool("TargetingPlayer", false);
            target = guardSpot;
            hasBarked = false;
            if(Vector3.Distance(transform.position, guardSpot.position) >= MinDist){
                rb.AddForce(MoveSpeed * Time.deltaTime * transform.forward);
            }else{
                animator.SetBool("Awake", false);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

 }
