namespace MarsRoverMission.DOMAIN.Abstract
{
    using System.Collections.Generic;

    using MarsRoverMission.DOMAIN.Concretes;

    public interface IPlateau
    {
        /// <summary> Gets or sets the plateau coordinates. </summary>
        public PlateauCoordinates PlateauCoordinates { get; set; }

        /// <summary> Gets or sets the rover states. </summary>
        public List<RoverState> RoverStates { get; set; }
    }
}
