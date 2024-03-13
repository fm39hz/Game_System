using GameSystem.Core.Component.DamageSystem.Base;
using GameSystem.Core.Data.Interface;
using Godot;

namespace GameSystem.Core.Data.Base;

public abstract class BaseCreatureData : BaseObjectData, ICreatureData
{
	/// <summary>
	///     Condition allow Root to Move
	/// </summary>
	public bool IsMoveable { get; set; } = true;

	public List<BaseEffect> EffetedEffects { get; init; } = [];
	public Dictionary<int, CollisionPolygon2D> ShapePool { get; init; } = new();
	[Export] public float Health { get; set; }

	public abstract void TakeDamage(BaseDamageData damage);
}