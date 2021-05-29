namespace MarsRoverMission.DOMAIN.Abstract
{
    using MarsRoverMission.COMMON.Enums;

    public interface IRoverState
    {
        /// <summary> Gets or sets the x position. </summary>
        public int XPosition { get; set; }

        /// <summary> Gets or sets the y position. </summary>
        public int YPosition { get; set; }

        /// <summary> Gets or sets the direction. </summary>
        public Directions Direction { get; set; }
    }
}
