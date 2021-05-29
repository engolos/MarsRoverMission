namespace MarsRoverMission.TEST.RoverTest
{
    using System.Collections.Generic;

    using FluentAssertions;

    using MarsRoverMission.COMMON.Enums;
    using MarsRoverMission.COMMON.Extensions;
    using MarsRoverMission.DOMAIN.Concretes;
    using MarsRoverMission.SERVICES.Abstract;
    using MarsRoverMission.SERVICES.Concretes;

    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    public class RoverServicesTest
    {
        #region Fields

        private static IRoverService _roverService;

        #endregion

        #region Ctor

        public RoverServicesTest()
        {
            Configure();
        }

        #endregion

        [Theory]
        [InlineData("1 2 N")]
        [InlineData("3 3 E")]
        public void GetRoverPositions_Should_Create_RoverState(string input)
        {
            // Arrange
            var roverdata = input.Split(" ");

            var xPosition = int.Parse(roverdata[0]);
            var yPosition = int.Parse(roverdata[1]);
            var directions = roverdata[2].GetEnumValue<Directions>();

            var roverState = new RoverState
            {
                XPosition = xPosition,
                YPosition = yPosition,
                Direction = directions
            };

            // Act
            var result = _roverService.GetRoverPositions(input);
            // Assert
            result.Should().NotBeNull();
            result.XPosition.Should().Be(roverState.XPosition);
            result.YPosition.Should().Be(roverState.YPosition);
            result.Direction.Should().Be(roverState.Direction);
        }

        private static ServiceProvider Configure()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
          .AddSingleton<IRoverService, RoverService>()
          .BuildServiceProvider();

            _roverService = serviceProvider.GetService<IRoverService>();

            return serviceProvider;
        }
    }
}
