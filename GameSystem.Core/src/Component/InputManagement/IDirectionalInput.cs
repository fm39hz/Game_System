using Godot;

namespace GameSystem.Core.Component.InputManagement;

public interface IDirectionalInput
{
	public Vector2 GetMovementVector(Vector2 inputVector);

	public Vector2 GetJumpVector(Vector2 inputVector);
}