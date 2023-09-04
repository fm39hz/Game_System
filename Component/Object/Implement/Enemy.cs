using Godot;
using GameSystem.Component.Object.Composition;
using GameSystem.Utils;
namespace GameSystem.Component.Object.Implement;

public partial class Enemy : Creature
{
	[Export] public Creature ChasingTarget { get; set; }
  public Area2D TargetingZone { get; set; }
  public override void _Ready()
    {
      base._Ready();
      TargetingZone = this.GetFirstChild<Area2D>();
    }
}
