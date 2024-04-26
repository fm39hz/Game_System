namespace GameSystem.Core.Component.DamageSystem;

public interface IApplicable
{
	public void Apply();

	public void Discard();
}