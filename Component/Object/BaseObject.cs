using Godot;

namespace GameSystem.Component.Object;

[GlobalClass]
public partial class BaseObject : CharacterBody2D
{
	/// <summary>
	/// Condition allow Object to Move
	/// </summary>
	public bool IsMoveable { get; set; } = true;
}