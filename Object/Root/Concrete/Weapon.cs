using GameSystem.Core.Component.DamageSystem;
using GameSystem.Core.Data;
using GameSystem.Core.Object.PhysicsBody;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root.Concrete;

public abstract partial class Weapon : ItemRoot
{
	[Signal]
	public delegate void ApplyDamageEventHandler(DamageData damage);

	public Hitbox? Hitbox { get; set; }
	public DamageData? Damage { get; set; }

	public override void _EnterTree()
	{
		PhysicsBody = GetOwner<Item>();
		Damage = this.GetFirstChild<DamageData>();
	}
}