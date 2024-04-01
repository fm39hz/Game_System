namespace GameSystem.Core.Data;

public interface IInitializeableObject
{
	public void InitializeData();

	public void UpdateData(double delta);
}