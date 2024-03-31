using GameSystem.Core.Component.DamageSystem;
using Godot;

namespace GameSystem.Core.Data;

public abstract class CreatureData : ObjectData, ICreatureData
{
	/// <summary>
	///     Condition allow Root to Move
	/// </summary>
	public bool IsMoveable { get; set; } = true;

	public List<Effect> EffetedEffects { get; init; } = [];
	public Dictionary<int, CollisionPolygon2D> ShapePool { get; init; } = new();
	[Export] public float Health { get; set; }

	public abstract void TakeDamage(DamageData damage);
}