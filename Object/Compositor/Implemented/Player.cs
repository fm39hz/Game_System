using GameSystem.Component.Manager;
using GameSystem.Component.Object.Compositor;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Object.Compositor.Implemented;

public partial class Player : CreatureCompositor
{
	public InputManager InputHandler { get; set; }
	public Camera2D View { get; set; }
	public override void _Ready()
	{
		base._Ready();
		InputHandler = this.GetFirstChild<InputManager>();
		View = Composition.GetFirstChild<Camera2D>();
	}
}