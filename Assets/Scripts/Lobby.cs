using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;


public class Lobby : MonoBehaviour
{
    public GameObject playerPrefab;
    PlayerActions keyboardListener;
    PlayerActions joystickListener;

    public List<PlayerLobbyControls> players = new List<PlayerLobbyControls>();

	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (JoinButtonWasPressedOnListener( joystickListener ))
        {
            var inputDevice = InputManager.ActiveDevice;

            if (ThereIsNoPlayerUsingJoystick( inputDevice ))
            {
                CreatePlayer( inputDevice );
				
				
            }
        }

        if (JoinButtonWasPressedOnListener( keyboardListener ))
        {
            if (ThereIsNoPlayerUsingKeyboard())
            {
                CreatePlayer( null );
				
            }
        }
    }

    void OnEnable()
    {
        InputManager.OnDeviceDetached += OnDeviceDetached;
        keyboardListener = PlayerActions.CreateWithKeyboardBindings();
        joystickListener = PlayerActions.CreateWithJoystickBindings();
    }
    void OnDisable()
    {
        InputManager.OnDeviceDetached -= OnDeviceDetached;
        joystickListener.Destroy();
        keyboardListener.Destroy();
    }


		bool JoinButtonWasPressedOnListener( PlayerActions actions )
		{
			return actions.ActionBottom.WasPressed;
		}

		PlayerLobbyControls FindPlayerUsingJoystick( InputDevice inputDevice )
		{
			var playerCount = players.Count;
			for (var i = 0; i < playerCount; i++)
			{
				var player = players[i];
				if (player.Actions.Device == inputDevice)
				{
					return player;
				}
			}

			return null;
		}
        bool ThereIsNoPlayerUsingJoystick( InputDevice inputDevice )
		{
			return FindPlayerUsingJoystick( inputDevice ) == null;
		}

        
		PlayerLobbyControls FindPlayerUsingKeyboard()
		{
			var playerCount = players.Count;
			for (var i = 0; i < playerCount; i++)
			{
				var player = players[i];
				if (player.Actions == keyboardListener)
				{
					return player;
				}
			}

			return null;
		}
        bool ThereIsNoPlayerUsingKeyboard()
		{
			return FindPlayerUsingKeyboard() == null;
		}


		void OnDeviceDetached( InputDevice inputDevice )
		{
			var player = FindPlayerUsingJoystick( inputDevice );
			if (player != null)
			{
				RemovePlayer( player );
			}
		}

        
		PlayerLobbyControls CreatePlayer( InputDevice inputDevice )
		{
				// Pop a position off the list. We'll add it back if the player is removed.
				var gameObject = (GameObject) Instantiate( playerPrefab, new Vector3(0,0.5f,0), Quaternion.identity );
				var player = gameObject.GetComponent<PlayerLobbyControls>();

				if (inputDevice == null)
				{
					// We could create a new instance, but might as well reuse the one we have
					// and it lets us easily find the keyboard player.
					player.Actions = keyboardListener;
				}
				else
				{
					// Create a new instance and specifically set it to listen to the
					// given input device (joystick).
					var actions = PlayerActions.CreateWithJoystickBindings();
					actions.Device = inputDevice;

					player.Actions = actions;
				}
                player.lobby = this;
				players.Add( player );
                Debug.Log("Added player. There are " + players.Count + " Players.");
				return player;

		}
        public void RemovePlayer( PlayerLobbyControls player )
		{
            
			players.Remove( player );
			player.Actions = null;
			Destroy( player.gameObject );
            Debug.Log("Removed player. There are " + players.Count + " Players.");
		}
}
