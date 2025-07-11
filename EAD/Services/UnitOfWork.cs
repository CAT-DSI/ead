using EAD.Interfaces.Services;
using EAD.Repositories;
using System.Threading.Tasks;

namespace EAD.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OcrDbContext _dbContext;

        public UnitOfWork(OcrDbContext dbContext)
        {
            _dbContext = dbContext;
            FtpConfigurationsRepository = new FtpConfigurationsRepository(dbContext);
            FtpResultsRepository = new FtpResultsRepository(dbContext);
            OcrConfigurationsRepository = new OcrConfigurationsRepository(dbContext);
        }

        public FtpConfigurationsRepository FtpConfigurationsRepository { get; }

        public FtpResultsRepository FtpResultsRepository { get; }

        public OcrConfigurationsRepository OcrConfigurationsRepository { get; }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
