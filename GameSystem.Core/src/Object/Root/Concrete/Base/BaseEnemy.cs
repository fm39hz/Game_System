using GameSystem.Core.Object.Root.Base;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root.Concrete.Base;

public abstract partial class BaseEnemy : BaseCreatureRoot
{
	public BasePlayer? Target { get; private set; }
	public Area2D? TargetingZone { get; set; }

	public override void _Ready()
	{
		base._Ready();
		TargetingZone = this.GetFirstChild<Area2D>();
	}
}