using Godot;

namespace GameSystem.Core.Component.DamageSystem;

public interface IHitbox
{
	public void HurtboxEnter(Area2D target);

	public void HurtBoxExit(Area2D target);
}