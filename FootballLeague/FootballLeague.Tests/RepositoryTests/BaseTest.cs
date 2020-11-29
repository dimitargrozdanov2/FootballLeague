//using FootballLeague.Data;
//using FootballLeague.Data.Exception;
//using FootballLeague.Data.Repositories;
//using FootballLeague.Models;
//using FootballLeague.Web.Utils.Extensions;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace FootballLeague.Tests.RepositoryTests
//{
//    [TestFixture]

//    public class BaseRepositorySetup<TRepository, TEntity, TContext>
//         where TEntity : class, IEntity, new()
//         where TRepository : DbRepository<TEntity>
//         where TContext : DbContext
//    {
//        protected ServiceProvider serviceProvider;


//        protected void SetupServices(IServiceCollection services) 
//        {
//            services.AddSingleton<TRepository>();
//        }

//        [SetUp]
//        protected void TestSetup(Assembly assembly, string databaseName = null)
//        {
//            if (databaseName == null)
//                databaseName = Guid.NewGuid().ToString();
//            TestCleanup();

//            var builder = new ServiceCollection()
//                .AddEntityFrameworkInMemoryDatabase()
//                .AddAutomapper()
//                .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName).UseInternalServiceProvider(serviceProvider));  

//            SetupServices(builder);
//            serviceProvider = builder.BuildServiceProvider();
//        }

//        [TearDown]
//        protected void TestCleanup()
//        {
//            serviceProvider?.Dispose();
//            serviceProvider = null;
//        }

//        protected TEntity CreateEntity { get; }
//        protected virtual List<string> CreateIgnoreProperties { get; set; } = new List<string>();
//        protected List<TEntity> CreatedEntities { get; }
//        protected TEntity UpdatedEntity { get; }


//        [Test]
//        public async Task Add_Should_Add_to_Database()
//        {
//            var result = await serviceProvider.GetService<TRepository>().AddAsync(CreateEntity);
//            result.AssertEqualProperties(CreateEntity);
//        }

//        [Test]
//        public async Task Get_Should_Return_Entity()
//        {
//            using var dbContext = serviceProvider.GetService<TContext>();
//            await dbContext.Set<TEntity>().AddAsync(CreateEntity);
//            await dbContext.SaveChangesAsync();
//            var result = await serviceProvider.GetService<TRepository>().GetAsync(CreateEntity.Id);
//            result.AssertEqualProperties(CreateEntity);
//        }

//        [Test]
//        public async Task Get_Should_Return_Not_Found()
//        {
//            using var dbContext = serviceProvider.GetService<TContext>();
//            await dbContext.Set<TEntity>().AddAsync(CreateEntity);
//            await dbContext.SaveChangesAsync();
//            Assert.ThrowsAsync<NotFoundException>(async () =>
//                await serviceProvider.GetService<TRepository>().GetAsync(default(int)));
//        }

//        [Test]
//        public async Task GetAll_Should_Return_Entities()
//        {
//            using var dbContext = serviceProvider.GetService<TContext>();
//            dbContext.Set<TEntity>().AddRange(CreatedEntities);
//            dbContext.SaveChanges();
//            var result = serviceProvider.GetService<TRepository>().GetAll();
//            var x = await result.ToListAsync();
//            Assert.AreEqual(x.Count, 2);
//        }

//        [Test]
//        public async Task GetSingle_Should_Return_SingleEntity()
//        {
//            using var dbContext = serviceProvider.GetService<TContext>();
//            await dbContext.Set<TEntity>().AddAsync(CreateEntity);
//            await dbContext.SaveChangesAsync();
//            var result = await serviceProvider.GetService<TRepository>().GetSingleAsync(e => e.Id.Equals(CreateEntity.Id));
//            result.AssertEqualProperties(CreateEntity);
//        }

//        [Test]
//        public async Task Update_Should_Return_ModifiedEntity()
//        {
//            using var dbContext = serviceProvider.GetService<TContext>();
//            dbContext.Set<TEntity>().Add(CreateEntity);
//            dbContext.SaveChanges();
//            var updated = dbContext.Set<TEntity>().Find(CreateEntity.Id);
//            UpdatedEntity.CopyProperties(updated);
//            await serviceProvider.GetService<TRepository>().UpdateAsync(updated);
//            updated = dbContext.Set<TEntity>().Find(UpdatedEntity.Id);
//            updated.AssertEqualProperties(UpdatedEntity);
//        }

//        [Test]
//        public void Update_Should_Return_Not_Found()
//        {
//            Assert.ThrowsAsync<NotFoundException>(async () =>
//                await serviceProvider.GetService<TRepository>().UpdateAsync(null));
//        }

//        [Test]
//        public async Task Delete_Should_Delete_Entity()
//        {
//            using var dbContext = serviceProvider.GetService<TContext>();
//            await dbContext.Set<TEntity>().AddAsync(CreateEntity);
//            await dbContext.SaveChangesAsync();
//            await serviceProvider.GetService<TRepository>().DeleteAsync(CreateEntity.Id);
//            var deletedEntity = await dbContext.Set<TEntity>().FindAsync(CreateEntity.Id);
//            Assert.IsNull(deletedEntity);
//        }
//    }
//}
