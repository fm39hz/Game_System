using GameSystem.Component.DamageSystem;
using GameSystem.Data.Instance;
using GameSystem.Component.Object.Directional;
using Godot;

namespace GameSystem.Component.Object.Equipment;

[GlobalClass]
public partial class Weapon : DynamicObject
{
	[Signal]
	public delegate void ApplyDamageEventHandler(DamageData damage);

	public Hitbox Hitbox { get; set; }
	public DamageData Damage { get; set; }
	public DynamicObject Target { get; set; }

	public override void _EnterTree()
	{
		Target = GetOwner<DynamicObject>();
		Damage = GetFirstChildOfType<DamageData>();
	}
}