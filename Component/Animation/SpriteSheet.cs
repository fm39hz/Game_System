using GameSystem.BaseClass;
using Godot;
using GameSystem.Data.Global;

namespace GameSystem.Component.Animation;

[GlobalClass]
public partial class SpriteSheet : Sprite2D
{
	/// <summary>
	/// Signal trigger when the Sheet finished
	/// </summary>
	[Signal] public delegate void AnimationFinishedEventHandler();

	/// <summary>
	/// The current frame, show by int
	/// </summary>
	private int CurrentFrame { get; set; }

	/// <summary>
	/// Realframe counter
	/// </summary>
	private double FrameCounter { get; set; }

	/// <summary>
	/// Run the SpriteSheetPlayer based on the data provided
	/// </summary>
	/// <param name="objectData">Owner Data</param>
	public void Animate(ObjectData objectData)
	{
		var _relativeResponseTime = GetNode<GlobalData>("/root/GlobalData").RelativeResponseTime;
		var _frameInfor = objectData.CurrentState.Frame;
		var _direction = objectData.Direction.GetDirectionAsNumber();	//Get Owner Direction
		var _firstFrame = _frameInfor.Length * _direction++;				//Set the First frame of animation
		var _nextFrame = _frameInfor.Length * _direction;				//Get the end frame
			if (objectData.IsTransitioning)
			{
				_nextFrame = _frameInfor.Length * _direction + _frameInfor.TransitionFrame;
			}
			if (_firstFrame <= CurrentFrame && CurrentFrame < _nextFrame)
			{
				FrameCounter += _relativeResponseTime;						//Create realtime frame counter
			}
			if (FrameCounter >= 60 * _relativeResponseTime / _frameInfor.Speed)
			{
				if (CurrentFrame == _nextFrame - 1)
				{
					if (!objectData.CurrentState.IsLoop)
					{
						EmitSignal(SignalName.AnimationFinished);
					}
					CurrentFrame = _firstFrame;								//Reset when reach the last frame
				}
				else if (CurrentFrame < _nextFrame)
				{
					CurrentFrame++;											//Increase frame when frame counter end
				}
				FrameCounter = 0;											//Reset frame counter
			}
			if (CurrentFrame < _firstFrame || CurrentFrame >= _nextFrame)
			{
				CurrentFrame = _firstFrame;									//Move the frame to the next position
			}
		FrameCoords = new Vector2I(CurrentFrame, objectData.CurrentState.Id);
	}
}