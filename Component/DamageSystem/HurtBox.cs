using GameSystem.Component.Object.Compositor;
using GameSystem.Data.Instance;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D
{
	private CreatureCompositor Compositor { get; set; }

	public override void _EnterTree()
	{
		Compositor = GetOwner<CreatureCompositor>();
		CollisionLayer = 2;
		CollisionMask = 2;
		Modulate = Colors.Red;
	}

	public void UpdateCollision(int frame)
	{
		this.RemoveAllChild();
		foreach (var (_frame, _collisionPolygon2D) in ((CreatureData)Compositor.Information).ShapePool)
		{
			if (_frame == frame)
			{
				AddChild(_collisionPolygon2D, true);
			}
		}
	}

	public void TakeDamage(DamageData damage)
	{
		foreach (var _target in damage.Target)
		{
			((CreatureData)Compositor.Information).TakeDamage(damage);
		}
	}
}