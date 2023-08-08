using GameSystem.Component.Object;
using GameSystem.Data.Instance;
using GameSystem.Component.Object.Directional;
using Godot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class HurtBox : Area2D
{
	public LivingObject Target { get; set; }

	public override void _EnterTree()
	{
		Target = GetOwner<LivingObject>();
		CollisionLayer = 2;
		CollisionMask = 2;
	}

	public void TakeDamage(DamageData damage)
	{
		foreach (var target in damage.Target)
		{
			if (Target.GetType().IsAssignableTo(target.GetType()))
			{
				Target.Information.TakeDamage(damage);
				return;
			}
		}
	}
}