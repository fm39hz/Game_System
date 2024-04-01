using GameSystem.Core.Data;
using GameSystem.Core.Data.Concrete;
using GameSystem.Core.Data.Constant;
using GameSystem.Core.Object.Root.Concrete;
using GameSystem.Core.Utils.Singleton;
using Godot;

namespace GameSystem.Core.Component.InputManagement;

public abstract partial class InputManager : Node, IDirectionalInput, IInitializeableObject
{
	[Signal] public delegate void ActionKeyPressedEventHandler();

	[Signal] public delegate void MovementKeyPressedEventHandler(bool isPressed);

	protected Player? Compositor { get; set; }
	protected bool IsMoveable { get; set; }

	public abstract Vector2 GetMovementVector(Vector2 inputVector);

	public abstract Vector2 GetJumpVector(Vector2 inputVector);

	public override void _EnterTree()
	{
		InitializeData();
	}
	public override void _PhysicsProcess(double delta)
	{
		UpdateData(delta);
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


	public void InitializeData()
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

	public void UpdateData(double delta)
	{
		var _up = InputMapped.IsPressed(InputMappedEnum.Up);
		var _down = InputMapped.IsPressed(InputMappedEnum.Down);
		var _left = InputMapped.IsPressed(InputMappedEnum.Left);
		var _right = InputMapped.IsPressed(InputMappedEnum.Right);
		IsMoveable = Compositor!.Information!.IsMoveable;
		if (IsMoveable)
		{
			EmitSignal(SignalName.MovementKeyPressed, _up || _down || _left || _right);
		}
		if (InputMapped.IsJustPressed(InputMappedEnum.Action))
		{
			EmitSignal(SignalName.ActionKeyPressed);
		}
	}
}