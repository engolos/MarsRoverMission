namespace MarsRoverMission.DOMAIN.Concretes
{
    using System.Collections.Generic;
    using MarsRoverMission.DOMAIN.Abstract;

    public class Plateau : IPlateau
    {
        /// <summary> Gets or sets the plateau coordinates. </summary>
        public PlateauCoordinates PlateauCoordinates { get; set; }

        /// <summary> Gets or sets the rover states. </summary>
        public List<RoverState> RoverStates { get; set; } = new List<RoverState>();
    }
}
