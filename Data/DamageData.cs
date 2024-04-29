using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using GameSystem.Object.PhysicsBody;
using Godot;

namespace GameSystem.Data;

public partial class DamageData : Resource
{
	[Export] public float Value { get; set; }
	public List<Creature> Target { get; set; } = [];
	public List<Effect> EffectsValue { get; set; } = [];
}