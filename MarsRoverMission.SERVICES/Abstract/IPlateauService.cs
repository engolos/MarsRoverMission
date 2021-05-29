namespace MarsRoverMission.SERVICES.Abstract
{
    using MarsRoverMission.DOMAIN.Concretes;

    public interface IPlateauService
    {
        Plateau SetInitialCoordinates(PlateauCoordinates plateauCoordinates);

        PlateauCoordinates GetPlateauCoordinates(string coordinates);
    }
}
