using GameSystem.Component.Object.Compositor;
using GameSystem.Data.Instance;
using Godot;
using Godot.Collections;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D
{
	public CreatureCompositor Compositor { get; set; }
	public CollisionPolygon2D Area { get; set; }

	public override void _EnterTree()
	{
		Compositor = GetOwner<CreatureCompositor>();
		AddChild(Area = new(), true);
		CollisionLayer = 2;
		CollisionMask = 2;
		Modulate = Colors.Red;
	}
    
	public void UpdateCollision(Array<Vector2[]> polygons)
	{
		foreach (var _polygon in polygons)
		{
			for (var _i = 0; _i < _polygon.Length; _i++)
			{
				_polygon[_i] += Compositor.SpriteSheet.Position;
			}

			Area.Polygon = _polygon;
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