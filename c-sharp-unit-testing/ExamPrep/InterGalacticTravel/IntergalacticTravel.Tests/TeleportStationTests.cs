using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Fakes;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class TeleportStationTests
    {

        [Test]
        public void Constructor_ShouldCorrectlySetAllTheFields_WhenValidParametersArePassed()
        {
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            // Act

            var sut = new FakeTeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            // Assert

            Assert.AreEqual(ownerStub.Object, sut.Owner);
            Assert.AreEqual(galacticMapStub.Object, sut.GalacticMap);
            Assert.AreEqual(locationStub.Object, sut.Location);
            Assert.IsInstanceOf<IResources>(sut.Resources);
        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullExceptionWithMessageContainsunitToTeleport_WhenunitToTeleportIsNull()
        {
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            var targetLocationStub = new Mock<ILocation>();
            var sut = new TeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);
            // Act & Assert

            var ex = Assert.Catch<ArgumentNullException>(() => sut.TeleportUnit(null, targetLocationStub.Object));
            StringAssert.Contains("unitToTeleport", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullExceptionWithMessageContainsdestination_WhenDestinationIsNull()
        {
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            var unitToTeleportStub = new Mock<IUnit>();
            var sut = new TeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);
            // Act & Assert

            var ex = Assert.Catch<ArgumentNullException>(() => sut.TeleportUnit(unitToTeleportStub.Object, null));
            StringAssert.Contains("destination", ex.Message);
        }
        
        [Test]
        public void TeleportUnit_ShouldThrowTeleportOutOfRangeExceptionWithMessageunitToTeleportCurrentLocation_WhenUnitIsUsingTeleportStationFromDistantLocation()
        {
            // Arrange
            var expectedMsg = "unitToTeleport.CurrentLocation";

            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            var sut = new TeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            locationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            locationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitToTeleportStub = new Mock<IUnit>();
            var targetLocationStub = new Mock<ILocation>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("notmilkyway");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("earth");

            unitToTeleportStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            // Act & Assert

            var ex = Assert.Catch<TeleportOutOfRangeException>(() => sut.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
            StringAssert.Contains(expectedMsg, ex.Message);
        }
        
        [Test]
        public void TeleportUnit_ShouldThrowInvalidTeleportationLocationExceptionWithMessageUnitsWillOverlap_WhenTryingToTeleportUnitOnTopOfAnotherUnit()
        {
            // Arrange
            var expectedMsg = "units will overlap";

            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();
            var sut = new TeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            locationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            locationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitToTeleportStub = new Mock<IUnit>();
            var targetLocationStub = new Mock<ILocation>();
            var currentLocationStub = new Mock<ILocation>();

            unitToTeleportStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("galaxy");
            targetLocationStub.Setup(x => x.Planet.Name).Returns("planet");
            targetLocationStub.Setup(x => x.Coordinates.Latitude).Returns(12);
            targetLocationStub.Setup(x => x.Coordinates.Longtitude).Returns(12);

            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("mars");
            
            var unitInCityStub = new Mock<IUnit>();

            unitInCityStub.Setup(x => x.CurrentLocation).Returns(targetLocationStub.Object);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(12);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(12);
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("galaxy");
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Name).Returns("planet");

            var galacticMapPathStub = new Mock<IPath>();

            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("galaxy");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Name).Returns("planet");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCityStub.Object});


            galacticMapStub.Add(galacticMapPathStub.Object);
            
            // Act & Assert

            var ex = Assert.Catch<InvalidTeleportationLocationException>(() => sut.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
            StringAssert.Contains(expectedMsg, ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldLocationNotFoundExceptionWithStringPlanet_WhenPlanetNotFoundOnLocationsList()
        {
            // Arrange
            var expectedMsg = "Planet";

            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();
            var sut = new TeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            locationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            locationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitToTeleportStub = new Mock<IUnit>();
            var targetLocationStub = new Mock<ILocation>();
            var currentLocationStub = new Mock<ILocation>();

            unitToTeleportStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("galaxy");
            targetLocationStub.Setup(x => x.Planet.Name).Returns("planet");
            targetLocationStub.Setup(x => x.Coordinates.Latitude).Returns(12);
            targetLocationStub.Setup(x => x.Coordinates.Longtitude).Returns(12);

            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitInCityStub = new Mock<IUnit>();

            unitInCityStub.Setup(x => x.CurrentLocation).Returns(targetLocationStub.Object);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(12);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(12);
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("galaxy");
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Name).Returns("planet");

            var galacticMapPathStub = new Mock<IPath>();

            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("galaxy");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Name).Returns("notplanet");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCityStub.Object });


            galacticMapStub.Add(galacticMapPathStub.Object);

            // Act & Assert

            var ex = Assert.Catch<LocationNotFoundException>(() => sut.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
            StringAssert.Contains(expectedMsg, ex.Message);
        }
        
        [Test]
        public void TeleportUnit_ShouldThrowInsufficientResourcesExceptionWithMessageFREELUNCH_WhenUnitCantPay()
        {
            // Arrange
            var expectedMsg = "FREE LUNCH";

            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();
            var sut = new TeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            locationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            locationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitToTeleportStub = new Mock<IUnit>();
            var targetLocationStub = new Mock<ILocation>();
            var currentLocationStub = new Mock<ILocation>();

            unitToTeleportStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("galaxy");
            targetLocationStub.Setup(x => x.Planet.Name).Returns("planet");
            targetLocationStub.Setup(x => x.Coordinates.Latitude).Returns(12);
            targetLocationStub.Setup(x => x.Coordinates.Longtitude).Returns(12);

            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitInCityStub = new Mock<IUnit>();

            unitInCityStub.Setup(x => x.CurrentLocation).Returns(targetLocationStub.Object);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(13);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(13);
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("galaxy");
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Name).Returns("planet");

            var galacticMapPathStub = new Mock<IPath>();

            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("galaxy");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Name).Returns("planet");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCityStub.Object });


            galacticMapStub.Add(galacticMapPathStub.Object);

            var costStub = new Mock<IResources>();
            costStub.Setup(x => x.GoldCoins).Returns(2);
            costStub.Setup(x => x.SilverCoins).Returns(2);
            costStub.Setup(x => x.BronzeCoins).Returns(2);
            galacticMapPathStub.Setup(x => x.Cost).Returns(costStub.Object);
            unitToTeleportStub.Setup(x => x.Resources.GoldCoins).Returns(1);
            unitToTeleportStub.Setup(x => x.Resources.SilverCoins).Returns(1);
            unitToTeleportStub.Setup(x => x.Resources.BronzeCoins).Returns(1);

            // Act & Assert

            var ex = Assert.Catch<InsufficientResourcesException>(() => sut.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
            StringAssert.Contains(expectedMsg, ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldInvokeGetPayment_WhenAllValidationsAreCompleted()
        {
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();
            var sut = new FakeTeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            locationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            locationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitToTeleportStub = new Mock<IUnit>();
            var targetLocationStub = new Mock<ILocation>();
            var currentLocationStub = new Mock<ILocation>();

            unitToTeleportStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("galaxy");
            targetLocationStub.Setup(x => x.Planet.Name).Returns("planet");
            targetLocationStub.Setup(x => x.Coordinates.Latitude).Returns(12);
            targetLocationStub.Setup(x => x.Coordinates.Longtitude).Returns(12);

            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("milkyway");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("mars");

            var unitInCityStub = new Mock<IUnit>();

            unitInCityStub.Setup(x => x.CurrentLocation).Returns(targetLocationStub.Object);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(13);
            unitInCityStub.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(13);
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("galaxy");
            unitInCityStub.Setup(x => x.CurrentLocation.Planet.Name).Returns("planet");

            var galacticMapPathStub = new Mock<IPath>();

            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("galaxy");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Name).Returns("planet");
            galacticMapPathStub.Setup(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCityStub.Object });


            galacticMapStub.Add(galacticMapPathStub.Object);

            var costStub = new Mock<IResources>();
            costStub.Setup(x => x.GoldCoins).Returns(2);
            costStub.Setup(x => x.SilverCoins).Returns(2);
            costStub.Setup(x => x.BronzeCoins).Returns(2);
            galacticMapPathStub.Setup(x => x.Cost).Returns(costStub.Object);
            unitToTeleportStub.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var someReturnResourceAfterPayStub = new Mock<IResources>();
            someReturnResourceAfterPayStub.Setup(x => x.GoldCoins).Returns(1);
            someReturnResourceAfterPayStub.Setup(x => x.SilverCoins).Returns(1);
            someReturnResourceAfterPayStub.Setup(x => x.BronzeCoins).Returns(1);

            unitToTeleportStub.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(someReturnResourceAfterPayStub.Object);
            unitToTeleportStub.Setup(x => x.Resources.GoldCoins).Returns(3);
            unitToTeleportStub.Setup(x => x.Resources.SilverCoins).Returns(3);
            unitToTeleportStub.Setup(x => x.Resources.BronzeCoins).Returns(3);

            // Act

            sut.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);

            // Assert

            Assert.AreEqual(costStub.Object.GoldCoins, sut.Resources.GoldCoins);
        }

    }
}
