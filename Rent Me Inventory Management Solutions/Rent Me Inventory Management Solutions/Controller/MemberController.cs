using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class MemberController
    {
        private MemberRepository memberRepository;

        public MemberController()
        {
            this.memberRepository = new MemberRepository();
        }

        public void AddMember(Member aMember)
        {
            this.memberRepository.AddOne(aMember);
        }

        public IList<Member> GetAll()
        {
            return this.memberRepository.GetAll();
        }
    }
}
