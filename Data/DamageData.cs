using System.Collections.Generic;
using System.Dynamic;
using GameSystem.Component.DamageSystem;
using Godot;

namespace GameSystem.Data.Instance;

[GlobalClass]
public partial class DamageData : Node
{
	[Export] public float Value { get; set; }
	public List<DynamicObject> Target { get; set; }
	public List<Effect> EffectsValue { get; set; } = new();
}