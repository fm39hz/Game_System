using GameSystem.Core.Component.Animation.Base;
using GameSystem.Core.Component.FiniteStateMachine.Base;
using GameSystem.Core.Data.Base;
using GameSystem.Core.Object.Root.Interface;
using Godot;

namespace GameSystem.Core.Object.Root.Base;

public abstract partial class BaseRoot<TData, TBody> : Node2D, IObjectRoot
	where TData : BaseObjectData where TBody : Node
{
	[Export] public required Node PhysicsBody { protected get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;

	protected TBody? Body
	{
		get { return PhysicsBody as TBody; }
		set { PhysicsBody = value!; }
	}

	protected BaseStateMachine? StateMachine { get; set; }
	protected BaseSpriteSheet? SpriteSheet { get; set; }
	public TData? Information { get; protected set; }

	public abstract void PlayAnimation();

	public abstract void InitInformation();

	public abstract void UpdateInformation();
}