using GameSystem.Utils;
using GameSystem.Utils.Factory;
using Godot;
using InputManagement_InputManager = GameSystem.Component.InputManagement.InputManager;

namespace GameSystem.Object.Root.Concrete;

public partial class Player : CreatureRoot
{
	public InputManagement_InputManager InputHandler { get; set; }
	public Camera2D View { get; set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		InputHandler = InputManagerFactory.CreateInputManager(Body.MotionMode);
		AddChild(InputHandler);
	}

	public override void _Ready()
	{
		base._Ready();
		View = Body.GetFirstChild<Camera2D>();
	}
}