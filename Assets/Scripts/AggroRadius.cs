using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRadius : MonoBehaviour
{
    LayerMask layerMask;
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        //Add Player to enemy list
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            enemies.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other){
        //Remove Player to enemy list
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            enemies.Remove(other.gameObject);
        }
    }
}
