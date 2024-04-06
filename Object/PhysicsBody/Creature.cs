using Godot;
using CreatureRoot = GameSystem.Core.Object.Root.CreatureRoot;

namespace GameSystem.Core.Object.PhysicsBody;

[GlobalClass]
public abstract partial class Creature : CharacterBody2D
{
	public CreatureRoot Root { get; set; }

	public override void _EnterTree()
	{
		Root = GetParent<CreatureRoot>();
		MotionMode = MotionModeEnum.Floating;
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}