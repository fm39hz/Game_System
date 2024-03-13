using GameSystem.Core.Component.InputManagement.Interface;
using GameSystem.Core.Object.Root.Concrete.Base;
using Godot;

namespace GameSystem.Core.Component.InputManagement.Base;

public abstract partial class BaseInputManager : Node, IDirectionalInput
{
	[Signal] public delegate void ActionKeyPressedEventHandler();

	[Signal] public delegate void MovementKeyPressedEventHandler(bool isPressed);

	protected BasePlayer? Compositor { get; set; }
	protected bool IsMoveable { get; set; }

	public abstract Vector2 GetMovementVector(Vector2 inputVector);

	public abstract Vector2 GetJumpVector(Vector2 inputVector);
}