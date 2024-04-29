using System;
using GameSystem.Component.InputManagement;
using GameSystem.Component.InputManagement.Concrete;
using Godot;

namespace GameSystem.Utils.Factory;

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