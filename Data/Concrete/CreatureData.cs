namespace GameSystem.Core.Data.Concrete;

public class CreatureData : Data.CreatureData
{
	public override void TakeDamage(DamageData damage)
	{
		Health -= damage.Value;
		foreach (var _effect in damage.EffectsValue)
		{
			EffetedEffects.Add(_effect);
			_effect.Apply();
		}
	}
}