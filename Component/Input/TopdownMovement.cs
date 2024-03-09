using GameSystem.Abstraction;
using GameSystem.Data.Constant;
using Godot;

namespace GameSystem.Component.InputManagement;

public partial class TopdownMovement : InputManager, IDirectionalInput
{
	public Vector2 GetMovementVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector = InputMapped.GetVector();
		}
		return inputVector;
	}

	public Vector2 GetJumpVector(Vector2 inputVector)
	{
		throw new NotImplementedException();
	}
}