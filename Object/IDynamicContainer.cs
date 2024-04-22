namespace Prototype.GameSystem.Object;

public interface IDynamicContainer : IContainer
{
	/// <summary>
	/// Update method for dynamic containerized object
	/// </summary>
	/// <param name="delta">Godot's delta time</param>
	public void UpdateData(double delta);
}