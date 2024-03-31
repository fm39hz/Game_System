using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root.Concrete;

public abstract partial class Enemy : CreatureRoot
{
	public Player? Target { get; private set; }
	public Area2D? TargetingZone { get; set; }

	public override void _Ready()
	{
		base._Ready();
		TargetingZone = this.GetFirstChild<Area2D>();
	}
}