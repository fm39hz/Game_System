using System;
using GameSystem.Data.Constant;
using GameSystem.Data.Global;
using GameSystem.Data.Instance;
using GameSystem.Object.Compositor.Concrete;
using Godot;

namespace GameSystem.Component.InputManagement;

public partial class InputManager : Node
{
	[Signal]
	public delegate void ActionKeyPressedEventHandler();

	[Signal]
	public delegate void MovementKeyPressedEventHandler(bool isPressed);

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
		if (@event is not InputEventKey _eventKey || !_eventKey.IsPressed())
		{
			return;
		}
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

	public override void _PhysicsProcess(double delta)
	{
		if (Compositor.Information is CreatureData _information)
		{
			IsMoveable = _information.IsMoveable;
		}
		var _up = InputMapping.IsPressed(MappedKey.Up);
		var _down = InputMapping.IsPressed(MappedKey.Down);
		var _left = InputMapping.IsPressed(MappedKey.Left);
		var _right = InputMapping.IsPressed(MappedKey.Right);
		if (IsMoveable)
		{
			EmitSignal(SignalName.MovementKeyPressed, _up || _down || _left || _right);
		}
		if (InputMapping.IsJustPressed(MappedKey.Action))
		{
			EmitSignal(SignalName.ActionKeyPressed);
		}
	}

	public Vector2 TopDownVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector = InputMapping.GetVector();
		}
		return inputVector;
	}

	public Vector2 SideScrollingVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector.X = InputMapping.GetHorizontalAxis();
		}
		return inputVector;
	}
}