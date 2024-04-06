using GameSystem.Core.Data;
using GameSystem.Core.Data.Constant;
using GameSystem.Core.Object.Root.Concrete;
using GameSystem.Core.Utils.Singleton;
using Godot;

namespace GameSystem.Core.Component.InputManagement;

public partial class InputManager : Node, IDirectionalInput, IContainerized
{
	[Signal] public delegate void ActionKeyPressedEventHandler();

	[Signal] public delegate void MovementKeyPressedEventHandler(bool isPressed);

	public Player TargetAudience { get; set; }
	public void InitData()
	{
		TargetAudience = GetParent<Player>();
	}

	public void UpdateData(double delta)
	{
		if (TargetAudience!.Information!.IsMoveable)
		{
			EmitSignal(
				SignalName.MovementKeyPressed, 
				InputMapped.IsPressed(InputMappedEnum.Up) ||
				InputMapped.IsPressed(InputMappedEnum.Down) ||
				InputMapped.IsPressed(InputMappedEnum.Left) ||
				InputMapped.IsPressed(InputMappedEnum.Right)
				);
		}
		if (InputMapped.IsJustPressed(InputMappedEnum.Action))
		{
			EmitSignal(SignalName.ActionKeyPressed);
		}
	}

	public virtual Vector2 GetMovementVector(Vector2 inputVector) => new();

	public virtual Vector2 GetJumpVector(Vector2 inputVector) => new();

	public override void _EnterTree()
	{
		InitData();
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
}
