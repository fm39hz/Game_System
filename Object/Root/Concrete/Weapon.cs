using GameSystem.Component.DamageSystem;
using GameSystem.Data;
using GameSystem.Object.PhysicsBody;
using Godot;

namespace GameSystem.Object.Root.Concrete;

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