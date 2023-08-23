using GameSystem.Component.DamageSystem;
using GameSystem.Component.Object.Composition;
using GameSystem.Data.Instance;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Component.Object.Compositor.Equipment;

[GlobalClass]
public partial class Weapon : Item {
	[Signal]
	public delegate void ApplyDamageEventHandler(DamageData damage);

	public Hitbox Hitbox { get; set; }
	public DamageData Damage { get; set; }
	public Item Target { get; set; }

	public override void _EnterTree() {
		Target = GetOwner<Item>();
		Damage = this.GetFirstChildOfType<DamageData>();
	}
}