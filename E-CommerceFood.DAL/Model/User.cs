namespace E_CommerceFood.DAL.Model
{
    public class User:ApplicationUser
    {
        public string Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
