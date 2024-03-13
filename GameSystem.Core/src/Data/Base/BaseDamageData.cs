using GameSystem.Core.Component.DamageSystem.Base;
using GameSystem.Core.Object.PhysicsBody.Base;
using Godot;

namespace GameSystem.Core.Data.Base;

public partial class BaseDamageData : Node
{
	[Export] public float Value { get; set; }
	public List<BaseCreature> Target { get; set; } = new();
	public List<BaseEffect> EffectsValue { get; set; } = new();
}