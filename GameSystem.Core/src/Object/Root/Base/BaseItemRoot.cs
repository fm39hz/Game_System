using GameSystem.Core.Data.Base;
using GameSystem.Core.Object.PhysicsBody.Base;

namespace GameSystem.Core.Object.Root.Base;

public partial class BaseItemRoot : BaseObjectRoot<BaseItemData, BaseItem>
{
	public override void PlayAnimation()
	{
		throw new NotImplementedException();
	}

	public override void UpdateInformation()
	{
		throw new NotImplementedException();
	}

	public override void InitInformation()
	{
		throw new NotImplementedException();
	}
}