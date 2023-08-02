using System;
using Godot;

namespace GameSystem.Component.Object;
    [GlobalClass]
    /// <summary>
    /// Đối tượng Cơ sở của các đối tượng tương tác
    /// </summary>
    public partial class BaseObject : CharacterBody2D{
		/// <summary>
		/// Điều kiện quyết định đối tượng có được di chuyển hay không
		/// </summary>
		public bool IsMoveable { get; set; } = true;
		/// <summary>
		/// Trả về node con đầu tiên có type T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Node con đầu tiên có type T, hoặc null nếu không tìm thấy</returns>
		public T GetFirstChildOfType<T>() where T : Node{
			T targetChild = null;
				for (int i = 0; i < GetChildCount(); i++){
					if (GetChildOrNull<T>(i) != null){
						targetChild = GetChild<T>(i);
						break;
						}
					}
			return targetChild;
			}
		/// <summary>
		/// Trả về node đầu tiên có type T trong node Cha, ở cùng cấp với node hiện tại
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Node đầu tiên có type T ở cùng cấp, hoặc null nếu không tìm thấy</returns>
		public T GetFirstSiblingOfType<T>() where T : Node{
			var parent = GetParent();
			T targetSibling = null;
				for (int i = 0; i < parent.GetChildCount(); i++){
					if (parent.GetChildOrNull<T>(i) != null){
						targetSibling = parent.GetChild<T>(i);
						break;
						}
					}
			return targetSibling;
			}
        }