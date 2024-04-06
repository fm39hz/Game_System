using System.Collections.Generic;
using GameSystem.Core.Component.DamageSystem;
using GameSystem.Core.Object.PhysicsBody;
using Godot;

namespace GameSystem.Core.Data;

public partial class DamageData : Node
{
	[Export] public float Value { get; set; }
	public List<Creature> Target { get; set; } = new();
	public List<Effect> EffectsValue { get; set; } = new();
}