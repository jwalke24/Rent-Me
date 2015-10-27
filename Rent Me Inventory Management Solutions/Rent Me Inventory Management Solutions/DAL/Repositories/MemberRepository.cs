using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class MemberRepository : IRepository<Member>
    {
        private readonly string CONNECTION_STRING;

        public MemberRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }
        public void AddList(IList<Member> theList)
        {
            throw new NotImplementedException();
        }

        public void AddOne(Member item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Member item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public Member GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
