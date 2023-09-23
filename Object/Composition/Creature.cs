using GameSystem.Object.Compositor;
using Godot;

namespace GameSystem.Object.Composition;

[GlobalClass]
public partial class Creature : CharacterBody2D
{
	public CreatureCompositor Compositor { get; set; }

	public override void _EnterTree()
	{
		Compositor = GetParent<CreatureCompositor>();
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}