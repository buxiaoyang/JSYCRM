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
    /// 数据访问类:m_worker_history
    /// </summary>
    public partial class m_worker_history
    {
        public m_worker_history()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from m_worker_history");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Models.m_worker_history model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_worker_history(");
            strSql.Append("ID,WORKER_ID,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@WORKER_ID,@COMMENTS,@CREATE_USER_ID,@CREATE_DATETIME,@UPDATE_USER_ID,@UPDATE_DATETIME,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@WORKER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@COMMENTS", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.WORKER_ID;
            parameters[2].Value = model.COMMENTS;
            parameters[3].Value = model.CREATE_USER_ID;
            parameters[4].Value = model.CREATE_DATETIME;
            parameters[5].Value = model.UPDATE_USER_ID;
            parameters[6].Value = model.UPDATE_DATETIME;
            parameters[7].Value = model.DELETE_FLG;

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
        public bool Update(Models.m_worker_history model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_worker_history set ");
            strSql.Append("WORKER_ID=@WORKER_ID,");
            strSql.Append("COMMENTS=@COMMENTS,");
            strSql.Append("CREATE_USER_ID=@CREATE_USER_ID,");
            strSql.Append("CREATE_DATETIME=@CREATE_DATETIME,");
            strSql.Append("UPDATE_USER_ID=@UPDATE_USER_ID,");
            strSql.Append("UPDATE_DATETIME=@UPDATE_DATETIME,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WORKER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@COMMENTS", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.WORKER_ID;
            parameters[1].Value = model.COMMENTS;
            parameters[2].Value = model.CREATE_USER_ID;
            parameters[3].Value = model.CREATE_DATETIME;
            parameters[4].Value = model.UPDATE_USER_ID;
            parameters[5].Value = model.UPDATE_DATETIME;
            parameters[6].Value = model.DELETE_FLG;
            parameters[7].Value = model.ID;

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
            strSql.Append("delete from m_worker_history ");
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
            strSql.Append("delete from m_worker_history ");
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
        public Models.m_worker_history GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,WORKER_ID,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG from m_worker_history ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            Models.m_worker_history model = new Models.m_worker_history();
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
        public Models.m_worker_history DataRowToModel(DataRow row)
        {
            Models.m_worker_history model = new Models.m_worker_history();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["WORKER_ID"] != null && row["WORKER_ID"].ToString() != "")
                {
                    model.WORKER_ID = new Guid(row["WORKER_ID"].ToString());
                }
                if (row["COMMENTS"] != null)
                {
                    model.COMMENTS = row["COMMENTS"].ToString();
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
                }
                catch { }
                try
                {
                    if (row["UPDATE_USER"] != null)
                    {
                        model.UPDATE_USER = row["UPDATE_USER"].ToString();
                    }
                }
                catch { }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,WORKER_ID,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM m_worker_history ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(Guid workerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*, b.LAST_NAME as CREATE_USER, c.LAST_NAME as UPDATE_USER ");
            strSql.Append(" from dbo.m_worker_history as a ");
            strSql.Append(" left join dbo.z_user as b on a.CREATE_USER_ID = b.ID ");
            strSql.Append(" left join dbo.z_user as c on a.UPDATE_USER_ID = c.ID ");
            strSql.Append(" where a.WORKER_ID = '"+workerID.ToString()+"' ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Models.m_worker_history> GetModelList(Guid workerID)
        {
            List<Models.m_worker_history> z_m_worker_history_list = new List<Models.m_worker_history>();
            DataSet ds = GetList(workerID);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.m_worker_history z_m_worker_history = DataRowToModel(row);
                z_m_worker_history_list.Add(z_m_worker_history);
            }
            return z_m_worker_history_list;
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
            strSql.Append(" ID,WORKER_ID,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM m_worker_history ");
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
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM m_worker_history ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from m_worker_history T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "m_worker_history";
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