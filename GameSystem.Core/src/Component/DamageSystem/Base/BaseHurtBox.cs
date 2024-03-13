using GameSystem.Core.Component.DamageSystem.Interface;
using GameSystem.Core.Data.Base;
using GameSystem.Core.Data.Concrete;
using GameSystem.Core.Object.Root.Base;
using GameSystem.Core.Utils;
using GameSystem.Core.Utils.Singleton;
using Godot;

namespace GameSystem.Core.Component.DamageSystem.Base;

public abstract partial class BaseHurtBox : Area2D, IHurtBox
{
	protected BaseCreatureRoot? Root { get; set; }

	public virtual void UpdateCollision(int frame)
	{
		GetTree().DebugCollisionsHint = GlobalStatus.Debugging();
		this.RemoveAllChild();
		foreach (var (_frame, _collisionShape) in ((CreatureData)Root!.Information!).ShapePool)
		{
			if (_frame != frame) continue;
			AddChild(_collisionShape);
			return;
		}
	}

	public virtual void TakeDamage(BaseDamageData damage)
	{
		((CreatureData)Root!.Information!).TakeDamage(damage);
	}

	public override void _EnterTree()
	{
		Root = GetOwner<BaseCreatureRoot>();
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