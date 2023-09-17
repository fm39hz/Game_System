using GameSystem.Component.Object.Compositor;
using GameSystem.Data.Global;
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
		Modulate = Colors.Green;
	}

	public override void _ExitTree()
	{
		foreach (var _item in ((CreatureData)Compositor.Information).ShapePool)
		{
			_item.Value.Dispose();
		}
	}

	public void UpdateCollision(int frame)
	{
		GetTree().DebugCollisionsHint = GlobalStatus.GetDebugInfo();
		this.RemoveAllChild();
		foreach (var (_frame, _collisionPolygon2D) in ((CreatureData)Compositor.Information).ShapePool)
		{
			if (_frame == frame)
			{
				AddChild(_collisionPolygon2D);
			}
		}
	}

	public void TakeDamage(DamageData damage)
	{
		((CreatureData)Compositor.Information).TakeDamage(damage);
	}
}