using GameSystem.Component.Object.Compositor;
using Godot;

namespace GameSystem.Component.Object.Composition;

[GlobalClass]
public partial class Creature : CharacterBody2D
{
	
	public CreatureCompositor Compositor { get; set; }
	public override void _Ready()
	{
		Compositor = GetParent<CreatureCompositor>();
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}