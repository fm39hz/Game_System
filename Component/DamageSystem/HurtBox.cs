using GameSystem.Data.Global;
using GameSystem.Data.Instance;
using GameSystem.Object.Root;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D
{
	private CreatureRoot Root { get; set; }

	public override void _EnterTree()
	{
		Root = GetOwner<CreatureRoot>();
		CollisionLayer = 2;
		CollisionMask = 2;
		Modulate = Colors.Green;
	}

	public override void _ExitTree()
	{
		foreach (var _item in ((CreatureData)Root.Information).ShapePool)
		{
			_item.Value.Dispose();
		}
	}

	public void UpdateCollision(int frame)
	{
		GetTree().DebugCollisionsHint = GlobalStatus.Debugging();
		this.RemoveAllChild();
		foreach (var (_frame, _collisionShape) in ((CreatureData)Root.Information).ShapePool)
		{
			if (_frame != frame) continue;
			AddChild(_collisionShape);
			return;
		}
	}

	public void TakeDamage(DamageData damage)
	{
		((CreatureData)Root.Information).TakeDamage(damage);
	}
}