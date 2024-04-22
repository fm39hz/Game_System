namespace GameSystem.Component.FiniteStateMachine;

public interface IControllable
{
	public void ResetCondition();

	public void SetCondition(bool condition);
}