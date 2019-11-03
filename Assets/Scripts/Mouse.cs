using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Mouse : Player
{
    GameObject markerGameObject;
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Defend();
        ChangeSpeed();
        if(target){
            TargetMarker();
        }
    }


    public void ChangeSpeed(){
        if(Actions.ActionLeft.WasPressed){
            moveSpeed = 5;
        }
        if(Actions.ActionRight.WasPressed){
            moveSpeed = 10;
        }
    }

    public void Defend(){
        if (Actions.LTrigger.WasPressed)
        {
            _animator.SetTrigger("Blocking");
        }
    }
    
    public override void Attack(){
        if(Actions.ActionBottom.WasPressed){
            base.Attack();
            Debug.Log("Attack");
            
        }
    }
    
    public void TargetMarker(){
        if(markerGameObject){
            markerGameObject.transform.position = target.transform.position;
        } else{
            GameObject marker = spells.Where(spell => spell.name == "CFX3_DarkMagicAura_A").SingleOrDefault();
            markerGameObject = Instantiate(marker,target.transform.position, marker.transform.rotation);
        }

    }
    public void Parry(int parry)
    {
        Debug.Log(parry);
        this.parry =  parry == 1 ? true : false;
    }

}
