using _1DV607_WS2.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.Model.DAL
{
    // DB access to Member records of type MemberBLL

    public class MemberDAL : BaseDAL
    {
        public void IinsertMember(MemberBLL member)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 25).Value = member.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = member.LastName;
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 12).Value = member.SSN;
                    cmd.Parameters.Add("@MemberId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    member.MemberId = Convert.ToInt32(cmd.Parameters["@MemberId"].Value);
                }
                catch
                {
                    throw new ApplicationException("An error occured while inserting a member into the database.");
                }
            }
        }
        public void UpdateMember(MemberBLL member)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MemberId", SqlDbType.Int, 4).Value = member.MemberId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = member.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = member.LastName;
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = member.SSN;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while updating member at the database");
                }
            }
        }
        public void DeleteMember(string SSN)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 12).Value = SSN;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while deleting a member from the database.");
                }
            }
        }
        public MemberBLL GetMember(MemberBLL member)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspGetMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 12).Value = member.SSN;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int FirstNameIndex  = reader.GetOrdinal("FirstName");
                            int LastNameIndex   = reader.GetOrdinal("LastName");
                            int MemberIdIndex = reader.GetOrdinal("MemberId");

                            member.FirstName    = reader.GetString(FirstNameIndex);
                            member.LastName     = reader.GetString(LastNameIndex);
                            member.MemberId     = reader.GetInt32(MemberIdIndex);
                            return member;
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting a member from the database.");
                }
            }
        }

        public IEnumerable<MemberBLL> GetMembers()
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var members = new List<MemberBLL>(1000);

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetMembers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int MemberIdIndex = reader.GetOrdinal("MemberId");
                            int FirstNameIndex = reader.GetOrdinal("FirstName");
                            int LastNameIndex = reader.GetOrdinal("LastName");
                            int SSNIndex = reader.GetOrdinal("SSN");
                            members.Add(new MemberBLL
                            {
                                MemberId     = reader.GetInt32(MemberIdIndex),
                                FirstName    = reader.GetString(FirstNameIndex),
                                LastName     = reader.GetString(LastNameIndex),
                                SSN          = reader.GetString(SSNIndex),
                            });
                        }
                    }
                    members.TrimExcess();
                    return members;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting members from the database.");
                }
            }
        }
    }
}
