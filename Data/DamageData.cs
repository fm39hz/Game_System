using System.Collections.Generic;
using GameSystem.Core.Component.DamageSystem;
using GameSystem.Core.Object.PhysicsBody;
using Godot;

namespace GameSystem.Core.Data;

public partial class DamageData : Resource
{
	[Export] public float Value { get; set; }
	public List<Creature> Target { get; set; } = [];
	public List<Effect> EffectsValue { get; set; } = [];
}