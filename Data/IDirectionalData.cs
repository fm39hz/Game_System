using Godot;

namespace GameSystem.Data;

public interface IDirectionalData
{
	public void SetDirection(int input);

	public void SetDirection(Vector2 input);

	public int GetDirectionAsNumber();
}