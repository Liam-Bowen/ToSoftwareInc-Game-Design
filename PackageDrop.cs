using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDrop : MonoBehaviour
{

    public GameObject player;
    public GameObject package;
    public GameObject referencePoint;
    public GameObject mailBox;
    public GameObject dropPoint;

    public float radius = 1;

    public GameObject visibleImage;
    public GameObject hiddenImage;


    void OnTriggerEnter(Collider other){
        if(other.name == "Player"){
            package.transform.parent = dropPoint.transform;
            package.transform.localPosition = Vector3.zero;
            package.transform.localRotation = Quaternion.identity;
            visibleImage.SetActive(true);
            hiddenImage.SetActive(false);
            //Instantiate(package, dropPoint.transform.position, dropPoint.transform.rotation);
            //Vector3 direction = dropPoint.transform.position - other.transform.position;
            //if (direction.magnitude < radius) {
                //Instantiate(package, dropPoint.transform.position, dropPoint.transform.rotation);
                //Debug.Log("Item placed!");
            //}
            Debug.Log("Item placed!");
            
        }
    }
}
