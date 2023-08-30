using System;
using Godot;
using GameSystem.Component.Object.Compositor;
using GameSystem.Data.Instance;

namespace GameSystem.Component.Manager;

[GlobalClass]
public partial class InputManager : Node
{
	[Signal]
	public delegate void MovementKeyPressedEventHandler(bool isPressed);

	[Signal]
	public delegate void ActionKeyPressedEventHandler();

	private CreatureCompositor Compositor { get; set; }
	private bool IsMoveable { get; set; }

	public override void _Ready()
	{
		try
		{
			IsMoveable = true;
			Compositor = GetOwner<CreatureCompositor>();
		}
		catch (NullReferenceException)
		{
			GD.Print("InputManager phải được đặt trong CreatureCompositor");
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
					#if DEBUG
					GetTree().DebugCollisionsHint = !GetTree().DebugCollisionsHint;
					#endif
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
}