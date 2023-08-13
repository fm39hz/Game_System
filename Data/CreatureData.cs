using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using GameSystem.BaseClass;
using Godot;

namespace GameSystem.Data.Instance;

[GlobalClass]
public class CreatureData : ObjectData
{
	public List<Effect> EffetedEffects { get; set; } = new();
	[Export] public float Health { get; set; }
	
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