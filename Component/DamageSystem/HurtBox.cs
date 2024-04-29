using GameSystem.Data;
using GameSystem.Object.Root;
using GameSystem.Utils;
using GameSystem.Utils.Singleton;
using Godot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D, IHurtBox
{
	protected CreatureRoot Root { get; set; }

	public virtual void UpdateCollision(int frame)
	{
		GetTree().DebugCollisionsHint = GlobalStatus.Debugging();
		this.RemoveAllChild();
		foreach (var _item in Root.Information.ShapePool)
		{
			if (_item.Key != frame) continue;
			AddChild(_item.Value);
			return;
		}
	}

	public virtual void TakeDamage(DamageData damage)
	{
		Root.Information.TakeDamage(damage);
	}

	public override void _EnterTree()
	{
		Root = GetOwner<CreatureRoot>();
		CollisionLayer = 2;
		CollisionMask = 2;
		Modulate = Colors.Green;
	}

	public override void _ExitTree()
	{
		foreach (var _item in Root.Information.ShapePool)
		{
			_item.Value.Dispose();
		}
	}
}