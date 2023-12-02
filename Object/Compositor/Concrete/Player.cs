using GameSystem.Component.InputManagement;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Object.Compositor.Concrete;

[GlobalClass]
public partial class Player : CreatureCompositor
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
		View = Decorator.GetFirstChild<Camera2D>();
	}
}
