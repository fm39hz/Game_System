using GameSystem.Component.Manager;
using GameSystem.Component.Object.Composition;
using GameSystem.Component.Object.Compositor;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Object.Compositor.Implemented;

[GlobalClass]
public partial class Player : CreatureCompositor
{
	public InputManager InputHandler { get; set; }
	public Camera2D View { get; set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		InputHandler = this.GetFirstChild<InputManager>();
		View = Composition.GetFirstChild<Camera2D>();
	}
}