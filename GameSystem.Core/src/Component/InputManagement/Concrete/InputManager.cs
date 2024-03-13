using GameSystem.Core.Component.InputManagement.Base;
using GameSystem.Core.Data.Concrete;
using GameSystem.Core.Data.Constant;
using GameSystem.Core.Object.Root.Concrete.Base;
using GameSystem.Core.Utils.Singleton;
using Godot;

namespace GameSystem.Core.Component.InputManagement.Concrete;

public abstract partial class InputManager : BaseInputManager
{
	public override void _EnterTree()
	{
		IsMoveable = true;
		try
		{
			Compositor = GetParentOrNull<BasePlayer>();
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
		if (Compositor!.Information is CreatureData _information)
		{
			IsMoveable = _information.IsMoveable;
		}
		var _up = InputMapped.IsPressed(InputMappedEnum.Up);
		var _down = InputMapped.IsPressed(InputMappedEnum.Down);
		var _left = InputMapped.IsPressed(InputMappedEnum.Left);
		var _right = InputMapped.IsPressed(InputMappedEnum.Right);
		if (IsMoveable)
		{
			EmitSignal(BaseInputManager.SignalName.MovementKeyPressed, _up || _down || _left || _right);
		}
		if (InputMapped.IsJustPressed(InputMappedEnum.Action))
		{
			EmitSignal(BaseInputManager.SignalName.ActionKeyPressed);
		}
	}
}