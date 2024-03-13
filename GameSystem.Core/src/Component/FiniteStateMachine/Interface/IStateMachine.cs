namespace GameSystem.Core.Component.FiniteStateMachine.Interface;

public interface IStateMachine
{
	protected void Init();

	protected void SelectState();

	protected void CheckingCondition();
}