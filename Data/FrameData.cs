namespace GameSystem.Data.Instance;
    /// <summary>
    /// Chứa thông tin về frame của 1 đối tượng
    /// </summary>
    public class FrameData{
        /// <summary>
        /// Số frame của Animation
        /// </summary>
        /// <value></value>
        public int Length { get; set; }
        /// <summary>
        /// Tốc độ của Animation
        /// </summary>
        /// <value></value>
        public double Speed { get; set; }
        public FrameData(int frameNumber, double speed){
            Length = frameNumber;
            Speed = speed;
            }
        }
