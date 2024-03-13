using GameSystem.Core.Object.Root.Base;
using Godot;

namespace GameSystem.Core.Object.PhysicsBody.Base;

public abstract partial class BaseCreature : CharacterBody2D
{
	public BaseCreatureRoot? Root { get; set; }

	public override void _EnterTree()
	{
		Root = GetParent<BaseCreatureRoot>();
		MotionMode = MotionModeEnum.Floating;
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}