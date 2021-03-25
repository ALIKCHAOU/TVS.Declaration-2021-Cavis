using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TVS.Core;
using TVS.Core.Interfaces;
using TVS.Core.Models;
using TVS.Dapper.Settings;

namespace TVS.Dapper
{
    public partial class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public int Create(Employee employee)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryInsert, employee).SingleOrDefault();
            }
        }

        public void Update(Employee employee)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, employee);
            }
        }

        public void Delete(int empNo)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new {No = empNo});
            }
        }

        public Employee Get(int no)
        {
            const string query = @" WHERE Id = @No";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Employee>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public Employee Get(string cin, int societeNo)
        {
            const string query = @" WHERE Cin = @Cin AND SocieteNo = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Employee>(queryGet, new
                {
                    cin,
                    societeNo
                }).SingleOrDefault();

                return result;
            }
        }

        public IEnumerable<Employee> GetAll(int societeNo)
        {
            const string query = @" WHERE SocieteNo = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Employee>(queryGet, new
                {
                    societeNo
                });
                return result;
            }
        }
    }
}