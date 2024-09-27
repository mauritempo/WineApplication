using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IWineService
    {
        void CreateWine(WineDto wineDto);
        List<WineDto> GetAllWines();
    }
}
