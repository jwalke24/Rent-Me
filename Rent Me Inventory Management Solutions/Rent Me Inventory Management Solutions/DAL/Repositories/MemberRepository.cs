﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using MySql.Data.MySqlClient;

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
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            const string statement = "INSERT INTO Customer (fname, lname, minit, phone, Address_id)" +
                                        " VALUES (@Fname, @Lname, @Minit, @Phone, @Address)";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@Fname", item.Fname);
                command.Parameters.AddWithValue("@Lname", item.Lname);
                command.Parameters.AddWithValue("@Minit", item.Minit);
                command.Parameters.AddWithValue("@Phone", item.PhoneNumber);
                command.Parameters.AddWithValue("@Address", item.AddressId);

                command.Connection = connection;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    command.Connection.Close();
                }
            }
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
            List<Member> members = new List<Member>();

            const string query = "SELECT * FROM Customer";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = connection;

                try
                {
                    command.Connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Member theMember = new Member();
                        theMember.Id = (int)reader["id"];
                        theMember.Fname = reader["fname"] == DBNull.Value ? String.Empty : (string)reader["fname"];
                        theMember.Minit = reader["minit"] == DBNull.Value ? String.Empty : (string)reader["minit"];
                        theMember.Lname = reader["lname"] == DBNull.Value ? String.Empty : (string)reader["lname"];
                        theMember.PhoneNumber = reader["phone"] == DBNull.Value ? String.Empty : (string)reader["phone"];
                        theMember.AddressId = reader["Address_id"] == DBNull.Value ? String.Empty : ((int)reader["Address_id"]).ToString();
                        members.Add(theMember);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return members;
        }

        public Member GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
