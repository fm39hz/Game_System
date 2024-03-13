using GameSystem.Core.Data.Interface;
using Godot;

namespace GameSystem.Core.Data.Base;

public abstract class BaseDirectionalData : IDirectionalData
{
	public int AsNumber { get; protected set; }
	public Vector2 AsVector { get; protected set; }
	public float AsRadiant { get; protected set; }
	public bool IsTransitioning { get; set; }
	public bool IsFourDirection { get; set; }

	public abstract void SetDirection(int input);

	public abstract void SetDirection(Vector2 input);

	public abstract int GetDirectionAsNumber();
}