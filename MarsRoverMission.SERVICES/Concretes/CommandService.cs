namespace MarsRoverMission.SERVICES.Concretes
{
    using MarsRoverMission.COMMON.Enums;
    using MarsRoverMission.COMMON.Extensions;
    using MarsRoverMission.DOMAIN.Concretes;
    using MarsRoverMission.SERVICES.Abstract;

    public class CommandService : ICommandService
    {
        public RoverState Execute(RoverState roverState, char[] commands, int maxX, int maxY)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case (COMMON.Constants.RoverCommands.TurnLeft):
                        TurnLeft(roverState);
                        break;
                    case (COMMON.Constants.RoverCommands.TurnRight):
                        TurnRight(roverState);
                        break;
                    case (COMMON.Constants.RoverCommands.Move):
                        Move(roverState, maxX, maxY);
                        break;
                    default:
                        break;
                }
            }

            return roverState;
        }

        public char[] GetRoverCommands(string commands)
        {
            char[] result = new char[commands.Trim().Length];
            if (IsValidateCommands(commands))
                result = commands.ToCharArray();
            return result;
        }

        private bool IsValidateCommands(string commands)
        {
            return commands.IsNotNull();
        }

        private void TurnLeft(RoverState roverState)
        {
            roverState.Direction = (roverState.Direction - 1) < Directions.N ? Directions.W : roverState.Direction - 1;
        }

        private void TurnRight(RoverState roverState)
        {
            roverState.Direction = (roverState.Direction + 1) > Directions.W ? Directions.N : roverState.Direction + 1;
        }

        private void Move(RoverState roverState, int maxX, int maxY)
        {
            if (roverState.Direction == Directions.N)
            {
                if (maxY > roverState.YPosition)  //To stay in the Plateau
                    roverState.YPosition++;
            }
            else if (roverState.Direction == Directions.E)
            {
                if (maxX > roverState.XPosition)
                    roverState.XPosition++;
            }
            else if (roverState.Direction == Directions.S)
            {
                if (roverState.YPosition > 0)
                    roverState.YPosition--;
            }
            else if (roverState.Direction == Directions.W)
            {
                if (roverState.XPosition > 0)
                    roverState.XPosition--;
            }
        }

    }
}
