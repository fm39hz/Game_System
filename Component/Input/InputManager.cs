using System;
using Godot;
using GameSystem.Data.Global;
using GameSystem.Data.Instance;
using GameSystem.Object.Compositor.Implemented;

namespace GameSystem.Component.InputManagement;

public partial class InputManager : Node
{
	[Signal]
	public delegate void MovementKeyPressedEventHandler(bool isPressed);

	[Signal]
	public delegate void ActionKeyPressedEventHandler();

	private Player Compositor { get; set; }
	private bool IsMoveable { get; set; }

	public override void _EnterTree()
	{
		IsMoveable = true;
		try
		{
			Compositor = GetParentOrNull<Player>();
		}
		catch (NullReferenceException)
		{
			GD.Print("InputManager phải được đặt trong PlayerCompositor");
			throw;
		}
	}

	public override void _UnhandledKeyInput(InputEvent @event)
	{
		if (@event is InputEventKey _eventKey && _eventKey.IsPressed())
		{
			switch (_eventKey.Keycode)
			{
				case Key.Escape:
					GetTree().Quit();
					break;
				case Key.F3:
					GlobalStatus.ToggleDebugMode();
					break;
			}
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Compositor.Information is CreatureData _information)
		{
			IsMoveable = _information.IsMoveable;
		}
		var _up = Input.IsActionPressed("ui_up");
		var _down = Input.IsActionPressed("ui_down");
		var _left = Input.IsActionPressed("ui_left");
		var _right = Input.IsActionPressed("ui_right");
		if (IsMoveable)
		{
			EmitSignal(SignalName.MovementKeyPressed, _up || _down || _left || _right);
		}
		if (Input.IsActionJustPressed("ui_accept"))
		{
			EmitSignal(SignalName.ActionKeyPressed);
		}
	}

	public Vector2 TopDownVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		}
		return inputVector;
	}
	public Vector2 SideScrollingVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector.X = Input.GetAxis("ui_left", "ui_right");
		}
		return inputVector;
	}
}