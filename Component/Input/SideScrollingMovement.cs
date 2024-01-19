using Godot;
using GameSystem.Data.Constant;
using GameSystem.VirtualInstance;

namespace GameSystem.Component.InputManagement;

public partial class SideScrollingMovement : InputManager, IDirectionalInput
{
	public Vector2 GetMovementVector(Vector2 inputVector)
	{
		if (IsMoveable)
		{
			inputVector.X = InputMapped.GetHorizontalAxis();
		}
		return inputVector;
	}
}