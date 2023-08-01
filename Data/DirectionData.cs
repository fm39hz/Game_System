using Godot;
using GameSystem.Utility.Direction;
using System.Collections.Generic;
using System;

namespace GameSystem.Data.Instance;
	public class DirectionData{
		public Dictionary<int, Vector2> DirectionContainer { get; private set; }
		public Dictionary<int, float> RadiantContainer { get; private set; }
		public int AsNumber { get; private set; }
		public Vector2 AsVector { get; private set; }
		public float AsRadiant { get; private set; }
		public DirectionData(){
			DirectionContainer = new(8){
				{ 0, Vector2.Down },
				{ 1, Vector2.Right },
				{ 2, Vector2.Up },
				{ 3, Vector2.Left },
				{ 4, Vector2.Down + Vector2.Right },
				{ 5, Vector2.Right + Vector2.Up },
				{ 6, Vector2.Up + Vector2.Left },
				{ 7, Vector2.Left + Vector2.Down }
				};
			var _pi = MathF.PI;
			RadiantContainer = new(8){
				{ 0, _pi / 2 },
				{ 1, 0 },
				{ 2, -_pi / 2 },
				{ 3, 2 * _pi },
				{ 4, _pi / 4 },
				{ 5, -_pi / 4 },
				{ 6, -3 * _pi / 4 },
				{ 7, 3 * _pi / 4 },
				};
			}
		public void SetDirection(int input){
			AsNumber = input;
			AsVector = DirectionConverter.ToDirection(input);
			AsRadiant = DirectionConverter.ToRadiant(input);
			}
		public void SetDirection(Vector2 input){
			AsVector = input;
			AsNumber = DirectionConverter.ToDirection(input);
			AsRadiant = DirectionConverter.ToRadiant(AsNumber);
			}
		}
