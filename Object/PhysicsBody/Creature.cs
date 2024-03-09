using GameSystem.Object.Root;
using Godot;

namespace GameSystem.Object.PhysicsBody;

[GlobalClass]
public partial class Creature : CharacterBody2D
{
	public CreatureRoot? Root { get; set; }

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