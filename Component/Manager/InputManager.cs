using System;
using Godot;
using GameSystem.Component.Object.Compositor;

namespace GameSystem.Component.Manager;

[GlobalClass]
public partial class InputManager : Node
{
	[Signal]
	public delegate void MovementKeyPressedEventHandler(bool isPressed);

	[Signal]
	public delegate void ActionKeyPressedEventHandler();

	private CreatureCompositor Compositor { get; set; }

	public override void _Ready()
	{
		try
		{
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
		if (@event is InputEventKey _eventKey)
		{
			if (_eventKey.IsPressed())
			{
				if (_eventKey.Keycode == Key.Escape)
				{
					GetTree().Quit();
				}

				if (_eventKey.Keycode == Key.F3)
				{
					GetTree().DebugCollisionsHint = !GetTree().DebugCollisionsHint;
				}
			}
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		var _up = Input.IsActionPressed("ui_up");
		var _down = Input.IsActionPressed("ui_down");
		var _left = Input.IsActionPressed("ui_left");
		var _right = Input.IsActionPressed("ui_right");
		if (Compositor.Information.IsMoveable)
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
		if (Compositor.Information.IsMoveable)
		{
			inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		}

		return inputVector;
	}
}