using Microsoft.EntityFrameworkCore;
using WebAPICodeDemo.Data;
using WebAPICodeDemo.Models.Domain;

namespace WebAPICodeDemo.Repositries
{
    public class SQLRegionsRepo : IRegionRepo
    {
        private NzwalksDBContext _dbContext;
        public SQLRegionsRepo(NzwalksDBContext nzwalksDBContext)
        {
            this._dbContext = nzwalksDBContext;
        }
        public async Task<List<Regions>> GetAllAsync()
        {
            return await this._dbContext.Regions.ToListAsync();


            //throw new NotImplementedException();
        }
    }
}
