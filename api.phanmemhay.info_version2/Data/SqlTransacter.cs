using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Data
{
    public class SqlTransacter : ISqlTransacter
    {
        public IConfiguration _Configuration { get; set; }
        public SqlTransacter(IConfiguration Configuration)
        {
            this._Configuration = Configuration;
        }
        public bool Query(string query)
        {
            try
            {
                string sqlDatasource = _Configuration.GetConnectionString("sql");
                using (SqlConnection myCon = new SqlConnection(sqlDatasource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.ExecuteReader();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Dictionary<string, object> QueryForObject(string query)
        {
            Dictionary<string, object> result = null;
            string sqlDatasource = _Configuration.GetConnectionString("sql");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    if (myReader != null && myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            int col_Count = myReader.FieldCount;
                            for (int i = 0; i < col_Count; i++)
                            {
                                string colname = myReader.GetName(i);
                                object value = myReader.GetValue(i);
                                dic.Add(colname, value);
                            }
                            result = dic;
                            break;
                        }
                        myReader.Close();
                    }
                    myCon.Close();
                }
            }
            return result;
        }
        public List<Dictionary<string, object>> QueryForList(string query)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            string sqlDatasource = _Configuration.GetConnectionString("sql");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    if (myReader != null && myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            int col_Count = myReader.FieldCount;
                            for (int i = 0; i < col_Count; i++)
                            {
                                string colname = myReader.GetName(i);
                                object value = myReader.GetValue(i);
                                dic.Add(colname, value);
                            }
                            result.Add(dic);
                        }
                        myReader.Close();
                    }
                    myCon.Close();
                }
            }
            return result;
        }
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Dictionary<string, object> dic, string action = "insert")
        {
            throw new NotImplementedException();
        }
        public int Update(Dictionary<string, object> dic, string action = "update")
        {
            throw new NotImplementedException();
        }
    }
}
