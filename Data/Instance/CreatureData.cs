using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using Godot;

namespace GameSystem.Data.Instance;

public class CreatureData : ObjectData
{
	/// <summary>
	/// Condition allow Root to Move
	/// </summary>
	public bool IsMoveable { get; set; } = true;

	public List<Effect> EffetedEffects { get; set; } = new();
	public Dictionary<int, CollisionPolygon2D> ShapePool { get; set; } = new();
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