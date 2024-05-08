using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using Godot;

namespace GameSystem.Data;

public partial class CreatureData : ObjectData, ICreatureData
{
	/// <summary>
	///     Condition allow Root to Move
	/// </summary>
	[Export] public float Health { get; set; }

	[Export] public bool IsMoveable { get; set; } = true;

	public List<Effect> EffetedEffects { get; init; } = [];
	public Dictionary<int, CollisionPolygon2D> ShapePool { get; set; } = new();

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