namespace GameSystem.Core.Component.FiniteStateMachine;

public interface IState
{
	public void EnteredMachine();

	public void UpdateCondition(double delta);

	public void RunningState(double delta);

	public void ExitMachine();
}