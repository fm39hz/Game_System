using GameSystem.Data;

namespace GameSystem.Component.DamageSystem;

public interface IHurtBox
{
	public void UpdateCollision(int frame);

	public void TakeDamage(DamageData damage);
}