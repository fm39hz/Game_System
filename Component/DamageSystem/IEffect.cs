namespace GameSystem.Core.Component.DamageSystem;

public interface IEffect
{
	public void Apply();

	public void Discard();
}