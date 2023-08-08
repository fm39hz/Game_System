using GameSystem.Component.DamageSystem;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.Object.Directional;

[GlobalClass]
public partial class LivingObject : DynamicObject
{
	public new LivingObjectData Information { get; set; }
	public HurtBox Hurtbox { get; set; }
}