using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BaseApplication.Domain.Entities;
using BaseApplication.Infra.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BaseApplication.Infra
{
    public class BaseApplicationDbContext : DbContext
    {
         #region Tables

        // public DbSet<User> Users { get; set; }

        #endregion

        public BaseApplicationDbContext(DbContextOptions<BaseApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupEntitiesConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        
        private static void SetupEntitiesConfigurations(ModelBuilder modelBuilder)
        {
            var assembly = AppDomain.CurrentDomain.Load(typeof(EntityTypeConfigurationBase<>).Module.Name.Replace(".dll", string.Empty));
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await UpdatePrivateFields();
            return await base.SaveChangesAsync(cancellationToken);
        }
        
        private async Task UpdatePrivateFields()
        {
            var dataAtual = DateTimeOffset.Now;
            foreach (var entity in ModifiedAndAddedEntities())
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        entity.CurrentValues["DeletedAt"] = dataAtual;
                        break;
                    case EntityState.Modified:
                        entity.CurrentValues["UpdatedAt"] = dataAtual;
                        break;
                    case EntityState.Added:
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }   
            }

            // await _domainEventEmitter.PublishAsync(PendingEvents().ToArray());
            // _eventsSent = _eventsSent.Concat(PendingEvents()).ToList();

            if (ModifiedAndAddedEntities().Any()/* || PendingEvents().Any()*/)
                await UpdatePrivateFields();
        }
        
        // private IEnumerable<IDomainEvent> PendingEvents() 
        //     => DomainEvents().Where(es => !_eventsSent.Contains(es));

        private IEnumerable<EntityEntry> EntityEntries()
        {
            var entities = ChangeTracker.Entries().Where(e => e.Entity is Entity);
            return entities;
        }

        private IEnumerable<EntityEntry> ModifiedAndAddedEntities()
        {
            var entities = EntityEntries();
            var modifiedAndAdded = entities.Where(e => (e.State == EntityState.Modified || e.State == EntityState.Added) &&
                                                       ((e.Entity as Entity).CreatedAt == DateTime.MinValue || (e.Entity as Entity).UpdatedAt == DateTime.MinValue));
            return modifiedAndAdded;
        }
    }
}