using GameSystem.Core.Utils;
using GameSystem.Core.Utils.Singleton;
using Godot;
using CreatureData = GameSystem.Core.Data.Concrete.CreatureData;
using CreatureRoot = GameSystem.Core.Object.Root.CreatureRoot;
using DamageData = GameSystem.Core.Data.DamageData;

namespace GameSystem.Core.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D, IHurtBox
{
	protected CreatureRoot Root { get; set; }

	public virtual void UpdateCollision(int frame)
	{
		GetTree().DebugCollisionsHint = GlobalStatus.Debugging();
		this.RemoveAllChild();
		foreach (var _item in Root!.Information!.ShapePool)
		{
			if (_item.Key != frame) continue;
			AddChild(_item.Value);
			return;
		}
	}

	public virtual void TakeDamage(DamageData damage)
	{
		((CreatureData)Root!.Information!).TakeDamage(damage);
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
		foreach (var _item in ((CreatureData)Root!.Information!).ShapePool)
		{
			_item.Value.Dispose();
		}
	}
}