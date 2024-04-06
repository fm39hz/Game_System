using GameSystem.Core.Utils;
using GameSystem.Core.Utils.Factory;
using Godot;
using InputManager = GameSystem.Core.Component.InputManagement.InputManager;

namespace GameSystem.Core.Object.Root.Concrete;

public abstract partial class Player : CreatureRoot
{
	public InputManager InputHandler { get; set; }
	public Camera2D View { get; set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		InputHandler = InputManagerFactory.CreateInputManager(Body!.MotionMode);
		AddChild(InputHandler);
	}

	public override void _Ready()
	{
		base._Ready();
		View = Body!.GetFirstChild<Camera2D>();
	}
}