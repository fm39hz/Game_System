using GameSystem.Core.Data;
using GameSystem.Core.Object.PhysicsBody.Base;

namespace GameSystem.Core.Object.Root;

public partial class ItemRoot : ObjectRoot<ItemData, Item>
{
	public override void PlayAnimation()
	{
		throw new NotImplementedException();
	}

	public override void UpdateData(double delta)
	{
		throw new NotImplementedException();
	}

	public override void InitData()
	{
		throw new NotImplementedException();
	}
}