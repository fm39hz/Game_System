using Godot;
using Player = GameSystem.Core.Object.Root.Concrete.Player;

namespace GameSystem.Core.Component.InputManagement;

public abstract partial class InputManager : Node, IDirectionalInput
{
	[Signal] public delegate void ActionKeyPressedEventHandler();

	[Signal] public delegate void MovementKeyPressedEventHandler(bool isPressed);

	protected Player? Compositor { get; set; }
	protected bool IsMoveable { get; set; }

	public abstract Vector2 GetMovementVector(Vector2 inputVector);

	public abstract Vector2 GetJumpVector(Vector2 inputVector);
}