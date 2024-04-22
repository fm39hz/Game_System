namespace GameSystem.Core.Component.FiniteStateMachine;

public interface IState
{
	public void RunningState(double delta);
}