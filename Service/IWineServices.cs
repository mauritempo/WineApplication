using Data.Entities;
using Data.Repo;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IWineService
    {
        Wine CreateWine(WineDto wineDto);
        List<WineDto> GetAllWines();
        Wine UpdateWineStock(int id, int newStock);
        List<Wine> GetWinesByVariety(string variety);
    }
}
