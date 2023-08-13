using GameSystem.Component.Object.Composition;
using GameSystem.Component.Object.Compositor;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D
{
	public CreatureCompositor Target { get; set; }

	public override void _EnterTree()
	{
		Target = GetOwner<CreatureCompositor>();
		CollisionLayer = 2;
		CollisionMask = 2;
	}

	public void TakeDamage(DamageData damage)
	{
		foreach (var _target in damage.Target)
		{
			if (Target.Information is CreatureData _information)
			{
				_information.TakeDamage(damage);
			}
		}
	}
}