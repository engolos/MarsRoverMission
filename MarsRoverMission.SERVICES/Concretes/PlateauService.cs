namespace MarsRoverMission.SERVICES.Concretes
{
    using System;

    using MarsRoverMission.COMMON.Constants;
    using MarsRoverMission.COMMON.Extensions;
    using MarsRoverMission.DOMAIN.Concretes;
    using MarsRoverMission.SERVICES.Abstract;

    public class PlateauService : IPlateauService
    {
        public Plateau SetInitialCoordinates(PlateauCoordinates plateauCoordinates)
        {
            return new Plateau
            {
                PlateauCoordinates = plateauCoordinates
            };
        }

        public PlateauCoordinates GetPlateauCoordinates(string coordinates)
        {
            var xCoordinate = 0;
            var yCoordinate = 0;

            try
            {
                if (IsValidatePlateauCoordinates(coordinates))
                {
                    xCoordinate = int.Parse(coordinates.Split(' ')[0]);
                    yCoordinate = int.Parse(coordinates.Split(' ')[1]);
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException();
            }


            return new PlateauCoordinates
            {
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            };
        }

        private bool IsValidatePlateauCoordinates(string coordinates)
        {
            return coordinates.IsNotNull() && coordinates.Length == PlateauInputsValidity.PlateauSizesLength;
        }
    }
}