using GameSystem.Core.Component.DamageSystem;
using GameSystem.Core.Data;
using GameSystem.Core.Object.PhysicsBody;
using Godot;

namespace GameSystem.Core.Object.Root.Concrete;

public partial class Weapon : ItemRoot
{
	[Signal] public delegate void ApplyDamageEventHandler(DamageData damage);

	[Export] public DamageData Damage { get; set; }

	public Hitbox Hitbox { get; set; }

	public override void _EnterTree()
	{
		PhysicsBody = GetOwner<Item>();
	}
}