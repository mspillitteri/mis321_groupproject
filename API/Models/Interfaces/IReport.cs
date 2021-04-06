using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IReport
    {
        //  public List<Item> ReportCheckedOutItems();
         public List<Item> ReportInventory();
    }
}