﻿using BanHangThep.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangThep.Class
{
    class LinQConnection
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(LinQConnection).Name);

        public static int ExecuteCommand(string sql)
        {
            int result = 0;
            BHTHepDataContext db = new BHTHepDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                //log.Error("LinQConnection ExecuteCommand : " + sql);
                //log.Error("LinQConnection ExecuteCommand : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int ExecuteCommand_(string sql)
        {
            int result = 0;
            BHTHepDataContext db = new BHTHepDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                //log.Error("LinQConnection ExecuteCommand_ : " + sql);
                //log.Error("LinQConnection ExecuteCommand_ : " + ex.Message);

            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }
        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            BHTHepDataContext db = new BHTHepDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                //log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }
        public static DataSet getDataSet(string sql, string table)
        {
            BHTHepDataContext db = new BHTHepDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, table);
                db.Connection.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                //log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return null;
        }


        public static DataTable getDataTable(string sql, int FirstRow, int pageSize)
        {
            BHTHepDataContext db = new BHTHepDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                //log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return null;
        }

        public static void ExecuteStoredProcedure(string storedNam, int ky, int nam)
        {
            BHTHepDataContext db = new BHTHepDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _ky = cmd.Parameters.Add("@KY", SqlDbType.Int);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = ky;

                SqlParameter _nam = cmd.Parameters.Add("@NAM", SqlDbType.Int);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = nam;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void ExecuteStoredProcedure(string storedNam)
        {
            BHTHepDataContext db = new BHTHepDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
              //  log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public static void ExecuteStoredProcedure_TK(string storedNam, string hieuluc, string tungay, string denngay)
        {
            BHTHepDataContext db = new BHTHepDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _ky = cmd.Parameters.Add("@TUNGAY", SqlDbType.VarChar);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = tungay;

                SqlParameter _nam = cmd.Parameters.Add("@DENNGAY", SqlDbType.VarChar);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = denngay;

                SqlParameter _hl = cmd.Parameters.Add("@HIEULUC", SqlDbType.VarChar);
                _hl.Direction = ParameterDirection.Input;
                _hl.Value = hieuluc;


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
