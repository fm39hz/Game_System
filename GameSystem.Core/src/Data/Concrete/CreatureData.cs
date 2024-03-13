using GameSystem.Core.Data.Base;

namespace GameSystem.Core.Data.Concrete;

public class CreatureData : BaseCreatureData
{
	public override void TakeDamage(BaseDamageData damage)
	{
		Health -= damage.Value;
		foreach (var _effect in damage.EffectsValue)
		{
			EffetedEffects.Add(_effect);
			_effect.Apply();
		}
	}
}