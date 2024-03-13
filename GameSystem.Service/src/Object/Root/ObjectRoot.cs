using GameSystem.Core.Data.Base;
using GameSystem.Core.Object.Root.Base;
using Godot;

namespace GameSystem.Service.Object.Root;

[GlobalClass]
public abstract partial class ObjectRoot : BaseObjectRoot<BaseObjectData, Node2D>;