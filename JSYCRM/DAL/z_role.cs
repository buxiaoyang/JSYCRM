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
    /// 数据访问类z_role。
    /// </summary>
    public class z_role
    {
        public z_role()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from z_role");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Models.z_role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into z_role(");
            strSql.Append("ID,NAME,DESCRIPTION,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@NAME,@DESCRIPTION,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,100),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.DELETE_FLG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Models.z_role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_role set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("DESCRIPTION=@DESCRIPTION,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,100),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.DELETE_FLG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from z_role ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Models.z_role GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,NAME,DESCRIPTION,DELETE_FLG from z_role ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            Models.z_role model = new Models.z_role();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = new Guid(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.DELETE_FLG = ds.Tables[0].Rows[0]["DELETE_FLG"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from z_role where DELETE_FLG <>1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(Guid USER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select b.* from z_r_user_role as a ");
            strSql.Append(" left join z_role as b on a.ROLE_ID = b.ID ");
            strSql.Append(" where a.USER_ID = '" + USER_ID.ToString() + "' ");
            strSql.Append(" and b.DELETE_FLG <>1 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Models.z_role> GetModelList(Guid USER_ID)
        {
            List<Models.z_role> z_role_list = new List<Models.z_role>();
            DataSet ds = GetList(USER_ID);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.z_role model_z_role = DataRowToModel(row);
                z_role_list.Add(model_z_role);
            }
            return z_role_list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Models.z_role> GetModelList()
        {
            List<Models.z_role> z_role_list = new List<Models.z_role>();
            DataSet ds = GetList();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.z_role model_z_role = DataRowToModel(row);
                z_role_list.Add(model_z_role);
            }
            return z_role_list;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JSYCRM.Models.z_role DataRowToModel(DataRow row)
        {
            JSYCRM.Models.z_role model = new JSYCRM.Models.z_role();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["NAME"] != null)
                {
                    model.NAME = row["NAME"].ToString();
                }
                if (row["DESCRIPTION"] != null)
                {
                    model.DESCRIPTION = row["DESCRIPTION"].ToString();
                }
                if (row["DELETE_FLG"] != null)
                {
                    model.DELETE_FLG = row["DELETE_FLG"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,NAME,DESCRIPTION,DELETE_FLG ");
            strSql.Append(" FROM z_role ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
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
            parameters[0].Value = "z_role";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}