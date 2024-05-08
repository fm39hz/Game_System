﻿using GameSystem.Data;
using GameSystem.Utils.Singleton;
using Godot;

namespace GameSystem.Component.Animation;

[GlobalClass]
public partial class SpriteSheet : Sprite2D, ISpriteSheet
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
	///     Real frame counter
	/// </summary>
	protected double FrameCounter { get; set; }

	public void Animate(ObjectData objectData)
	{
		var _currentState = objectData.CurrentState;
		var _frameData = _currentState.Frame;
		var _direction = objectData.Direction.GetDirectionAsNumber(); //Get Owner Direction
		var _firstFrame = _frameData.Length * _direction++;           //Set the First frame of animation
		var _nextFrame = _frameData.Length * _direction;              //Get the end frame

		SetFrame(_firstFrame, _nextFrame, _frameData.Speed, _currentState.IsLoop);
		if (CurrentFrame < _firstFrame || CurrentFrame >= _nextFrame)
		{
			CurrentFrame = _firstFrame; //Move the frame to the next position
		}
		EmitSignal(SignalName.PolygonChanged, Frame);
		FrameCoords = new Vector2I(CurrentFrame, _currentState.Id);
	}

	public void SetFrame(int firstFrame, int nextFrame, double frameSpeed, bool isLoop)
	{
		if (firstFrame <= CurrentFrame && CurrentFrame < nextFrame)
		{
			FrameCounter += GlobalStatus.GetResponseTime(); //Create realtime frame counter
		}
		if (!(FrameCounter >= 60 * GlobalStatus.GetResponseTime() / frameSpeed)) return;
		if (CurrentFrame == nextFrame - 1)
		{
			if (!isLoop)
			{
				EmitSignal(SignalName.AnimationFinished);
			}
			CurrentFrame = firstFrame; //Reset when reach the last frame
		}
		else if (CurrentFrame < nextFrame)
		{
			CurrentFrame++; //Increase frame when frame counter end
		}
		FrameCounter = 0; //Reset frame counter
	}
}