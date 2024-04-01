using GameSystem.Core.Data.Constant;
using Godot;

namespace GameSystem.Core.Component.InputManagement.Concrete;

public partial class TopdownMovement : InputManager
{
	public override Vector2 GetMovementVector(Vector2 inputVector)
	{
		if (TargetAudience!.Information!.IsMoveable)
		{
			inputVector = InputMapped.GetVector();
		}
		return inputVector;
	}

	public override Vector2 GetJumpVector(Vector2 inputVector)
	{
		throw new NotImplementedException();
	}
}