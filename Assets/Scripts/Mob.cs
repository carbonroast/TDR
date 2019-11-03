using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Mob : Creature
{
    protected Transform hitBox;
    protected Vector3 destination;
    protected NavMeshAgent agent;

    public float rotationSpeed = 10f;
    protected float distanceFromTarget;

    [SerializeField] bool destinationSet;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Mob");
        agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable(){
        Speed = moveSpeed;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(alive){
            GetTarget();
            if(target){
                Movement();
                //Attack();
            }
            
            
            
        }

    }

    void FixedUpdate(){
        if (alive){
            agent.speed = Speed;
            _animator.SetFloat("Speed", Speed);
        }
    }

    public virtual void Movement(){
        if(IsInMeleeRangeOf(target)){
            RotateTowards(target);
            Attack();
        } else{
            MoveTowards(target);
        }
        

    }

    IEnumerable Wait(){
        float time = Random.Range(2f,5f);
        yield return new WaitForSeconds(time);
    } 

    public override void Attack(){
        _animator.SetTrigger("Attack");
    }

    public override void Flinch(){
        _animator.SetTrigger("Flinch");
    }

    public void Death(){
        _animator.SetTrigger("Death");
    }
    public virtual void GetTarget(){
        //send ray to see check if can see
    }

    public virtual void RotateTowards(GameObject target){
        Vector3 direction = (target.transform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);  
    }

    public virtual bool IsInMeleeRangeOf(GameObject target){
        _animator.SetBool("Moving", false);
        float distance = Vector3.Distance(this.transform.position, target.transform.position);
        //Debug.Log(distance);
        return distance < agent.stoppingDistance;
    }

    public virtual void MoveTowards(GameObject target){
        _animator.SetBool("Moving", true);
        agent.destination = target.transform.position; 
    }
    void Patrol(){
        //get a random point around transform and set as agent destination
        if(!destinationSet){
            Vector3 point;
            if (RandomDestination(out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.destination = point;
                //Debug.Log(agent.destination);
                destinationSet = true;
            }
        } else{
            if (Vector3.Distance(agent.destination, this.transform.position) < 1.0f)
            {
                destinationSet = false;
            } 
        }
    }
    public bool RandomDestination(out Vector3 result){
        //get a random point aroudn agent
        float range = 10.0f;
        Vector3 center = this.transform.position;
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
