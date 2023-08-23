using Godot;
using GameSystem.Component.Object.Composition;

namespace GameSystem.Component.Object.Implement;

public partial class Enemy : Creature {
	public Creature ChasingTarget { get; set; }
}