using GameSystem.Data;

namespace GameSystem.Component.Animation;

public interface ISpriteSheet
{
	/// <summary>
	///     Run the SpriteSheetPlayer based on the data provided
	/// </summary>
	/// <param name="objectData">Owner Data</param>
	public void Animate(ObjectData objectData);

	protected void SetFrame(int firstFrame, int nextFrame, double frameSpeed, bool isLoop);
}