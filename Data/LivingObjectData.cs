using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using Godot;

namespace GameSystem.Data.Instance;

[GlobalClass]
public partial class LivingObjectData : ObjectData
{
	public List<Effect> EffetedEffects { get; set; }
	[Export] public float Health { get; set; }

	public override void _EnterTree()
	{
		EffetedEffects = new();
	}

	public void TakeDamage(DamageData damage)
	{
		Health -= damage.Value;
		foreach (var _effect in damage.EffectsValue)
		{
			EffetedEffects.Add(_effect);
			_effect.Apply();
		}
	}
}