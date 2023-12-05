using GameSystem.Component.DamageSystem;
using GameSystem.Object.PhysicsBody;
using GameSystem.Data.Instance;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Object.Root.Equipment;

[GlobalClass]
public partial class Weapon : ItemRoot
{
	[Signal]
	public delegate void ApplyDamageEventHandler(DamageData damage);

	public Hitbox Hitbox { get; set; }
	public DamageData Damage { get; set; }

	public override void _EnterTree()
	{
		PhysicsBody = GetOwner<Item>();
		Damage = this.GetFirstChild<DamageData>();
	}
}