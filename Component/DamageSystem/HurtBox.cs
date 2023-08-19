using GameSystem.Component.Object.Compositor;
using GameSystem.Data.Instance;
using Godot;
using Godot.Collections;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D
{
	public CreatureCompositor Compositor { get; set; }

	public override void _EnterTree()
	{
		Compositor = GetOwner<CreatureCompositor>();
		CollisionLayer = 2;
		CollisionMask = 2;
		Modulate = Colors.Red;
	}
    
	public void UpdateCollision(Array<Vector2[]> polygons, Vector2I bitmapSize)
	{
		foreach (var _polygon in GetChildren())
		{
			RemoveChild(_polygon);
		}
		foreach (var _polygon in polygons)
		{
			for (var _i = 0; _i < _polygon.Length; _i++)
			{
				_polygon[_i] -= Position;
			}
			var _collisionPolygon = new CollisionPolygon2D
			{
				Polygon = _polygon
			};
			AddChild(_collisionPolygon);
		}
	}
	public void TakeDamage(DamageData damage)
	{
		if (Compositor.Information is CreatureData _information)
		{
			foreach (var _target in damage.Target)
			{
				_information.TakeDamage(damage);
			}
		}
	}
}