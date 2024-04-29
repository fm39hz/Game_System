using System;
using GameSystem.Data.Constant;
using Godot;

namespace GameSystem.Component.InputManagement.Concrete;

public partial class SideScrollingMovement : InputManager, IDirectionalInput
{
	public Vector2 GetMovementVector(Vector2 inputVector)
	{
		if (TargetAudience.Information.IsMoveable)
		{
			inputVector.X = InputMapped.GetHorizontalAxis();
		}
		return inputVector;
	}

	public Vector2 GetJumpVector(Vector2 inputVector)
	{
		throw new NotImplementedException();
	}
}