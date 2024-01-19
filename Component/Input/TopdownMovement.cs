using Godot;
using GameSystem.Data.Constant;
using GameSystem.VirtualInstance;

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
}