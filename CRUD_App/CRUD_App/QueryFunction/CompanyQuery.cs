using CRUD_App.ExecuteFunction;
using CRUD_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUD_App.QueryFunction
{
    public class CompanyQuery
    {
        Execute execute = new Execute();
        public DataTable GetCompanyDetails(int id = 0)
        {
            DataTable dt = new DataTable();
            string Query = "Select * from CompanyDetails";

            if (id > 0)
            {
                Query += " where id=" + id;
            }
            dt = execute.ExcuteDatatble(Query);

            return dt;
        }

        public int InsertData(CompanyModel Model)
        {
            string query = "Insert Into CompanyDetails(Comp_Name,Strength,Remarks) values('" + Model.Comp_Name + "','" + Model.Stength + "',";
            query += "'" + Model.Remarks + "') If(@@Error=0) Select 1 else Select 0";
            int Res = execute.Excuteint(query);
            return Res;
        }

        public int UpdateData(CompanyModel Model)
        {
            string query = "Update CompanyDetails Set Strength= '" + Model.Stength + "' Remarks='" + Model.Remarks + "' where id= '" + Model.Comp_No + "'";
            query += " If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);

            return Res;
        }

        public int DeleteData(int Id)
        {
            string query = "Delete From CompanyDetails Where id=" + Id;
            query += " If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);

            return Res;
        }
    }
}