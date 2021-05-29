namespace MarsRoverMission.SERVICES.Concretes
{
    using System;

    using MarsRoverMission.COMMON.Constants;
    using MarsRoverMission.COMMON.Enums;
    using MarsRoverMission.COMMON.Extensions;
    using MarsRoverMission.DOMAIN.Concretes;
    using MarsRoverMission.SERVICES.Abstract;

    public class RoverService : IRoverService
    {
        public RoverState GetRoverPositions(string roverPosition)
        {
            var XPosition = 0;
            var yPosition = 0;
            var direction = Directions.N;

            try
            {
                if (IsValidateRoverPositions(roverPosition))
                {
                    var roverPositions = roverPosition.Split(' ');

                    XPosition = int.Parse(roverPositions[0]);
                    yPosition = int.Parse(roverPositions[1]);
                    direction = roverPositions[2].GetEnumValue<Directions>();
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new RoverState
            {
                XPosition = XPosition,
                YPosition = yPosition,
                Direction = direction
            };
        }

        public string GetRoverCurrentState(RoverState roverState)
        {
            return string.Format("{0} {1} {2}", roverState.XPosition, roverState.YPosition, roverState.Direction);
        }

        private bool IsValidateRoverPositions(string roverPosition)
        {
            return roverPosition.IsNotNull() && roverPosition.Length == PlateauInputsValidity.RoverPositionLength;
        }
    }
}