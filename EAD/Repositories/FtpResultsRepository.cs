using EAD.Extensions;
using EAD.Models;
using EAD.Repositories.Common;
using EAD.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAD.Repositories
{
    public class FtpResultsRepository : SqlRepository<FtpResult>
    {
        private readonly OcrDbContext _dbContext;

        public FtpResultsRepository(OcrDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IEnumerable<FtpResult>> GetAll()
        {
            return await _dbContext.FtpResults.Include(x => x.FtpConfiguration).ToListAsync();
        }

        public async Task<IEnumerable<FtpResult>> GetByDates(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.FtpResults.Where(x => x.Date >= startDate.ToStartOfDay() && x.Date <= endDate.ToEndOfDay()).Include(x => x.FtpConfiguration).ToListAsync();
        }
    }
}
