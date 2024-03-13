using GameSystem.Core.Data.Base;

namespace GameSystem.Core.Component.Animation.Interface;

public interface ISpriteSheet
{
	/// <summary>
	///     Run the SpriteSheetPlayer based on the data provided
	/// </summary>
	/// <param name="objectData">Owner Data</param>
	public void Animate(BaseObjectData objectData);

	protected void SetFrame(int firstFrame, int nextFrame, double frameSpeed, bool isLoop);
}