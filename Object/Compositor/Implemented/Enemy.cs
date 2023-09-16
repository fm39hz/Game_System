using Godot;
using GameSystem.Component.Object.Composition;
using GameSystem.Component.Object.Compositor;
using GameSystem.Utils;
using Godot.Collections;

namespace GameSystem.Component.Object.Implemented;

[GlobalClass]
public partial class Enemy : CreatureCompositor
{
	[Export] public Array<Creature> Target { get; private set; }
	public Area2D TargetingZone { get; set; }

	public override void _Ready()
	{
		base._Ready();
		TargetingZone = this.GetFirstChild<Area2D>();
	}
}