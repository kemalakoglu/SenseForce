using CodingPuzzleSıgnalR.ApplicationService;
using CodingPuzzleSıgnalR.ApplicationService.DTO;
using CodingPuzzleSıgnalR.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Xunit;
using Xunit.DependencyInjection;

namespace CodingPuzzleSıgnalR.IntegrationTest
{
    public class ApplicationServiceTest
    {
        private IApplicationService applicationService { get; set; }

        [Fact]
        public void ShouldMessageValidAndInsertedToDatabase()
        {


            //Arrange          
            DependencyFixture dependencyFixture = new DependencyFixture();
            this.applicationService = dependencyFixture.ServiceProvider.GetService<IApplicationService>();
            MessageDTO mess = new MessageDTO();
            mess.Data = @"{ 'sensor1':12.3, 'sensor2':10.0, 'sensor3':12.3, 'sensor4':'open' }";
            mess.Type = "SensorData";
            mess.Id = "7e8b93c3-44bb-425f-a8d8-f48bb8e58365";
            mess.TimeStamp = Guid.NewGuid().ToString();

            //Act

            bool result = this.applicationService.ConsumeMessage(mess);

            //Assert
            Assert.True(result);

        }

        [Fact]
        public void ShouldMessageNotValid()
        {
            //Arrange
            DependencyFixture dependencyFixture = new DependencyFixture();
            this.applicationService = dependencyFixture.ServiceProvider.GetService<IApplicationService>();
            MessageDTO mess = new MessageDTO();
            mess.Data = @"{ 'sensor1':12.3, 'sensor2':10.0, 'sensor3':12.3, 'sensor4':'open' }";

            //Act

            bool result = this.applicationService.ConsumeMessage(mess);

            //Assert
            Assert.Throws<Exception>(() => "Message Body Is Not Valid");
        }

        [Fact]
        public void ShouldMessageValidButMessageRepeated()
        {
            //Arrange
            DependencyFixture dependencyFixture = new DependencyFixture();
            this.applicationService = dependencyFixture.ServiceProvider.GetService<IApplicationService>();
            MessageDTO mess = new MessageDTO();
            mess.Data = @"{ 'sensor1':12.3, 'sensor2':10.0, 'sensor3':12.3, 'sensor4':'open' }";
            mess.Type = "SensorData";
            mess.Id = "7e8b93c3-44bb-425f-a8d8-f48bb8e58365";
            mess.TimeStamp = Guid.NewGuid().ToString();

            //Act

            bool result = this.applicationService.ConsumeMessage(mess);

            //Assert
            Assert.Throws<Exception>(() => "Repeated Message");
        }
    }
}
