﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoConcord
{

    internal class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _conn;
        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * from Departments");
        }
        public void InsertDepartments(string newDepartmentName)
        {
            _conn.Execute("Insert Into department(name) values (@department)",
                new { departmentName = newDepartmentName });
        }
    }
}

