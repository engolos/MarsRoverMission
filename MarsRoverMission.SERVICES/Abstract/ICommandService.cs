namespace MarsRoverMission.SERVICES.Abstract
{
    using MarsRoverMission.DOMAIN.Concretes;

    public interface ICommandService
    {
        RoverState Execute(RoverState roverState, char[] commands, int maxX, int maxY);

        char[] GetRoverCommands(string commands);
    }
}
