using EAD.Repositories;
using System.Threading.Tasks;

namespace EAD.Interfaces.Services
{
    public interface IUnitOfWork
    {
        public FtpConfigurationsRepository FtpConfigurationsRepository { get; }

        public FtpResultsRepository FtpResultsRepository { get; }

        public OcrConfigurationsRepository OcrConfigurationsRepository { get; }

        public Task<int> SaveChanges();
    }
}