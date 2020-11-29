using FootballLeague.Data;
using FootballLeague.Data.Exception;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.Services;
using FootballLeague.Services.Services.Contracts;
using FootballLeague.Web.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Tests.ServiceTests
{
    public abstract class BaseServiceSetup<TService, TRepository, TEntity, TEntityDto, TUpdateEntityInput, TCreateEntityInput>
     where TRepository : class, IRepository<TEntity>
     where TEntity : class, IEntity, new()
     where TService : CrudService<TEntity, TEntityDto, TUpdateEntityInput, TCreateEntityInput>
     where TEntityDto : class, IEntityDto
     where TUpdateEntityInput : class, IEntityDto
     where TCreateEntityInput : class
    {
        protected Mock<TRepository> repoMock;
        protected ServiceProvider serviceProvider;
        protected int primaryKey = 0;

        public BaseServiceSetup()
        {
        }

        protected abstract TCreateEntityInput CreateInput { get; }
        protected abstract TUpdateEntityInput UpdateInput { get; }


        protected virtual void SetupServices(IServiceCollection services) { }

        [SetUp]
        protected void TestSetup()
        {
            var databaseName = Guid.NewGuid().ToString();

            repoMock = new Mock<TRepository>();
                 
            var builder = new ServiceCollection()
                 .AddEntityFrameworkInMemoryDatabase()
                 .AddAutomapper()
                .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName).UseInternalServiceProvider(serviceProvider))
                .AddSingleton<TService>()
                .AddSingleton(repoMock.Object);

            SetupServices(builder);
            serviceProvider = builder.BuildServiceProvider();
        }

        protected void TestCleanup()
        {
            serviceProvider?.Dispose();
            serviceProvider = null;
        }

        [Test]
        public virtual async Task CreateAsync_Should_Add_To_Database()
        {
            repoMock.Setup(r => r.AddAsync(It.IsAny<TEntity>()));
            var result = await serviceProvider.GetService<TService>().CreateAsync(CreateInput);
            result.AssertEqualProperties(CreateInput);
        }

        [Test]
        public virtual void DeleteAsync_Should_Throw_NotFound_On_PrimaryKey_Null()
        {
            Assert.ThrowsAsync<NotFoundException>(() =>
                serviceProvider.GetService<TService>().DeleteAsync(primaryKey));
        }

        [Test]
        public virtual void DeleteAsync_Should_Throw_NotFound_On_Entity_Null()
        {

            repoMock.Setup(r => r.GetAsync(UpdateInput.Id)).ReturnsAsync((TEntity)null);
            Assert.ThrowsAsync<NotFoundException>(async () =>
                await serviceProvider.GetService<TService>().DeleteAsync(UpdateInput.Id));
        }

        [Test]
        public virtual Task GetAsync_Should_Throw_NotFound_On_PrimaryKey_Null()
        {
            Assert.ThrowsAsync<NotFoundException>(() =>
                serviceProvider.GetService<TService>().GetAsync(primaryKey));
            return Task.CompletedTask;
        }


        [Test]
        public virtual Task UpdateAsync_Should_Throw_NotFound_On_PrimaryKey_Null()
        {
            Assert.ThrowsAsync<NotFoundException>(() =>
                serviceProvider.GetService<TService>().UpdateAsync(primaryKey, UpdateInput));
            return Task.CompletedTask;
        }
    }
}
