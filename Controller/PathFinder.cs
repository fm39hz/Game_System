using Godot;
using GameSystem.Object.Compositor;
using System.Collections.Generic;

namespace GameSystem.Controller;

public class PathFinder
{
    public CreatureCompositor Object { get; set; }
    public Vector2 TargetLocation { get; set; }
    public Dictionary<Vector2, Vector2> Objectiles { get; set; }
}