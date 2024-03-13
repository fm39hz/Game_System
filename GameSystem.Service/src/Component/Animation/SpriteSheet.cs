using GameSystem.Core.Component.Animation.Base;
using GameSystem.Core.Data.Base;
using GameSystem.Core.Utils.Singleton;
using Godot;

namespace GameSystem.Service.Component.Animation;

[GlobalClass]
public sealed partial class SpriteSheet : BaseSpriteSheet
{
	public override void Animate(BaseObjectData objectData)
	{
		var _currentState = objectData.CurrentState!;
		var _frameData = _currentState.Frame;
		var _direction = objectData.Direction!.GetDirectionAsNumber(); //Get Owner Direction
		var _firstFrame = _frameData!.Length * _direction++;           //Set the First frame of animation
		var _nextFrame = _frameData.Length * _direction;               //Get the end frame

		SetFrame(_firstFrame, _nextFrame, _frameData.Speed, _currentState.IsLoop);
		if (CurrentFrame < _firstFrame || CurrentFrame >= _nextFrame)
		{
			CurrentFrame = _firstFrame; //Move the frame to the next position
		}
		EmitSignal(BaseSpriteSheet.SignalName.PolygonChanged, Frame);
		FrameCoords = new Vector2I(CurrentFrame, _currentState.Id);
	}

	public override void SetFrame(int firstFrame, int nextFrame, double frameSpeed, bool isLoop)
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
				EmitSignal(BaseSpriteSheet.SignalName.AnimationFinished);
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