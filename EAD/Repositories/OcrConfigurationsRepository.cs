using EAD.Models;
using EAD.Repositories.Common;
using EAD.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAD.Repositories
{
    public class OcrConfigurationsRepository : SqlRepository<OcrConfiguration>
    {
        private readonly OcrDbContext _dbContext;

        public OcrConfigurationsRepository(OcrDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<List<OcrConfiguration>> GetAll()
        {
            return await _dbContext.OcrConfigurations.Include(x => x.FtpConfiguration).ToListAsync();
        }

        public new async Task<OcrConfiguration> GetById(int id)
        {
            return await _dbContext.OcrConfigurations.Where(x => x.Id == id).Include(x => x.FtpConfiguration).FirstOrDefaultAsync();
        }
    }
}