using GameSystem.Core.Data;
using Godot;

namespace GameSystem.Core.Component.Animation;

public abstract partial class SpriteSheet : Sprite2D, ISpriteSheet
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

	public abstract void Animate(ObjectData objectData);

	public abstract void SetFrame(int firstFrame, int nextFrame, double frameSpeed, bool isLoop);
}