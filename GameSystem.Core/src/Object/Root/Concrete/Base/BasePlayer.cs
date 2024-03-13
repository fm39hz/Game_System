using GameSystem.Core.Component.InputManagement.Base;
using GameSystem.Core.Object.Root.Base;
using GameSystem.Core.Utils;
using GameSystem.Core.Utils.Factory;
using Godot;

namespace GameSystem.Core.Object.Root.Concrete.Base;

public abstract partial class BasePlayer : BaseCreatureRoot
{
	public BaseInputManager? InputHandler { get; set; }
	public Camera2D? View { get; set; }

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