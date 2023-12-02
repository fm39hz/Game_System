using GameSystem.Object.Compositor;
using Godot;

namespace GameSystem.Object.Decorator;

[GlobalClass]
public partial class Creature : CharacterBody2D
{
	public CreatureCompositor Compositor { get; set; }

	public override void _EnterTree()
	{
		Compositor = GetParent<CreatureCompositor>();
		MotionMode = MotionModeEnum.Floating;
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}