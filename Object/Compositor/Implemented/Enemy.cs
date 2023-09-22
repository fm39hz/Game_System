using Godot;
using GameSystem.Component.Object.Compositor;
using GameSystem.Utils;

namespace GameSystem.Object.Compositor.Implemented;

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