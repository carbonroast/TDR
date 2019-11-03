using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyControls : MonoBehaviour
{
    public PlayerActions Actions { get; set; }
    public Lobby lobby;
    
    void OnDisable()
    {
        if (Actions != null)
        {
            Actions.Destroy();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Color color = new Color( Random.value, Random.value, Random.value, 1.0f);
        this.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Actions.LeftStick.X,0,Actions.LeftStick.Y);
        if(Actions.ActionRight.WasPressed){
            lobby.RemovePlayer(this);
        }
    }
}
