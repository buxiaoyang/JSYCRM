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
    /// 数据访问类z_menu。
    /// </summary>
    public class z_menu
    {
        public z_menu()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from z_menu");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Models.z_menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into z_menu(");
            strSql.Append("ID,NAME,DESCRIPTION,ALL_ACCESS_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@NAME,@DESCRIPTION,@ALL_ACCESS_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,100),
					new SqlParameter("@ALL_ACCESS_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.ALL_ACCESS_FLG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Models.z_menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_menu set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("DESCRIPTION=@DESCRIPTION,");
            strSql.Append("ALL_ACCESS_FLG=@ALL_ACCESS_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,100),
					new SqlParameter("@ALL_ACCESS_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.DESCRIPTION;
            parameters[3].Value = model.ALL_ACCESS_FLG;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from z_menu ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Models.z_menu GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,NAME,DESCRIPTION,ALL_ACCESS_FLG from z_menu ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = ID;

            Models.z_menu model = new Models.z_menu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = new Guid(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.DESCRIPTION = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                model.ALL_ACCESS_FLG = ds.Tables[0].Rows[0]["ALL_ACCESS_FLG"].ToString();
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
            strSql.Append(" select *, case  when ROOTMENU_ID is NULL then '1' else '2' end LEVEL from z_menu order by MENU_ORDER ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDropDownList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from z_menu where VALUE = '' and ROOTMENU_ID is null order by MENU_ORDER ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetMenuListByUserID(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct z_menu.* ");
            strSql.Append(" from z_menu ");
            strSql.Append(" left join z_r_role_menu on z_menu.ID = z_r_role_menu.MENU_ID ");
            strSql.Append(" left join z_role on z_r_role_menu.ROLE_ID = z_role.ID ");
            strSql.Append(" left join z_r_user_role on z_role.ID = z_r_user_role.ROLE_ID");
            strSql.Append(" left join z_user on z_r_user_role.USER_ID = z_user.ID ");
            strSql.Append(" where z_user.ID = '" + userID.ToString() + "' ");
            strSql.Append(" order by z_menu.MENU_ORDER");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JSYCRM.Models.z_menu DataRowToModel(DataRow row)
        {
            JSYCRM.Models.z_menu model = new JSYCRM.Models.z_menu();
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
                if (row["VALUE"] != null)
                {
                    model.VALUE = row["VALUE"].ToString();
                }
                if (row["DESCRIPTION"] != null)
                {
                    model.DESCRIPTION = row["DESCRIPTION"].ToString();
                }
                if (row["MENU_ORDER"] != null && row["MENU_ORDER"].ToString() != "")
                {
                    model.MENU_ORDER = int.Parse(row["MENU_ORDER"].ToString());
                }
                if (row["ALL_ACCESS_FLG"] != null)
                {
                    model.ALL_ACCESS_FLG = row["ALL_ACCESS_FLG"].ToString();
                }
                if (row["ROOTMENU_ID"] != null && row["ROOTMENU_ID"].ToString() != "")
                {
                    model.ROOTMENU_ID = new Guid(row["ROOTMENU_ID"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Models.z_menu> GetMenuModelListByUserID(Guid userID)
        {
            List<Models.z_menu> z_menu_list = new List<Models.z_menu>();
            DataSet ds = GetMenuListByUserID(userID);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.z_menu model_z_menu = DataRowToModel(row);
                z_menu_list.Add(model_z_menu);
            }
            return z_menu_list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAccessPageListByUserID(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct z_menu.* ");
            strSql.Append("from z_menu ");
            strSql.Append("left join z_r_role_menu on z_menu.ID = z_r_role_menu.MENU_ID ");
            strSql.Append("left join z_role on z_r_role_menu.ROLE_ID = z_role.ID ");
            strSql.Append("left join z_r_user_role on z_role.ID = z_r_user_role.ROLE_ID ");
            strSql.Append("left join z_user on z_r_user_role.USER_ID = z_user.ID ");
            strSql.Append("where ");
            strSql.Append("z_user.ID = '" + userID.ToString() + "' ");
            strSql.Append("or z_menu.ALL_ACCESS_FLG = 1");
            strSql.Append("order by z_menu.MENU_ORDER ");
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
            strSql.Append(" ID,NAME,DESCRIPTION,ALL_ACCESS_FLG ");
            strSql.Append(" FROM z_menu ");
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
            parameters[0].Value = "z_menu";
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