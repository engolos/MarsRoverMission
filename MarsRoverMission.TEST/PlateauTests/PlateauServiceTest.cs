namespace MarsRoverMission.TEST.PlateauTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using MarsRoverMission.DOMAIN.Concretes;
    using MarsRoverMission.SERVICES.Abstract;
    using MarsRoverMission.SERVICES.Concretes;

    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    public class PlateauServiceTest
    {
        #region Fields

        private static IPlateauService _plateauService;

        #endregion

        #region Ctor

        public PlateauServiceTest()
        {
            Configure();
        }

        #endregion

        [Theory]
        [InlineData("5 5")]
        [InlineData("6 5")]
        public void SetInitialCoordinates_Should_Create_Plateau(string input)
        {
            // Arrange

            var XCoordinate = int.Parse(input.Split(" ")[0]);
            var YCoordinate = int.Parse(input.Split(" ")[1]);

            var plateauCoordinates = new PlateauCoordinates
            {
                XCoordinate = XCoordinate,
                YCoordinate = YCoordinate
            };

            var Plateau = new Plateau
            {
                PlateauCoordinates = plateauCoordinates,
                RoverStates = new List<RoverState>()
            };

            // Act
            var result = _plateauService.SetInitialCoordinates(plateauCoordinates);
            // Assert
            result.Should().NotBeNull();
            result.PlateauCoordinates.XCoordinate.Should().Be(Plateau.PlateauCoordinates.XCoordinate);
            result.PlateauCoordinates.YCoordinate.Should().Be(Plateau.PlateauCoordinates.YCoordinate);
            result.RoverStates.Should().Equal(Plateau.RoverStates);
        }

        private static ServiceProvider Configure()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
          .AddSingleton<IPlateauService, PlateauService>()
          .BuildServiceProvider();

            _plateauService = serviceProvider.GetService<IPlateauService>();

            return serviceProvider;
        }
    }
}
