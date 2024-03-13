using GameSystem.Core.Component.InputManagement.Base;
using GameSystem.Core.Component.InputManagement.Concrete;
using Godot;

namespace GameSystem.Core.Utils.Factory;

public static class InputManagerFactory
{
	public static BaseInputManager CreateInputManager(CharacterBody2D.MotionModeEnum mode)
	{
		return mode switch
		{
			CharacterBody2D.MotionModeEnum.Floating => new TopdownMovement(),
			CharacterBody2D.MotionModeEnum.Grounded => new SideScrollingMovement(),
			_ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "Cannot have another motion mode")
		};
	}
}