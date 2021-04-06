namespace API.Models.Interfaces
{
    public interface IUpdate
    {
         public void UpdateCheckOut(Checkouts cvalue);
         public void UpdateItem(Item ivalue);
         public void UpdateUser(User uvalue);
    }
}