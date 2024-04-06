namespace Prototype.GameSystem.Component.FiniteStateMachine;
public interface IControllableState 
{ 
	public void ResetCondition();
	public void SetCondition(bool condition);
}
