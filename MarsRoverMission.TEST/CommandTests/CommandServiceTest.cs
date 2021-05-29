namespace MarsRoverMission.TEST.CommandTests
{
    using Xunit;
    using FluentAssertions;
    using MarsRoverMission.DOMAIN.Concretes;
    using MarsRoverMission.COMMON.Enums;
    using MarsRoverMission.COMMON.Extensions;
    using MarsRoverMission.SERVICES.Abstract;
    using Microsoft.Extensions.DependencyInjection;
    using MarsRoverMission.SERVICES.Concretes;

    public class CommandServiceTest
    {
        #region Fields

        private static ICommandService _commandService;

        #endregion

        #region Ctor

        public CommandServiceTest()
        {
            Configure();
        }

        #endregion

        [Theory]
        [InlineData(new string[] { "5 5", "1 2 N", "LMLMLMLMM" }, "1 3 N")]
        [InlineData(new string[] { "5 5", "3 3 E", "MMRMMRMRRM" }, "5 1 E")]
        public void Execute_CommandResult_Should_Be_Equal_Expexted(string[] input, string expected)
        {
            // Arrange
            var roverdata = input[1].Split(" ");

            var expecteddata = expected.Split(" ");

            var roverCommands = input[2].ToCharArray();

            var maxX = int.Parse(input[0].Split(" ")[0]);
            var maxY = int.Parse(input[0].Split(" ")[1]);


            var roverState = new RoverState
            {
                XPosition = int.Parse(roverdata[0]),
                YPosition = int.Parse(roverdata[1]),
                Direction = roverdata[2].GetEnumValue<Directions>()
            };

            var expectedRoverState = new RoverState
            {
                XPosition = int.Parse(expecteddata[0]),
                YPosition = int.Parse(expecteddata[1]),
                Direction = expecteddata[2].GetEnumValue<Directions>()
            };

            // Act
            var result = _commandService.Execute(roverState, roverCommands, maxX, maxY);
            // Assert
            result.Should().NotBeNull();
            result.Direction.Should().Be(expectedRoverState.Direction);
            result.XPosition.Should().Be(expectedRoverState.XPosition);
            result.YPosition.Should().Be(expectedRoverState.YPosition);
        }

        private static ServiceProvider Configure()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
          .AddSingleton<ICommandService, CommandService>()
          .BuildServiceProvider();

            _commandService = serviceProvider.GetService<ICommandService>();

            return serviceProvider;
        }
    }
}
