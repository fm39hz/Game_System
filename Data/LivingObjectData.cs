using System.Collections.Generic;
using GameSystem.Component.DamageSystem;

namespace GameSystem.Data.Instance;

public class LivingObjectData : ObjectData
{
	public List<Effect> EffetedEffects { get; set; }
	public float Health { get; set; }

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