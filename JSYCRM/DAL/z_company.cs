using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace JSYCRM.DAL
{
    /// <summary>
    /// z_company
    /// </summary>
    public class z_company
    {
        public z_company()
        { }
        #region

        /// <summary>
        /// 
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from z_company");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 
        /// </summary>
        public void Add(Models.z_company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into z_company(");
            strSql.Append("ID,COMPANY_NAME,COMPANY_DESCRIPTION,PO_NUMBER,COMPANY_INFO,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@COMPANY_NAME,@COMPANY_DESCRIPTION,@PO_NUMBER,@COMPANY_INFO,@CREATE_USER_ID,@CREATE_DATETIME,@UPDATE_USER_ID,@UPDATE_DATETIME,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@COMPANY_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@COMPANY_DESCRIPTION", SqlDbType.NVarChar,200),
					new SqlParameter("@PO_NUMBER", SqlDbType.NVarChar,100),
					new SqlParameter("@COMPANY_INFO", SqlDbType.NVarChar,500),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.COMPANY_NAME;
            parameters[2].Value = model.COMPANY_DESCRIPTION;
            parameters[3].Value = model.PO_NUMBER;
            parameters[4].Value = model.COMPANY_INFO;
            parameters[5].Value = model.CREATE_USER_ID;
            parameters[6].Value = model.CREATE_DATETIME;
            parameters[7].Value = model.UPDATE_USER_ID;
            parameters[8].Value = model.UPDATE_DATETIME;
            parameters[9].Value = model.DELETE_FLG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Update(Models.z_company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_company set ");
            strSql.Append("COMPANY_NAME=@COMPANY_NAME,");
            strSql.Append("COMPANY_DESCRIPTION=@COMPANY_DESCRIPTION,");
            strSql.Append("PO_NUMBER=@PO_NUMBER,");
            strSql.Append("COMPANY_INFO=@COMPANY_INFO,");
            strSql.Append("CREATE_USER_ID=@CREATE_USER_ID,");
            strSql.Append("CREATE_DATETIME=@CREATE_DATETIME,");
            strSql.Append("UPDATE_USER_ID=@UPDATE_USER_ID,");
            strSql.Append("UPDATE_DATETIME=@UPDATE_DATETIME,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@COMPANY_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@COMPANY_DESCRIPTION", SqlDbType.NVarChar,200),
					new SqlParameter("@PO_NUMBER", SqlDbType.NVarChar,100),
					new SqlParameter("@COMPANY_INFO", SqlDbType.NVarChar,500),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.COMPANY_NAME;
            parameters[2].Value = model.COMPANY_DESCRIPTION;
            parameters[3].Value = model.PO_NUMBER;
            parameters[4].Value = model.COMPANY_INFO;
            parameters[5].Value = model.CREATE_USER_ID;
            parameters[6].Value = model.CREATE_DATETIME;
            parameters[7].Value = model.UPDATE_USER_ID;
            parameters[8].Value = model.UPDATE_DATETIME;
            parameters[9].Value = model.DELETE_FLG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(String ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update z_company set DELETE_FLG = '1' where ID ='" + ID + "' ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 
        /// </summary>
        public Models.z_company GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,COMPANY_NAME,COMPANY_DESCRIPTION,PO_NUMBER,COMPANY_INFO,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG from z_company ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            Models.z_company model = new Models.z_company();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = new Guid(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.COMPANY_NAME = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                model.COMPANY_DESCRIPTION = ds.Tables[0].Rows[0]["COMPANY_DESCRIPTION"].ToString();
                model.PO_NUMBER = ds.Tables[0].Rows[0]["PO_NUMBER"].ToString();
                model.COMPANY_INFO = ds.Tables[0].Rows[0]["COMPANY_INFO"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_USER_ID"].ToString() != "")
                {
                    model.CREATE_USER_ID = new Guid(ds.Tables[0].Rows[0]["CREATE_USER_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CREATE_DATETIME"].ToString() != "")
                {
                    model.CREATE_DATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATETIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UPDATE_USER_ID"].ToString() != "")
                {
                    model.UPDATE_USER_ID = new Guid(ds.Tables[0].Rows[0]["UPDATE_USER_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UPDATE_DATETIME"].ToString() != "")
                {
                    model.UPDATE_DATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["UPDATE_DATETIME"].ToString());
                }
                model.DELETE_FLG = ds.Tables[0].Rows[0]["DELETE_FLG"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetDropDownList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ID,COMPANY_NAME ");
            strSql.Append(" FROM z_company ");
            strSql.Append(" where DELETE_FLG <> 1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dbo.z_company where DELETE_FLG <>1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetFilterList(string companyName, string companyPO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dbo.z_company where DELETE_FLG <>1 ");
            if (companyName != "")
            {
                strSql.Append(" and COMPANY_NAME like '%" + companyName + "%' ");
            }
            if (companyPO != "")
            {
                strSql.Append(" and PO_NUMBER like '%" + companyPO + "%' ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "z_company";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion
    }
}