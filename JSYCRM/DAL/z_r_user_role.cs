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
    /// 数据访问类z_r_user_role。
    /// </summary>
    public class z_r_user_role
    {
        public z_r_user_role()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid USER_ID, Guid ROLE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from z_r_user_role");
            strSql.Append(" where USER_ID=@USER_ID and ROLE_ID=@ROLE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier),
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = USER_ID;
            parameters[1].Value = ROLE_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Models.z_r_user_role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into z_r_user_role(");
            strSql.Append("USER_ID,ROLE_ID)");
            strSql.Append(" values (");
            strSql.Append("@USER_ID,@ROLE_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.ROLE_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加多条数据
        /// </summary>
        public void Add(String USER_ID, String ROLE_ID)
        {
            String[] ROLE_ID_LIST = ROLE_ID.Split(',');
            foreach (String ROLE_ID_ITEM in ROLE_ID_LIST)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into z_r_user_role(");
                strSql.Append("USER_ID,ROLE_ID)");
                strSql.Append(" values (");
                strSql.Append("@USER_ID,@ROLE_ID)");
                SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier,16)};
                parameters[0].Value = new Guid(USER_ID.Trim());
                parameters[1].Value = new Guid(ROLE_ID_ITEM.Trim());
                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }    
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Models.z_r_user_role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_r_user_role set ");
            strSql.Append("USER_ID=@USER_ID,");
            strSql.Append("ROLE_ID=@ROLE_ID");
            strSql.Append(" where USER_ID=@USER_ID and ROLE_ID=@ROLE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.ROLE_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(Guid USER_ID, Guid ROLE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from z_r_user_role ");
            strSql.Append(" where USER_ID=@USER_ID and ROLE_ID=@ROLE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier),
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = USER_ID;
            parameters[1].Value = ROLE_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Models.z_r_user_role GetModel(Guid USER_ID, Guid ROLE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 USER_ID,ROLE_ID from z_r_user_role ");
            strSql.Append(" where USER_ID=@USER_ID and ROLE_ID=@ROLE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier),
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = USER_ID;
            parameters[1].Value = ROLE_ID;

            Models.z_r_user_role model = new Models.z_r_user_role();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["USER_ID"].ToString() != "")
                {
                    model.USER_ID = new Guid(ds.Tables[0].Rows[0]["USER_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ROLE_ID"].ToString() != "")
                {
                    model.ROLE_ID = new Guid(ds.Tables[0].Rows[0]["ROLE_ID"].ToString());
                }
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USER_ID,ROLE_ID ");
            strSql.Append(" FROM z_r_user_role ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetAssignList(String userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct z_r_user_role.ROLE_ID, z_role.NAME from z_r_user_role  ");
            strSql.Append(" left join z_role on  ");
            strSql.Append(" z_r_user_role.ROLE_ID = z_role.ID ");
            strSql.Append(" where z_r_user_role.USER_ID = '" + userId + "' ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetUnAssignList(String userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select T1.ID as ROLE_ID, T1.NAME from z_role as T1 where T1.ID not in ( ");
            strSql.Append(" select distinct z_r_user_role.ROLE_ID from z_r_user_role  ");
            strSql.Append(" left join z_role on  ");
            strSql.Append(" z_r_user_role.ROLE_ID = z_role.ID ");
            strSql.Append(" where z_r_user_role.USER_ID = '" + userId + "') ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public void DeleteRoleByUserID(string userID)
        {
            string strSql = "delete from z_r_user_role where USER_ID = '" + userID + "'";
            DbHelperSQL.ExecuteSql(strSql);
        }

        public void DeleteByRoleID(string roleID)
        {
            string strSql = "delete from z_r_user_role where ROLE_ID = '" + roleID + "'";
            DbHelperSQL.ExecuteSql(strSql);
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
            strSql.Append(" USER_ID,ROLE_ID ");
            strSql.Append(" FROM z_r_user_role ");
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
            parameters[0].Value = "z_r_user_role";
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