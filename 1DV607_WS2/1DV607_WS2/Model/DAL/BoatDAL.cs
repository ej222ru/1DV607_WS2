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
    public class BoatDAL : BaseDAL
    {

        public void InsertBoat(BoatBLL boat)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertBoat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BoatType", SqlDbType.Int, 4).Value = boat.BoatType;
                    cmd.Parameters.Add("@Length", SqlDbType.Int, 4).Value = boat.Length;
                    cmd.Parameters.Add("@MemberId", SqlDbType.Int, 4).Value = boat.MemberId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while inserting a a boat into the database.");
                }
            }
        }
        public void UpdateBoat(BoatBLL boat)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateBoat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BoatId", SqlDbType.Int, 4).Value = boat.BoatId;
                    cmd.Parameters.Add("@MemberId", SqlDbType.Int, 4).Value = boat.MemberId;
                    cmd.Parameters.Add("@BoatType", SqlDbType.Int, 4).Value = boat.BoatType;
                    cmd.Parameters.Add("@Length", SqlDbType.Int, 4).Value = boat.Length;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while updating boat at the database");
                }
            }
        }
        public void DeleteBoat(int boatId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteBoat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BoatId", SqlDbType.Int, 4).Value = boatId;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while deleting a boat from the database.");
                }
            }
        }
        public BoatBLL GetBoat(BoatBLL boat)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspGetBoat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BoatId", SqlDbType.Int, 4).Value = boat.BoatId;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int MemberIdIndex = reader.GetOrdinal("MemberId");
                            int BoatTypeIndex   = reader.GetOrdinal("BoatType");
                            int LengthIndex        = reader.GetOrdinal("Length");

                            boat.MemberId   = reader.GetInt32(MemberIdIndex);
                            boat.BoatType   = (BoatType)reader.GetInt32(BoatTypeIndex);
                            boat.Length     = reader.GetInt32(LengthIndex);
                            return boat;
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
        public IEnumerable<BoatBLL> GetBoats()
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var boats = new List<BoatBLL>(10);

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetMembers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int BoatIdIndex = reader.GetOrdinal("BoatId");
                            int MemberIdIndex = reader.GetOrdinal("MemberId");
                            int BoatTypeIndex = reader.GetOrdinal("BoatType");
                            int LengthIndex = reader.GetOrdinal("Length");
                            boats.Add(new BoatBLL
                            {
                                BoatId = reader.GetInt32(BoatIdIndex),
                                MemberId = reader.GetInt32(MemberIdIndex),
                                BoatType = (BoatType)reader.GetInt32(BoatTypeIndex),
                                Length   = reader.GetInt32(LengthIndex),
                            });
                        }
                    }
                    boats.TrimExcess();
                    return boats;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting boats from the database.");
                }
            }
        }
    }
}
