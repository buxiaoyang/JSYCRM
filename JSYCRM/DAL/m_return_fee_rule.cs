using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JSYCRM.DAL
{
    /// <summary>
    /// 数据访问类:m_return_fee_rule
    /// </summary>
    public partial class m_return_fee_rule
    {
        public m_return_fee_rule()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from m_return_fee_rule");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Models.m_return_fee_rule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_return_fee_rule(");
            strSql.Append("ID,USER_ID,AREA_ID,NUMBER,TIME_START,TIME_END,STATUS,DAYS,FEE_MEN,FEE_WOMEN,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@USER_ID,@AREA_ID,@NUMBER,@TIME_START,@TIME_END,@STATUS,@DAYS,@FEE_MEN,@FEE_WOMEN,@COMMENTS,@CREATE_USER_ID,@CREATE_DATETIME,@UPDATE_USER_ID,@UPDATE_DATETIME,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@AREA_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NUMBER", SqlDbType.Int,4),
					new SqlParameter("@TIME_START", SqlDbType.DateTime),
					new SqlParameter("@TIME_END", SqlDbType.DateTime),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@DAYS", SqlDbType.Int,4),
					new SqlParameter("@FEE_MEN", SqlDbType.Float,8),
					new SqlParameter("@FEE_WOMEN", SqlDbType.Float,8),
					new SqlParameter("@COMMENTS", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.USER_ID;
            parameters[2].Value = model.AREA_ID;
            parameters[3].Value = model.NUMBER;
            parameters[4].Value = model.TIME_START;
            parameters[5].Value = model.TIME_END;
            parameters[6].Value = model.STATUS;
            parameters[7].Value = model.DAYS;
            parameters[8].Value = model.FEE_MEN;
            parameters[9].Value = model.FEE_WOMEN;
            parameters[10].Value = model.COMMENTS;
            parameters[11].Value = model.CREATE_USER_ID;
            parameters[12].Value = model.CREATE_DATETIME;
            parameters[13].Value = model.UPDATE_USER_ID;
            parameters[14].Value = model.UPDATE_DATETIME;
            parameters[15].Value = model.DELETE_FLG;

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
        public bool Update(Models.m_return_fee_rule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_return_fee_rule set ");
            strSql.Append("USER_ID=@USER_ID,");
            strSql.Append("AREA_ID=@AREA_ID,");
            strSql.Append("NUMBER=@NUMBER,");
            strSql.Append("TIME_START=@TIME_START,");
            strSql.Append("TIME_END=@TIME_END,");
            strSql.Append("STATUS=@STATUS,");
            strSql.Append("DAYS=@DAYS,");
            strSql.Append("FEE_MEN=@FEE_MEN,");
            strSql.Append("FEE_WOMEN=@FEE_WOMEN,");
            strSql.Append("COMMENTS=@COMMENTS,");
            strSql.Append("CREATE_USER_ID=@CREATE_USER_ID,");
            strSql.Append("CREATE_DATETIME=@CREATE_DATETIME,");
            strSql.Append("UPDATE_USER_ID=@UPDATE_USER_ID,");
            strSql.Append("UPDATE_DATETIME=@UPDATE_DATETIME,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@AREA_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NUMBER", SqlDbType.Int,4),
					new SqlParameter("@TIME_START", SqlDbType.DateTime),
					new SqlParameter("@TIME_END", SqlDbType.DateTime),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@DAYS", SqlDbType.Int,4),
					new SqlParameter("@FEE_MEN", SqlDbType.Float,8),
					new SqlParameter("@FEE_WOMEN", SqlDbType.Float,8),
					new SqlParameter("@COMMENTS", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.AREA_ID;
            parameters[2].Value = model.NUMBER;
            parameters[3].Value = model.TIME_START;
            parameters[4].Value = model.TIME_END;
            parameters[5].Value = model.STATUS;
            parameters[6].Value = model.DAYS;
            parameters[7].Value = model.FEE_MEN;
            parameters[8].Value = model.FEE_WOMEN;
            parameters[9].Value = model.COMMENTS;
            parameters[10].Value = model.CREATE_USER_ID;
            parameters[11].Value = model.CREATE_DATETIME;
            parameters[12].Value = model.UPDATE_USER_ID;
            parameters[13].Value = model.UPDATE_DATETIME;
            parameters[14].Value = model.DELETE_FLG;
            parameters[15].Value = model.ID;

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
            strSql.Append("delete from m_return_fee_rule ");
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteByUserId(Guid userID, Guid areaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_return_fee_rule ");
            strSql.Append(" where USER_ID='" + userID.ToString() + "' and AREA_ID = '" + areaID.ToString() + "' ");

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_return_fee_rule ");
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
        public Models.m_return_fee_rule GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,USER_ID,AREA_ID,NUMBER,TIME_START,TIME_END,STATUS,DAYS,FEE_MEN,FEE_WOMEN,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG from m_return_fee_rule ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            Models.m_return_fee_rule model = new Models.m_return_fee_rule();
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
        public Models.m_return_fee_rule DataRowToModel(DataRow row)
        {
            Models.m_return_fee_rule model = new Models.m_return_fee_rule();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["USER_ID"] != null && row["USER_ID"].ToString() != "")
                {
                    model.USER_ID = new Guid(row["USER_ID"].ToString());
                }
                if (row["AREA_ID"] != null && row["AREA_ID"].ToString() != "")
                {
                    model.AREA_ID = new Guid(row["AREA_ID"].ToString());
                }
                if (row["NUMBER"] != null && row["NUMBER"].ToString() != "")
                {
                    model.NUMBER = int.Parse(row["NUMBER"].ToString());
                }
                if (row["TIME_START"] != null && row["TIME_START"].ToString() != "")
                {
                    model.TIME_START = DateTime.Parse(row["TIME_START"].ToString());
                }
                if (row["TIME_END"] != null && row["TIME_END"].ToString() != "")
                {
                    model.TIME_END = DateTime.Parse(row["TIME_END"].ToString());
                }
                if (row["STATUS"] != null && row["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(row["STATUS"].ToString());
                }
                if (row["DAYS"] != null && row["DAYS"].ToString() != "")
                {
                    model.DAYS = int.Parse(row["DAYS"].ToString());
                }
                if (row["FEE_MEN"] != null && row["FEE_MEN"].ToString() != "")
                {
                    model.FEE_MEN = decimal.Parse(row["FEE_MEN"].ToString());
                }
                if (row["FEE_WOMEN"] != null && row["FEE_WOMEN"].ToString() != "")
                {
                    model.FEE_WOMEN = decimal.Parse(row["FEE_WOMEN"].ToString());
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USER_ID,AREA_ID,NUMBER,TIME_START,TIME_END,STATUS,DAYS,FEE_MEN,FEE_WOMEN,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM m_return_fee_rule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by NUMBER ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Models.m_return_fee_rule> GetListModel(Guid userID, Guid areaID)
        {
            List<Models.m_return_fee_rule> m_return_fee_rule_list = new List<Models.m_return_fee_rule>();
            DataSet ds = GetList(" USER_ID = '" + userID.ToString() + "' and AREA_ID = '" + areaID.ToString() + "' ");
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.m_return_fee_rule model_m_return_fee_rule = DataRowToModel(row);
                m_return_fee_rule_list.Add(model_m_return_fee_rule);
            }
            return m_return_fee_rule_list;
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
            strSql.Append(" ID,USER_ID,AREA_ID,NUMBER,TIME_START,TIME_END,STATUS,DAYS,FEE_MEN,FEE_WOMEN,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM m_return_fee_rule ");
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
            strSql.Append("select count(1) FROM m_return_fee_rule ");
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
            strSql.Append(")AS Row, T.*  from m_return_fee_rule T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}