using GameSystem.Core.Data.Base;

namespace GameSystem.Core.Component.DamageSystem.Interface;

public interface IHurtBox
{
	public void UpdateCollision(int frame);

	public void TakeDamage(BaseDamageData damage);
}