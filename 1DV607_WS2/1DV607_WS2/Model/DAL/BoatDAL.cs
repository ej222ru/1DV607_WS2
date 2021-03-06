﻿using _1DV607_WS2.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.Model.DAL
{


    // DB access to Boat records of type BoatBLL
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
                    cmd.Parameters.Add("@BoatLength", SqlDbType.Int, 4).Value = boat.BoatLength;
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 12).Value = boat.SSN;
                    cmd.Parameters.Add("@BoatId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    boat.BoatId = Convert.ToInt32(cmd.Parameters["@BoatId"].Value);

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
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 12).Value = boat.SSN;
                    cmd.Parameters.Add("@BoatType", SqlDbType.Int, 4).Value = boat.BoatType;
                    cmd.Parameters.Add("@BoatLength", SqlDbType.Int, 4).Value = boat.BoatLength;

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
                            int SSNIndex = reader.GetOrdinal("SSN");
                            int BoatTypeIndex   = reader.GetOrdinal("BoatType");
                            int BoatLengthIndex        = reader.GetOrdinal("BoatLength");

                            boat.SSN = reader.GetString(SSNIndex);
                            boat.BoatType   = (BoatType)reader.GetInt32(BoatTypeIndex);
                            boat.BoatLength = reader.GetInt32(BoatLengthIndex);
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
        public IEnumerable<BoatBLL> GetBoats(string SSN)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var boats = new List<BoatBLL>(10);

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetBoats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SSN", SqlDbType.VarChar, 12).Value = SSN;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int BoatIdIndex = reader.GetOrdinal("BoatId");
                            int SSNIndex = reader.GetOrdinal("SSN");
                            int BoatTypeIndex = reader.GetOrdinal("BoatType");
                            int BoatLengthIndex = reader.GetOrdinal("BoatLength");
                            boats.Add(new BoatBLL
                            {
                                BoatId = reader.GetInt32(BoatIdIndex),
                                SSN = reader.GetString(SSNIndex),
                                BoatType = (BoatType)reader.GetInt32(BoatTypeIndex),
                                BoatLength   = reader.GetInt32(BoatLengthIndex),
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

        public IEnumerable<BoatBLL> GetAllBoats()
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var boats = new List<BoatBLL>(10);

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetAllBoats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int BoatIdIndex = reader.GetOrdinal("BoatId");
                            int SSNIndex = reader.GetOrdinal("SSN");
                            int BoatTypeIndex = reader.GetOrdinal("BoatType");
                            int BoatLengthIndex = reader.GetOrdinal("BoatLength");
                            boats.Add(new BoatBLL
                            {
                                BoatId = reader.GetInt32(BoatIdIndex),
                                SSN = reader.GetString(SSNIndex),
                                BoatType = (BoatType)reader.GetInt32(BoatTypeIndex),
                                BoatLength = reader.GetInt32(BoatLengthIndex),
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
