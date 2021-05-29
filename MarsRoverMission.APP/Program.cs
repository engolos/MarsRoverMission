namespace MarsRoverMission.APP
{
    using System;

    using MarsRoverMission.SERVICES.Abstract;
    using MarsRoverMission.SERVICES.Concretes;

    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        #region Fields

        private static IPlateauService _plateauService;
        private static IRoverService _roverService;
        private static ICommandService _commandService;

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mars!");

            Configure();
            Run();

            Console.WriteLine("Good By Mars...!");
        }

        private static ServiceProvider Configure()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
          .AddSingleton<IPlateauService, PlateauService>()
          .AddSingleton<IRoverService, RoverService>()
          .AddSingleton<ICommandService, CommandService>()
          .BuildServiceProvider();

            _plateauService = serviceProvider.GetService<IPlateauService>();
            _roverService = serviceProvider.GetService<IRoverService>();
            _commandService = serviceProvider.GetService<ICommandService>();

            return serviceProvider;
        }

        public static void Run()
        {
            #region Set plateau data

            Console.WriteLine("Plateau Coordinate Sizes :");
            var plateauSizes = Console.ReadLine();
            var plateauCoordinates = _plateauService.GetPlateauCoordinates(plateauSizes);
            var plateau = _plateauService.SetInitialCoordinates(plateauCoordinates);

            #endregion

            var addRoverFlag = true;
            var roverId = 1;

            while (addRoverFlag)
            {
                #region Set rover data

                Console.WriteLine($"{roverId}" + ". Rover position :");
                var roverInitialState = Console.ReadLine();
                var rover = _roverService.GetRoverPositions(roverInitialState);

                #endregion

                #region Set rover commands

                Console.WriteLine($"{roverId}" + ". Rover commands :");
                var commands = Console.ReadLine();
                var roverCommands = _commandService.GetRoverCommands(commands);

                #endregion

                #region Execute Commands

                rover = _commandService.Execute(rover, roverCommands, plateau.PlateauCoordinates.XCoordinate, plateau.PlateauCoordinates.YCoordinate);

                #endregion

                plateau.RoverStates.Add(rover);
                roverId++;

                Console.WriteLine("Do you want to add rover : y or n");
                addRoverFlag = Console.ReadLine() == "y";
            }

            foreach (var rover in plateau.RoverStates)
            {
                Console.WriteLine(_roverService.GetRoverCurrentState(rover));
            }
        }
    }
}
