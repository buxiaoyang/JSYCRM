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
    /// 数据访问类:m_announcement
    /// </summary>
    public partial class m_announcement
    {
        public m_announcement()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from m_announcement");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Models.m_announcement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_announcement(");
            strSql.Append("ID,TITLE,TITLE_COLOR,PUBLISH,SHOW_IN_LOGIN,DEPARTMENT,BODY,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@TITLE,@TITLE_COLOR,@PUBLISH,@SHOW_IN_LOGIN,@DEPARTMENT,@BODY,@CREATE_USER_ID,@CREATE_DATETIME,@UPDATE_USER_ID,@UPDATE_DATETIME,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@TITLE", SqlDbType.NVarChar,100),
					new SqlParameter("@TITLE_COLOR", SqlDbType.NVarChar,50),
					new SqlParameter("@PUBLISH", SqlDbType.NVarChar,50),
					new SqlParameter("@SHOW_IN_LOGIN", SqlDbType.NVarChar,50),
					new SqlParameter("@DEPARTMENT", SqlDbType.NVarChar,200),
					new SqlParameter("@BODY", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.TITLE;
            parameters[2].Value = model.TITLE_COLOR;
            parameters[3].Value = model.PUBLISH;
            parameters[4].Value = model.SHOW_IN_LOGIN;
            parameters[5].Value = model.DEPARTMENT;
            parameters[6].Value = model.BODY;
            parameters[7].Value = model.CREATE_USER_ID;
            parameters[8].Value = model.CREATE_DATETIME;
            parameters[9].Value = model.UPDATE_USER_ID;
            parameters[10].Value = model.UPDATE_DATETIME;
            parameters[11].Value = model.DELETE_FLG;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Models.m_announcement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_announcement set ");
            strSql.Append("TITLE=@TITLE,");
            strSql.Append("TITLE_COLOR=@TITLE_COLOR,");
            strSql.Append("PUBLISH=@PUBLISH,");
            strSql.Append("SHOW_IN_LOGIN=@SHOW_IN_LOGIN,");
            strSql.Append("DEPARTMENT=@DEPARTMENT,");
            strSql.Append("BODY=@BODY,");
            strSql.Append("CREATE_USER_ID=@CREATE_USER_ID,");
            strSql.Append("CREATE_DATETIME=@CREATE_DATETIME,");
            strSql.Append("UPDATE_USER_ID=@UPDATE_USER_ID,");
            strSql.Append("UPDATE_DATETIME=@UPDATE_DATETIME,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TITLE", SqlDbType.NVarChar,100),
					new SqlParameter("@TITLE_COLOR", SqlDbType.NVarChar,50),
					new SqlParameter("@PUBLISH", SqlDbType.NVarChar,50),
					new SqlParameter("@SHOW_IN_LOGIN", SqlDbType.NVarChar,50),
					new SqlParameter("@DEPARTMENT", SqlDbType.NVarChar,200),
					new SqlParameter("@BODY", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.TITLE;
            parameters[1].Value = model.TITLE_COLOR;
            parameters[2].Value = model.PUBLISH;
            parameters[3].Value = model.SHOW_IN_LOGIN;
            parameters[4].Value = model.DEPARTMENT;
            parameters[5].Value = model.BODY;
            parameters[6].Value = model.CREATE_USER_ID;
            parameters[7].Value = model.CREATE_DATETIME;
            parameters[8].Value = model.UPDATE_USER_ID;
            parameters[9].Value = model.UPDATE_DATETIME;
            parameters[10].Value = model.DELETE_FLG;
            parameters[11].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_announcement ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_announcement ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Models.m_announcement GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TT.*, CC.LAST_NAME as CREATE_USER, UU.LAST_NAME as UPDATE_USER  from m_announcement as TT ");
            strSql.Append(" left join z_user as CC on TT.CREATE_USER_ID = CC.ID  ");
            strSql.Append(" left join z_user as UU on TT.UPDATE_USER_ID = UU.ID  ");
            strSql.Append(" where TT.ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            Models.m_announcement model = new Models.m_announcement();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Models.m_announcement DataRowToModel(DataRow row)
        {
            Models.m_announcement model = new Models.m_announcement();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["TITLE"] != null)
                {
                    model.TITLE = row["TITLE"].ToString();
                }
                if (row["TITLE_COLOR"] != null)
                {
                    model.TITLE_COLOR = row["TITLE_COLOR"].ToString();
                }
                if (row["PUBLISH"] != null)
                {
                    model.PUBLISH = row["PUBLISH"].ToString();
                }
                if (row["SHOW_IN_LOGIN"] != null)
                {
                    model.SHOW_IN_LOGIN = row["SHOW_IN_LOGIN"].ToString();
                }
                if (row["DEPARTMENT"] != null)
                {
                    model.DEPARTMENT = row["DEPARTMENT"].ToString();
                }
                if (row["BODY"] != null)
                {
                    model.BODY = row["BODY"].ToString();
                }
                if (row["CREATE_USER_ID"] != null && row["CREATE_USER_ID"].ToString() != "")
                {
                    model.CREATE_USER_ID = new Guid(row["CREATE_USER_ID"].ToString());
                }
                if (row["CREATE_DATETIME"] != null && row["CREATE_DATETIME"].ToString() != "")
                {
                    model.CREATE_DATETIME = DateTime.Parse(row["CREATE_DATETIME"].ToString());
                }
                if (row["UPDATE_USER_ID"] != null && row["UPDATE_USER_ID"].ToString() != "")
                {
                    model.UPDATE_USER_ID = new Guid(row["UPDATE_USER_ID"].ToString());
                }
                if (row["UPDATE_DATETIME"] != null && row["UPDATE_DATETIME"].ToString() != "")
                {
                    model.UPDATE_DATETIME = DateTime.Parse(row["UPDATE_DATETIME"].ToString());
                }
                if (row["DELETE_FLG"] != null)
                {
                    model.DELETE_FLG = row["DELETE_FLG"].ToString();
                }
                try
                {
                    if (row["CREATE_USER"] != null)
                    {
                        model.CREATE_USER = row["CREATE_USER"].ToString();
                    }
                    if (row["UPDATE_USER"] != null)
                    {
                        model.UPDATE_USER = row["UPDATE_USER"].ToString();
                    }
                }
                catch
                { 
                
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TITLE,TITLE_COLOR,PUBLISH,SHOW_IN_LOGIN,DEPARTMENT,BODY,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM m_announcement ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" ID,TITLE,TITLE_COLOR,PUBLISH,SHOW_IN_LOGIN,DEPARTMENT,BODY,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM m_announcement ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string TITLE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM m_announcement ");
            if (TITLE != "" && TITLE != null)
            {
                strSql.Append("where TITLE like '%" + TITLE.Trim() + "%'");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.*, CC.LAST_NAME as CREATE_USER, UU.LAST_NAME as UPDATE_USER FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from m_announcement T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join z_user as CC on TT.CREATE_USER_ID = CC.ID  ");
            strSql.Append(" left join z_user as UU on TT.UPDATE_USER_ID = UU.ID ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Models.m_announcement> GetListModelByPage(string TITLE, int startIndex, int endIndex)
        {
            String where = "";
            if (TITLE != "" && TITLE != null)
            {
                where = "TITLE like '%" + TITLE.Trim() + "%'";
            }
            List<Models.m_announcement> m_announcement_list = new List<Models.m_announcement>();
            DataSet ds = GetListByPage(where, "CREATE_DATETIME desc", startIndex, endIndex);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.m_announcement model_m_announcement = DataRowToModel(row);
                m_announcement_list.Add(model_m_announcement);
            }
            return m_announcement_list;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Models.m_announcement> GetListModelByPage(bool isLoginPage)
        {
            String where = "PUBLISH = '发布中'";
            if (isLoginPage)
            {
                where = "SHOW_IN_LOGIN = '显示' and PUBLISH = '发布中'";
            }
            List<Models.m_announcement> m_announcement_list = new List<Models.m_announcement>();
            DataSet ds = GetListByPage(where, "CREATE_DATETIME desc", 0, 100);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.m_announcement model_m_announcement = DataRowToModel(row);
                m_announcement_list.Add(model_m_announcement);
            }
            return m_announcement_list;
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
            parameters[0].Value = "m_announcement";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}