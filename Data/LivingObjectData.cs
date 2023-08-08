using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using Godot;

namespace GameSystem.Data.Instance;

[GlobalClass]
public partial class LivingObjectData : ObjectData
{
	public List<Effect> EffetedEffects { get; set; }
	[Export] public float Health { get; set; }

	public LivingObjectData()
	{
		EffetedEffects = new List<Effect>();
		Health = 0;
	}

	public void TakeDamage(DamageData damage)
	{
		Health -= damage.Value;
		foreach (var effect in damage.EffectsValue)
		{
			EffetedEffects.Add(effect);
			effect.Apply();
		}
	}
}