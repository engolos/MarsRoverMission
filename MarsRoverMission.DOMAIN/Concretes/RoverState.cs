namespace MarsRoverMission.DOMAIN.Concretes
{
    using MarsRoverMission.COMMON.Enums;
    using MarsRoverMission.DOMAIN.Abstract;

    public class RoverState : IRoverState
    {
        /// <summary> Gets or sets the x position. </summary>
        public int XPosition { get; set; }

        /// <summary> Gets or sets the y position. </summary>
        public int YPosition { get; set; }

        /// <summary> Gets or sets the direction. </summary>
        public Directions Direction { get; set; }
    }
}
