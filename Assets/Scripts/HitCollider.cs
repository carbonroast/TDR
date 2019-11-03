using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public GameObject target;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enabled");
    }

    void OnDisable(){
        Debug.Log("Disabled");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(){
        if(target){
            if(target.tag == "Parry"){
                if(target.GetComponent<Player>().parry){
                    Debug.Log("Parry");
                }
                else{
                    Debug.Log("Failed Parry");
                    target.GetComponent<Player>().Flinch();
                }

            }
            else{
                Debug.Log("Could not Parry, Hit");
                target.GetComponent<Creature>().Flinch();
            }
        }
    }
    void OnTriggerEnter(Collider other){
        target = other.gameObject;
    }
    void OnTriggerExit(Collider other){
        target = null;
    }
}
