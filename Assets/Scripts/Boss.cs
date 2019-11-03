using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Creature
{
    public float parryStartTime;
    public float animationTime;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Boss");
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public virtual void Movement(){
        
    }

    public override void Attack(){
        //Start animation

        //set parry time
        parryStartTime = Time.time + animationTime;
    }

    public virtual void GetTarget(){

    }

    public override void Flinch(){

    }
}
