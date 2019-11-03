using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> spawnables;
    // Start is called before the first frame update
    void Start()
    {
        float x = 0; float y = 0;
        foreach(GameObject go in spawnables){
            Instantiate(go, new Vector3(x,0,y),Quaternion.identity);
            x++; 

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
