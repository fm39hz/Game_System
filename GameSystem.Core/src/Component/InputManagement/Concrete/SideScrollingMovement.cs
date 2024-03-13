using GameSystem.Core.Data.Constant;
using Godot;

namespace GameSystem.Core.Component.InputManagement.Concrete;

public partial class SideScrollingMovement : InputManager
{
	public override Vector2 GetMovementVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector.X = InputMapped.GetHorizontalAxis();
		}
		return inputVector;
	}

	public override Vector2 GetJumpVector(Vector2 inputVector)
	{
		throw new NotImplementedException();
	}
}