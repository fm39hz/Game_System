using Godot;
using GameSystem.Utils;

namespace GameSystem.Object.Compositor.Concrete;

[GlobalClass]
public partial class Enemy : CreatureCompositor
{
	public Player Target { get; private set; }
	public Area2D TargetingZone { get; set; }

	public override void _Ready()
	{
		base._Ready();
		TargetingZone = this.GetFirstChild<Area2D>();
	}
}