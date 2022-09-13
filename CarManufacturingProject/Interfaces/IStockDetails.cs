using CarManufacturingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturingProject.Interfaces
{
    public interface IStockDetails
    {
        List<StockDetails> GetStocksList();
    }
}
