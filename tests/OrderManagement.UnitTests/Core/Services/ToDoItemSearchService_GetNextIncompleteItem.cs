﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using OrderManagement.Core.ProjectAggregate;
using OrderManagement.Core.Services;
using OrderManagement.SharedKernel.Interfaces;
using Moq;
using Xunit;

namespace OrderManagement.UnitTests.Core.Services
{
    public class ToDoItemSearchService_GetNextIncompleteItem
    {
        [Fact]
        public async Task ReturnsNotFoundGivenNoRemainingItems()
        {
            var repo = new Mock<IRepository<ToDoItem>>();
            var service = new ToDoItemSearchService(repo.Object);
            repo.Setup(r => r.ListAsync(It.IsAny<ISpecification<ToDoItem>>()))
                .ReturnsAsync(new List<ToDoItem>());

            var result = await service.GetNextIncompleteItemAsync();

            Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
        }

        [Fact]
        public async Task ReturnsFirstItemFromList()
        {
            var repo = new Mock<IRepository<ToDoItem>>();
            var service = new ToDoItemSearchService(repo.Object);
            var testItems = GetTestItems();
            repo.Setup(r => r.ListAsync(It.IsAny<ISpecification<ToDoItem>>()))
                .ReturnsAsync(testItems);

            var result = await service.GetNextIncompleteItemAsync();

            Assert.Equal(testItems.First(), result.Value);
        }

        private List<ToDoItem> GetTestItems()
        {
            // Note: could use AutoFixture
            var builder = new ToDoItemBuilder();

            var items = new List<ToDoItem>();

            var item1 = builder.WithDefaultValues().Build();
            items.Add(item1);

            var item2 = builder.WithDefaultValues().Id(2).Build();
            items.Add(item2);

            var item3 = builder.WithDefaultValues().Id(3).Build();
            items.Add(item3);

            return items;
        }
    }
}
