using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public float speed;
    public float height;

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        
        Vector3 pos = transform.localPosition;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height;
        //Debug.Log(newY);
        //set the object's Y to the new calculated Y
        //Debug.Log(new Vector3(pos.x, newY, pos.z) * height);
        this.transform.localPosition = new Vector3(pos.x, newY, pos.z);
    }
}
