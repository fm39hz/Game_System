using GameSystem.Core.Data;

namespace GameSystem.Core.Component.DamageSystem;

public interface IHurtBox
{
	public void UpdateCollision(int frame);

	public void TakeDamage(DamageData damage);
}