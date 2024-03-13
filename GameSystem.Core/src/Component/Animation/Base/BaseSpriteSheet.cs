using GameSystem.Core.Component.Animation.Interface;
using GameSystem.Core.Data.Base;
using Godot;

namespace GameSystem.Core.Component.Animation.Base;

public abstract partial class BaseSpriteSheet : Sprite2D, ISpriteSheet
{
	/// <summary>
	///     Signal trigger when the Sheet finished
	/// </summary>
	[Signal]
	public delegate void AnimationFinishedEventHandler();

	/// <summary>
	///     Signal trigger when the collision must changed
	/// </summary>
	[Signal]
	public delegate void PolygonChangedEventHandler(int frame);


	/// <summary>
	///     The current frame, show by int
	/// </summary>
	public int CurrentFrame { get; protected set; }

	/// <summary>
	///     Realframe counter
	/// </summary>
	protected double FrameCounter { get; set; }

	public abstract void Animate(BaseObjectData objectData);

	public abstract void SetFrame(int firstFrame, int nextFrame, double frameSpeed, bool isLoop);
}