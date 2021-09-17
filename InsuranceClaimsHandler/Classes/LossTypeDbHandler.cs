using InsuranceClaimsHandler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandler.Classes
{
    public class LossTypeDbHandler
    {
        public List<LossTypeModel> AllLossTypeData()
        {
            DataTable dt = RetrieveAllLossTypeData();

            List<LossTypeModel> lossTypes = new List<LossTypeModel>();

            foreach (DataRow row in dt.Rows)
            {
                LossTypeModel lossTypeData = new LossTypeModel();

                lossTypeData.LossTypeId = (int)row["LossTypeId"];
                lossTypeData.LossTypeCode = row["LossTypeCode"].ToString();
                lossTypeData.LossTypeDesc = row["LossTypeDescription"].ToString();
                lossTypeData.Active = (bool)row["Active"];
                lossTypeData.LastUpdatedDate = (DateTime)row["LastUpdatedDate"];
                lossTypeData.LastUpdatedId = (int)row["LastUpdatedId"];
                lossTypeData.CreatedDate = (DateTime)row["CreatedDate"];
                lossTypeData.CreatedId = (int)row["CreatedId"];

                lossTypes.Add(lossTypeData);
            }

            return lossTypes;
        }

        private DataTable RetrieveAllLossTypeData()
        {
            DataTable dt = new DataTable();

            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connectionString = $@"Server=interview-testing-server.database.windows.net; Database=Interview; User Id=TestLogin; Password=5D9ej2G64s3sd^;";
            sql = $"select * from LossTypes";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection!");
            }

            return dt;
        }

        public LossTypeModel LossTypeData(int lossTypeId)
        {
            DataTable dt = RetrieveLossTypeData(lossTypeId);

            var lossData = new LossTypeModel();

            lossData.LossTypeId = (int)dt.Rows[0]["LossTypeId"];
            lossData.LossTypeCode = dt.Rows[0]["LossTypeCode"].ToString();
            lossData.LossTypeDesc = dt.Rows[0]["LossTypeDescription"].ToString();
            lossData.Active = (bool)dt.Rows[0]["Active"];
            lossData.LastUpdatedDate = (DateTime)dt.Rows[0]["LastUpdatedDate"];
            lossData.LastUpdatedId = (int)dt.Rows[0]["LastUpdatedId"];
            lossData.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
            lossData.CreatedId = (int)dt.Rows[0]["CreatedId"];

            return lossData;
        }

        private DataTable RetrieveLossTypeData(int lossTypeId)
        {
            DataTable dt = new DataTable();

            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connectionString = $@"Server=interview-testing-server.database.windows.net; Database=Interview; User Id=TestLogin; Password=5D9ej2G64s3sd^;";
            sql = $"select * from LossTypes where LossTypeId = {lossTypeId}";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection!");
            }

            return dt;
        }

    }
}
