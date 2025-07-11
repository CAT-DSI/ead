using EAD.Models;
using EAD.Repositories.Common;
using EAD.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAD.Repositories
{
    public class FtpConfigurationsRepository : SqlRepository<FtpConfiguration>
    {
        private readonly OcrDbContext _dbContext;

        public FtpConfigurationsRepository(OcrDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FtpConfiguration>> GetByConfigurationId(int configurationId)
        {
            return await _dbContext.OcrConfigurations.Where(x => x.Id == configurationId).Include(x => x.FtpConfiguration).Select(x => x.FtpConfiguration).Where(x => x != null).ToListAsync();
        }
    }
}