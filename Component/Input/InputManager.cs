using System;
using GameSystem.Data.Constant;
using GameSystem.Data.Global;
using GameSystem.Data.Instance;
using GameSystem.Object.Root.Concrete;
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
		var _up = InputMapped.IsPressed(InputMappedEnum.Up);
		var _down = InputMapped.IsPressed(InputMappedEnum.Down);
		var _left = InputMapped.IsPressed(InputMappedEnum.Left);
		var _right = InputMapped.IsPressed(InputMappedEnum.Right);
		if (IsMoveable)
		{
			EmitSignal(SignalName.MovementKeyPressed, _up || _down || _left || _right);
		}
		if (InputMapped.IsJustPressed(InputMappedEnum.Action))
		{
			EmitSignal(SignalName.ActionKeyPressed);
		}
	}

	public Vector2 TopDownVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector = InputMapped.GetVector();
		}
		return inputVector;
	}

	public Vector2 SideScrollingVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector.X = InputMapped.GetHorizontalAxis();
		}
		return inputVector;
	}
}