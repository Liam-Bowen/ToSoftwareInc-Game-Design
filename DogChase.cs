using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class DogChase : MonoBehaviour
 {
    public Transform Player;
    public Transform guardSpot;
    public Transform target;
    float distanceFromPlayer;
    int MoveSpeed = 4;
    int MinDist = 3;

    void Awake(){
        target = guardSpot;
    }

    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, Player.position);
        transform.LookAt(target);
 
        if (distanceFromPlayer < 10.0)
        {
            target = Player;
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }else{
            target = guardSpot;
            if(Vector3.Distance(transform.position, guardSpot.position) >= MinDist){
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
        }
    }
 }
