namespace MarsRoverMission.SERVICES.Abstract
{
    using MarsRoverMission.DOMAIN.Concretes;

    public interface IRoverService
    {
        RoverState GetRoverPositions(string roverPosition);

        string GetRoverCurrentState(RoverState roverState);
    }
}
