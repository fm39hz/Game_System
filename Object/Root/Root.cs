using System;
using GameSystem.Core.Component.Animation;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Data;
using Godot;

namespace GameSystem.Core.Object.Root;

public partial class Root<TData, TBody> : Node2D where TData : ObjectData where TBody : Node
{
	[Export] public Node PhysicsBody { private get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;

	public TBody Body
	{
		get
		{
			if (PhysicsBody is TBody _body)
			{
				return _body;
			}
			throw new InvalidCastException("Body must set with TBody type");
		}
		set { PhysicsBody = value; }
	}

	public TData Information { get; set; }

	public StateMachine StateMachine { get; set; }
	public SpriteSheet SpriteSheet { get; set; }
}