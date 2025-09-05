using Microsoft.AspNetCore.Mvc;
using WebAPICodeDemo.Models.Domain;

namespace WebAPICodeDemo.Repositries
{
    public interface IRegionRepo
    {
      Task<List<Regions>> GetAllAsync();

    }
}
