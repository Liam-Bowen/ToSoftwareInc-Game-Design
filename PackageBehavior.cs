using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject package;
    public GameObject referencePoint;

    public GameObject visibleImage;
    public GameObject hiddenImage;

    //public GameObject mailBox;
    //public GameObject dropPoint;

    /**void OnTriggerEnter(Collider other){
        if(other.gameObject == player){
            if(Input.GetKeyDown(KeyCode.E)){
                package.transform.parent = referencePoint.transform;
                package.transform.localPosition = Vector3.zero;
                package.transform.localRotation = Quaternion.identity;
                Debug.Log("Item has been picked up");
            }
        }
    }**/

    void Start(){
        visibleImage.SetActive(true);
        hiddenImage.SetActive(false);
    }

    void OnCollisionEnter(Collision collision){

        if(collision.gameObject.name == "Player"){
            package.transform.parent = referencePoint.transform;
            package.transform.localPosition = Vector3.zero;
            package.transform.localRotation = Quaternion.identity;
            visibleImage.SetActive(false);
            hiddenImage.SetActive(true);
            Debug.Log("Item collected!");
        }
    }

    /**void OnCollisionExit(Collision collision){
        if(collision.gameObject.name == "MailBox"){
            package.transform.parent = dropPoint.transform;
            package.transform.localPosition = Vector3.zero;
            package.transform.localRotation = Quaternion.identity;
            Debug.Log("Item placed!");
        }
    }**/
}
