
using InControl;


public class PlayerActions : PlayerActionSet
{
	public PlayerAction ActionTop;
	public PlayerAction ActionLeft;
	public PlayerAction ActionRight;
	public PlayerAction ActionBottom;
	public PlayerAction LLeft;
	public PlayerAction LRight;
	public PlayerAction LUp;
	public PlayerAction LDown;
	public PlayerAction RRight;
	public PlayerAction RLeft;
	public PlayerAction RUp;
	public PlayerAction RDown;
	public PlayerAction LTrigger;
	public PlayerAction RTrigger;
	public PlayerTwoAxisAction LeftStick;
	public PlayerTwoAxisAction RightStick;
	//public PlayerAction Mouse;



	public PlayerActions()
	{
		ActionTop = CreatePlayerAction( "Triangle" );
		ActionLeft = CreatePlayerAction( "Square" );
		ActionRight = CreatePlayerAction( "Circle" );
		ActionBottom = CreatePlayerAction( "X" );
		LUp = CreatePlayerAction( "LUp" );
		LDown = CreatePlayerAction( "LDown" );
		LLeft = CreatePlayerAction( "LLeft" );
		LRight = CreatePlayerAction( "LRight");
		RUp = CreatePlayerAction( "RUp" );
		RDown = CreatePlayerAction( "RDown" );
		RLeft = CreatePlayerAction( "RLeft" );
		RRight = CreatePlayerAction( "RRight");
		LTrigger = CreatePlayerAction( "Left Trigger");
		RTrigger = CreatePlayerAction( "Right Trigger");
		LeftStick = CreateTwoAxisPlayerAction( LLeft, LRight, LDown, LUp );
		RightStick = CreateTwoAxisPlayerAction( RLeft, RRight, RDown, RUp );
	}


	public static PlayerActions CreateWithKeyboardBindings()
	{
		var actions = new PlayerActions();

		actions.ActionTop.AddDefaultBinding( Key.A );
		actions.ActionLeft.AddDefaultBinding( Key.S );
		actions.ActionRight.AddDefaultBinding( Key.D );
		actions.ActionBottom.AddDefaultBinding( Key.F );

		actions.LUp.AddDefaultBinding( Key.UpArrow );
		actions.LDown.AddDefaultBinding( Key.DownArrow );
		actions.LLeft.AddDefaultBinding( Key.LeftArrow );
		actions.LRight.AddDefaultBinding( Key.RightArrow );

		//actions.Mouse.AddDefaultBinding(Mouse);
		return actions;
	}


	public static PlayerActions CreateWithJoystickBindings()
	{
		var actions = new PlayerActions();

		actions.ActionBottom.AddDefaultBinding( InputControlType.Action1 );
		actions.ActionRight.AddDefaultBinding( InputControlType.Action2 );
		actions.ActionLeft.AddDefaultBinding( InputControlType.Action3 );
		actions.ActionTop.AddDefaultBinding( InputControlType.Action4 );

		actions.LUp.AddDefaultBinding( InputControlType.LeftStickUp );
		actions.LDown.AddDefaultBinding( InputControlType.LeftStickDown );
		actions.LLeft.AddDefaultBinding( InputControlType.LeftStickLeft );
		actions.LRight.AddDefaultBinding( InputControlType.LeftStickRight );

		actions.LUp.AddDefaultBinding( InputControlType.DPadUp );
		actions.LDown.AddDefaultBinding( InputControlType.DPadDown );
		actions.LLeft.AddDefaultBinding( InputControlType.DPadLeft );
		actions.LRight.AddDefaultBinding( InputControlType.DPadRight );

		actions.RUp.AddDefaultBinding( InputControlType.RightStickUp );
		actions.RDown.AddDefaultBinding( InputControlType.RightStickDown );
		actions.RLeft.AddDefaultBinding( InputControlType.RightStickLeft );
		actions.RRight.AddDefaultBinding( InputControlType.RightStickRight);

		actions.LTrigger.AddDefaultBinding(InputControlType.LeftTrigger);
		actions.RTrigger.AddDefaultBinding(InputControlType.RightTrigger);

		return actions;
	}
}


