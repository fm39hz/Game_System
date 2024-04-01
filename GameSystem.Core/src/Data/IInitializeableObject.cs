namespace GameSystem.Core.Data;

public interface IInitializeableObject
{
	public void InitData();

	public void UpdateData(double delta);
}