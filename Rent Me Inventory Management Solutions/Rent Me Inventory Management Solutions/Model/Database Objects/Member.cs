namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    class Member
    {
        public string Fname { get; set; }

        public string Minit { get; set; }

        public string Lname { get; set; }

        public string PhoneNumber { get; set; }

        public Address TheAddress { get; set; }
    }
}
