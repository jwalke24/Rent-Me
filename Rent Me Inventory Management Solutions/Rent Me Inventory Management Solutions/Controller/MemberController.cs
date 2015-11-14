using System;
using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    internal class MemberController
    {
        private readonly MemberRepository memberRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberController" /> class.
        /// </summary>
        public MemberController()
        {
            this.memberRepository = new MemberRepository();
        }

        /// <summary>
        ///     Adds the member to the database.
        /// </summary>
        /// <param name="aMember">a member.</param>
        public void AddMember(Member aMember)
        {
            this.memberRepository.AddOne(aMember);
        }

        /// <summary>
        ///     Gets all the members from the database.
        /// </summary>
        /// <returns></returns>
        public IList<Member> GetAll()
        {
            return this.memberRepository.GetAll();
        }

        /// <summary>
        ///     Deletes the member by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public void DeleteMemberById(string customerId)
        {
            this.memberRepository.DeleteById(customerId);
        }

        public IList<Member> SearchMember(string text)
        {
            try
            {
                long.Parse(text);
                return this.memberRepository.SearchByIDOrPhone(text);
            }
            catch (Exception)
            {
                return this.memberRepository.SearchByName(text);
            }
        }
    }
}