using GameSystem.Core.Component.InputManagement.Concrete;
using Godot;
using InputManager = GameSystem.Core.Component.InputManagement.InputManager;

namespace GameSystem.Core.Utils.Factory;

public static class InputManagerFactory
{
	public static InputManager CreateInputManager(CharacterBody2D.MotionModeEnum mode)
	{
		return mode switch
		{
			CharacterBody2D.MotionModeEnum.Floating => new TopdownMovement(),
			CharacterBody2D.MotionModeEnum.Grounded => new SideScrollingMovement(),
			_ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "Cannot have another motion mode")
		};
	}
}