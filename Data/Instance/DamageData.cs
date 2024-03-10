using GameSystem.Component.DamageSystem;
using GameSystem.Object.PhysicsBody;
using Godot;

namespace GameSystem.Data.Instance;

[GlobalClass]
public partial class DamageData : Node
{
	[Export] public float Value { get; set; }
	public List<Creature> Target { get; set; } = new();
	public List<Effect> EffectsValue { get; set; } = new();
}