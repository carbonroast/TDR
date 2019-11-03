using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skeleton : Mob
{
    List<GameObject> enemies;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitBox = this.transform.Find("HitBox");
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        ChangeSpeed();

    }

    public void ActivateHitBox()
    {
        
        hitBox.GetComponent<HitCollider>().Attack();
        Color color = new Color( Random.value, Random.value, Random.value, 1.0f);
        hitBox.GetComponent<Renderer>().material.color = color;

    }

    public override void Attack(){

            base.Attack();

    }
    public override void GetTarget(){
        this.enemies = this.GetComponentInChildren<AggroRadius>().enemies;
        if(enemies.Count > 0){
            target = enemies[0];
        }
        
    }

    // public override void Movement(){

    // }

    public  void ChangeSpeed(){
        if(Input.GetKeyDown(KeyCode.W)){
            Speed = 3;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            Speed = 6;
        }
    }


}
