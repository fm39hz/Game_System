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
		if (Target.Information is CreatureData _information)
		{
			foreach (var _target in damage.Target)
			{
				_information.TakeDamage(damage);
			}
		}
	}
}