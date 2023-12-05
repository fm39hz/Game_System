using GameSystem.Component.InputManagement;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Object.Root.Concrete;

[GlobalClass]
public partial class Player : CreatureRoot
{
	public InputManager InputHandler { get; set; }
	public Camera2D View { get; set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		InputHandler = new();
		AddChild(InputHandler);
	}

	public override void _Ready()
	{
		base._Ready();
		View = PhysicsBody.GetFirstChild<Camera2D>();
	}
}
