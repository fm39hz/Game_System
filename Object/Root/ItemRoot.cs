using GameSystem.Data;
using GameSystem.Object.PhysicsBody;
using Godot;

namespace GameSystem.Object.Root;

[GlobalClass]
public partial class ItemRoot : ObjectRoot<ItemData, Item>;