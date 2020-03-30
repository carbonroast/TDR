using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public abstract class Creature : MonoBehaviour
{
    public int health;
    public bool alive;
    public float attackSpeed;
    public State state;
    public float moveSpeed;

    public float currentSpeed;
    public int damage;

    public GameObject spawnables;
    public List<GameObject> spells;
    public GameObject target;
    //public float jumpVelocity;
    //public float fallMultiplier;
    //public float lowJumpMultiplier;

    public Rigidbody rb;
    protected Animator _animator;
    public virtual void Awake(){
        alive = true;
        spawnables = GameObject.Find("Spawnables");
        //spells = spawnables.GetComponent<Spawnable>().Spells;
        rb = this.GetComponent<Rigidbody>();
        _animator = this.GetComponent<Animator>();
    }
    // Start is called before the first frame update



    public virtual void ChangeHealth(int changeHealth){
        health = health + changeHealth;
        if(health < 0){
            alive = false;
            _animator.SetTrigger("Death");
            Die();
        }
    }

    public virtual void Die(){
        Debug.Log(this.gameObject.name + "  is dead");
        this.gameObject.SetActive(false);
        
    }
    public abstract void Attack();

    public abstract void Flinch();

    public virtual float Speed{
        get { return currentSpeed; }
        set{
            currentSpeed = value; 
           
        }
    }
    
}
