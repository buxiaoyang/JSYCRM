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
    /// 数据访问类z_r_role_menu。
    /// </summary>
    public class z_r_role_menu
    {
        public z_r_role_menu()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ROLE_ID, Guid MENU_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from z_r_role_menu");
            strSql.Append(" where ROLE_ID=@ROLE_ID and MENU_ID=@MENU_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier),
					new SqlParameter("@MENU_ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ROLE_ID;
            parameters[1].Value = MENU_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Models.z_r_role_menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into z_r_role_menu(");
            strSql.Append("ROLE_ID,MENU_ID)");
            strSql.Append(" values (");
            strSql.Append("@ROLE_ID,@MENU_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@MENU_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.ROLE_ID;
            parameters[1].Value = model.MENU_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Models.z_r_role_menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_r_role_menu set ");
            strSql.Append("ROLE_ID=@ROLE_ID,");
            strSql.Append("MENU_ID=@MENU_ID");
            strSql.Append(" where ROLE_ID=@ROLE_ID and MENU_ID=@MENU_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@MENU_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.ROLE_ID;
            parameters[1].Value = model.MENU_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(Guid ROLE_ID, Guid MENU_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from z_r_role_menu ");
            strSql.Append(" where ROLE_ID=@ROLE_ID and MENU_ID=@MENU_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier),
					new SqlParameter("@MENU_ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ROLE_ID;
            parameters[1].Value = MENU_ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DeleteByRoleID(string ROLE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from z_r_role_menu where ROLE_ID = '" + ROLE_ID + "' ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void DeleteByMenuID(string MENU_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from z_r_role_menu where MENU_ID = '" + MENU_ID + "' ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Models.z_r_role_menu GetModel(Guid ROLE_ID, Guid MENU_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ROLE_ID,MENU_ID from z_r_role_menu ");
            strSql.Append(" where ROLE_ID=@ROLE_ID and MENU_ID=@MENU_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.UniqueIdentifier),
					new SqlParameter("@MENU_ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ROLE_ID;
            parameters[1].Value = MENU_ID;

            Models.z_r_role_menu model = new Models.z_r_role_menu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ROLE_ID"].ToString() != "")
                {
                    model.ROLE_ID = new Guid(ds.Tables[0].Rows[0]["ROLE_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MENU_ID"].ToString() != "")
                {
                    model.MENU_ID = new Guid(ds.Tables[0].Rows[0]["MENU_ID"].ToString());
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
            strSql.Append("select ROLE_ID,MENU_ID ");
            strSql.Append(" FROM z_r_role_menu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetAssignList(string roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select z_r_role_menu.MENU_ID,z_menu.NAME  from z_r_role_menu  ");
            strSql.Append(" left join z_menu on z_r_role_menu.MENU_ID = z_menu.ID ");
            strSql.Append(" where ROLE_ID = '" + roleID + "' ");
            strSql.Append(" order by z_menu.MENU_ORDER ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetUnAssignList(string roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select T1.ID as MENU_ID, T1.NAME from z_menu as T1  ");
            strSql.Append(" where T1.ID not in ( ");
            strSql.Append(" select z_r_role_menu.MENU_ID from z_r_role_menu  ");
            strSql.Append(" left join z_menu on z_r_role_menu.MENU_ID = z_menu.ID ");
            strSql.Append(" where ROLE_ID = '" + roleID + "') ");
            strSql.Append(" order by T1.MENU_ORDER ");
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" ROLE_ID,MENU_ID ");
            strSql.Append(" FROM z_r_role_menu ");
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
            parameters[0].Value = "z_r_role_menu";
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