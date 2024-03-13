using GameSystem.Core.Component.DamageSystem.Base;
using GameSystem.Core.Data.Base;
using GameSystem.Core.Object.PhysicsBody.Base;
using GameSystem.Core.Object.Root.Base;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root.Concrete.Base;

public abstract partial class BaseWeapon : BaseItemRoot
{
	[Signal]
	public delegate void ApplyDamageEventHandler(BaseDamageData damage);

	public BaseHitbox? Hitbox { get; set; }
	public BaseDamageData? Damage { get; set; }

	public override void _EnterTree()
	{
		PhysicsBody = GetOwner<BaseItem>();
		Damage = this.GetFirstChild<BaseDamageData>();
	}
}