using Godot;
using System;
using GameSystem.Data.Instance;
using GameSystem.Component.Animation;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Manager;

namespace GameSystem.Component.Object.Directional;
	[GlobalClass]
	/// <summary>
	/// Object động, có State Machine & Animation
	/// </summary>
	public partial class DynamicObject : BaseObject{
		/// <summary>
		/// Kiểm soát signal từ input
		/// </summary>
		public InputManager InputManager { get; protected set; }
		/// <summary>
		/// Sprite Sheet của đối tượng
		/// </summary>
		public SpriteSheet Sheet { get; protected set; }
		/// <summary>
		/// State Machine của đối tượng
		/// </summary>
		public StateMachine StateMachine { get; protected set; }
		/// <summary>
		/// Metadata, chứa thông tin về State ID, hướng nhìn của object, Animation có loop hay không,...
		/// </summary>
		public ObjectData Information { get; protected set; }
		[Export] public bool FourDirectionAnimation { get; protected set; } = true;
		public override void _EnterTree(){
			Sheet = GetFirstChildOfType<SpriteSheet>();
			InputManager = GetFirstChildOfType<InputManager>();
			}
		public override void _Ready(){
			StateMachine = GetFirstChildOfType<StateMachine>();
			Information = new(){
				IsFourDirection = FourDirectionAnimation,
				};
			}
		public override void _PhysicsProcess(double delta){
			UpdateMetadata();
			ActiveAnimation();
			MoveAndSlide();
			}
		/// <summary>
		/// Cập nhật Metadata của đối tượng
		/// </summary>
		protected void UpdateMetadata(){
			try {
				Information.CurrentState = StateMachine.CurrentState;
					if (!Velocity.IsEqualApprox(Vector2.Zero)){
						Information.SetDirection(Velocity);
						}
				}
			catch (NullReferenceException CurrentStateMissing){
				GD.Print("Không thể tìm thấy State hiện tại của đối tượng: \'" + Name + "\'");
				throw CurrentStateMissing;
				}
			}
		public void Transition(){
			Information.Transitioning = !Information.Transitioning;
			}
		/// <summary>
		/// Animate Sprite Sheet dựa trên thông tin lấy được từ method UpdateMetadata
		/// </summary>
		protected void ActiveAnimation(){
			try {
				var _state = StateMachine.CurrentState;
				var _frame = _state.Frame;
					Sheet.Animate(_frame, Information);
				}
			catch (NullReferenceException NullRef){
				throw NullRef;
				}
			}
		}
 