using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace BIG
{
    public class MySqlHelper
    {
        private readonly MySqlConnection _connection;

        private readonly MySqlCommand _command;

        private readonly string _connectionString;

        public MySqlHelper(string connectionString)
        {
           // _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringKey].ToString();
            _connectionString = connectionString;
            _connection = new MySqlConnection(_connectionString);
            _command = new MySqlCommand("", _connection);
        }

        public MySqlDataReader ExecuteReader(string cmdText)
        {
            try
            {
                _connection.Open();
                _command.CommandText = cmdText;
                return _command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (MySqlException)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                return null;
            }
        }

        public object ExecuteScalar(string cmdText)
        {
            try
            {
                _connection.Open();
                _command.CommandText = cmdText;
                return _command.ExecuteScalar();
            }
            catch (MySqlException)
            {
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool ExecuteNonQuery(string cmdText, List<MySqlParameter> parameters)
        {
            try
            {
                _connection.Open();
                _command.CommandText = cmdText;
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Add(parameters);
                return _command.ExecuteNonQuery() > 0;
            }
            catch (MySqlException)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool ExecuteNonQuery(string cmdText)
        {
            try
            {
                _connection.Open();
                _command.CommandText = cmdText;
                return _command.ExecuteNonQuery() > 0;
            }
            catch (MySqlException)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Statistic(string url)
        {
            var count = Convert.ToInt32(ExecuteScalar("select count(*) from big_statistics_click where vdate='" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "' and pn='" + url + "'"));
            var str = count > 0
                          ? "update big_statistics_click set pv=pv+1  where  vdate='" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day +
                            "' and pn='" + url + "'"
                          : "insert into big_statistics_click(vdate,pn,pv) values('" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "','" + url + "',1)";
            ExecuteNonQuery(str);
        }

        public void StatisticLogin(string loginname,string name,string role,string department)
        {
            var sql = "insert into big_loginstatistics(loginname,name,role,department,logintime) values('"+loginname+"','" + name + "','" + role + "','" + department + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            ExecuteNonQuery(sql);
        }

        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                _connection.Open();
                var myDa = new MySqlDataAdapter(sql, _connection);
                var myds = new DataSet();
                myDa.Fill(myds);
                return myds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public string StatisticDengji(string loginname)
        {
            var reader = ExecuteReader("select logintime from big_loginstatistics a where a.loginname='" + loginname + "'");
            List<string> list = null;
            if (reader != null)
            {
                list = new List<string>();
                while (reader.Read())
                {
                    list.Add(Convert.ToDateTime(reader["logintime"]).ToString("yyyy-MM-dd"));
                }
                reader.Close();
            }
            if (list != null)
                return list.Distinct().Count() + "";
            return "0";
        }

        public void Close()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
    }
}