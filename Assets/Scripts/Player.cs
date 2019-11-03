using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;



public class Player : Creature
{
    public bool parry;
    public PlayerActions Actions { get; set; }

    List<GameObject> targetList;
    PlayerActions keyboardListener;
    PlayerActions joystickListener;
    int layerMask;
    float LeftStickInputX; float LeftStickInputY;
    
    float RightStickInputX; float RightStickInputY;
    
    InputDevice inputDevice;

    void OnEnable()
    {
        //Actions = PlayerActions.CreateWithKeyboardBindings();
        Actions = PlayerActions.CreateWithJoystickBindings();
        //keyboardListener = PlayerActions.CreateWithKeyboardBindings();
        //joystickListener = PlayerActions.CreateWithJoystickBindings();
    }

    void OnDisable()
    {
        if (Actions != null)
        {
            Actions.Destroy();
        }
    }

    public virtual void Start()
    {
        layerMask = LayerMask.GetMask("Boss", "Mob");
    }
    public virtual void Update()
    {
        PlayerInputLeftStick();
        PlayerInputRightStick();
        Attack();
    }

    void FixedUpdate(){
        GetTarget(RightStickInputX, RightStickInputY);
        Movement(LeftStickInputX, LeftStickInputY);
        _animator.SetFloat("Speed", Speed);
    }

    public virtual void Movement(float x, float y){
        //get input from left stick and move
        Vector3 movement = new Vector3(x,0,y);
        this.GetComponent<Rigidbody>().velocity = movement*Speed;
        if (movement != Vector3.zero) {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.6F);
            Speed = moveSpeed;
            
        } else{
            Speed = 0;
        }
    }

    public void PlayerInputLeftStick(){
        LeftStickInputX = Actions.LeftStick.X;
        LeftStickInputY = Actions.LeftStick.Y;
    }

    public void PlayerInputRightStick(){
        RightStickInputX = Actions.RightStick.Y;
        RightStickInputY = Actions.RightStick.X;
    }
    public virtual void GetTarget(float x, float y){
        //Get input from Right stick and set target to unit hit by ray
        if(x != 0 || y != 0){
            RaycastHit hit;
            Vector3 direction = new Vector3(x,0,y);
            Debug.DrawRay(transform.position + new Vector3(0,.6f,0), direction * 15.0f, Color.red);
            if(Physics.Raycast(this.transform.position + new Vector3(0,.6f,0), direction, out hit, 15.0f, layerMask)){
                
                Debug.Log("Hit " + hit.transform.name);
                target = hit.transform.gameObject;
            }
        }
    }

    public override void Attack(){
        _animator.SetTrigger("Attacking");
    }
    
    public override void Flinch(){
        _animator.SetTrigger("Flinch");
    }
    public bool CheckIfAlive(GameObject go){
        return(go.GetComponent<Creature>().alive);
    }



}



// public Vector2 ConvertToRaw(float x, float y){
//     float rawX = x >= 0 ? Mathf.Ceil(x) : Mathf.Floor(x);
//     float rawY = y >= 0 ? Mathf.Ceil(y) : Mathf.Floor(y);
//     return new Vector2(rawX, rawY);
// }
// void Gravity(){
//         if(rb.velocity.y < 0){
//             rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
//         }
//         else if (rb.velocity.y > 0 && !Actions.ActionBottom.IsPressed){
//             Debug.Log("low Jump");
//             rb.velocity += Vector3.up * Physics.gravity.y * lowJumpMultiplier * Time.deltaTime;
//         }
//     }
//    public void Jump(){
//         if(Actions.ActionBottom.WasPressed){
//             rb.velocity = Vector3.up * jumpVelocity;
//             Debug.Log(rb.velocity);
//         }
//     }