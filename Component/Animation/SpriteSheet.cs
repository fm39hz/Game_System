using GameSystem.BaseClass;
using GameSystem.Component.DamageSystem;
using GameSystem.Component.Object.Compositor;
using Godot;
using GameSystem.Data.Global;
using GameSystem.Utils;
using Godot.Collections;

namespace GameSystem.Component.Animation;

[GlobalClass]
public partial class SpriteSheet : Sprite2D
{
	/// <summary>
	/// Signal trigger when the Sheet finished
	/// </summary>
	[Signal]
	public delegate void AnimationFinishedEventHandler();
	/// <summary>
	/// Signal trigger when the collision must changed	
	/// </summary>

	[Signal]
	public delegate void PolygonChangedEventHandler(Array<Vector2[]> polygons);

	/// <summary>
	/// The current frame, show by int
	/// </summary>
	private int CurrentFrame { get; set; }

	/// <summary>
	/// The current state, show by int
	/// </summary>
	private int CurrentState { get; set; }

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
		var _direction = objectData.Direction.GetDirectionAsNumber(); //Get Owner Direction
		var _firstFrame = _frameInfor.Length * _direction++;          //Set the First frame of animation
		var _nextFrame = _frameInfor.Length * _direction;             //Get the end frame
		CurrentState = objectData.CurrentState.Id;
		if (objectData.IsTransitioning)
		{
			_nextFrame = _frameInfor.Length * _direction + _frameInfor.TransitionFrame;
		}

		if (_firstFrame <= CurrentFrame && CurrentFrame < _nextFrame)
		{
			FrameCounter += _relativeResponseTime; //Create realtime frame counter
		}

		if (FrameCounter >= 60 * _relativeResponseTime / _frameInfor.Speed)
		{
			if (CurrentFrame == _nextFrame - 1)
			{
				if (!objectData.CurrentState.IsLoop)
				{
					EmitSignal(SignalName.AnimationFinished);
				}
				
				CurrentFrame = _firstFrame; //Reset when reach the last frame
			}
			else if (CurrentFrame < _nextFrame)
			{
				CurrentFrame++; //Increase frame when frame counter end
			}

			FrameCounter = 0; //Reset frame counter
		}

		if (CurrentFrame < _firstFrame || CurrentFrame >= _nextFrame)
		{
			CurrentFrame = _firstFrame; //Move the frame to the next position
		}

		UpdateSpritePolygon(); //Update Collision
		FrameCoords = new Vector2I(CurrentFrame, CurrentState);
	}

	public void UpdateSpritePolygon()
	{
		var _width = Texture.GetWidth() / Hframes;
		var _height = Texture.GetHeight() / Vframes;
		var _collumn = CurrentFrame * _width;
		if (CurrentFrame * _width > Texture.GetWidth())
		{
			_collumn -= Texture.GetWidth() * CurrentState;
		}

		var _position = new Vector2I(_collumn, CurrentState * _height);
		var _bitmap = new Bitmap();
		_bitmap.CreateFromImageAlpha(Texture.GetImage());
		var _polys = _bitmap.OpaqueToPolygons(new Rect2I(_position, _width, _height), 0.42f);
		
		EmitSignal(SignalName.PolygonChanged, _polys);
	}
}