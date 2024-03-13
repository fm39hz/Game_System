using Godot;

namespace GameSystem.Core.Data.Interface;

public interface IDirectionalData
{
	public void SetDirection(int input);

	public void SetDirection(Vector2 input);

	public int GetDirectionAsNumber();
}