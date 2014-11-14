using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace JSYCRM.DAL
{
    /// <summary>
    /// 数据访问类:z_parameter
    /// </summary>
    public partial class z_parameter
    {
        public z_parameter()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from z_parameter");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public Guid GetID(string NAME, string VALUE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ID from dbo.z_parameter ");
            strSql.Append(" where NAME = @NAME and VALUE = @VALUE ");
            SqlParameter[] parameters = {
					                        new SqlParameter("@NAME", SqlDbType.NVarChar,50),
		                                    new SqlParameter("@VALUE", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = NAME;
            parameters[1].Value = VALUE;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new Guid(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            else
            {
                return Guid.Empty;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(JSYCRM.Models.z_parameter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into z_parameter(");
            strSql.Append("ID,TYPE,NAME,VALUE,DESCRIPTION,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@TYPE,@NAME,@VALUE,@DESCRIPTION,@CREATE_USER_ID,@CREATE_DATETIME,@UPDATE_USER_ID,@UPDATE_DATETIME,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@TYPE", SqlDbType.NVarChar,50),
					new SqlParameter("@NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@VALUE", SqlDbType.NVarChar,50),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,100),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.TYPE;
            parameters[2].Value = model.NAME;
            parameters[3].Value = model.VALUE;
            parameters[4].Value = model.DESCRIPTION;
            parameters[5].Value = model.CREATE_USER_ID;
            parameters[6].Value = model.CREATE_DATETIME;
            parameters[7].Value = model.UPDATE_USER_ID;
            parameters[8].Value = model.UPDATE_DATETIME;
            parameters[9].Value = model.DELETE_FLG;

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
        public bool Update(JSYCRM.Models.z_parameter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_parameter set ");
            strSql.Append("TYPE=@TYPE,");
            strSql.Append("NAME=@NAME,");
            strSql.Append("VALUE=@VALUE,");
            strSql.Append("DESCRIPTION=@DESCRIPTION,");
            strSql.Append("CREATE_USER_ID=@CREATE_USER_ID,");
            strSql.Append("CREATE_DATETIME=@CREATE_DATETIME,");
            strSql.Append("UPDATE_USER_ID=@UPDATE_USER_ID,");
            strSql.Append("UPDATE_DATETIME=@UPDATE_DATETIME,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TYPE", SqlDbType.NVarChar,50),
					new SqlParameter("@NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@VALUE", SqlDbType.NVarChar,50),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,100),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.TYPE;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.VALUE;
            parameters[3].Value = model.DESCRIPTION;
            parameters[4].Value = model.CREATE_USER_ID;
            parameters[5].Value = model.CREATE_DATETIME;
            parameters[6].Value = model.UPDATE_USER_ID;
            parameters[7].Value = model.UPDATE_DATETIME;
            parameters[8].Value = model.DELETE_FLG;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from z_parameter ");
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
            strSql.Append("delete from z_parameter ");
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
        public JSYCRM.Models.z_parameter GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,TYPE,NAME,VALUE,DESCRIPTION,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG from z_parameter ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            JSYCRM.Models.z_parameter model = new JSYCRM.Models.z_parameter();
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
        public JSYCRM.Models.z_parameter DataRowToModel(DataRow row)
        {
            JSYCRM.Models.z_parameter model = new JSYCRM.Models.z_parameter();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["TYPE"] != null)
                {
                    model.TYPE = row["TYPE"].ToString();
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
                    if (row["UPDATE_USER"] != null && row["UPDATE_USER"].ToString() != "")
                    {
                        model.CREATE_USER = row["UPDATE_USER"].ToString();
                    }
                    if (row["CREATE_USER"] != null && row["CREATE_USER"].ToString() != "")
                    {
                        model.CREATE_USER = row["CREATE_USER"].ToString();
                    }
                }
                catch
                { }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string NAME)
        {
            NAME = Common.Common.FilteSQLStr(NAME);
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*, b.LAST_NAME as CREATE_USER, c.LAST_NAME as UPDATE_USER from z_parameter as a  ");
            strSql.Append(" left join z_user as b on a.CREATE_USER_ID = b.ID ");
            strSql.Append(" left join z_user as c on a.UPDATE_USER_ID = c.ID ");
            strSql.Append(" where a.NAME = '" + NAME + "' ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Models.z_parameter> GetModelList(string NAME)
        {
            List<Models.z_parameter> z_parameter_list = new List<Models.z_parameter>();
            DataSet ds = GetList(NAME);
            DataTable dt = ds.Tables[0];
            foreach(DataRow row in dt.Rows) {
                Models.z_parameter model_z_parameter = DataRowToModel(row);
                z_parameter_list.Add(model_z_parameter);
            }
            return z_parameter_list;
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
            strSql.Append(" ID,TYPE,NAME,VALUE,DESCRIPTION,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM z_parameter ");
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
            strSql.Append("select count(1) FROM z_parameter ");
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
            strSql.Append(")AS Row, T.*  from z_parameter T ");
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
            parameters[0].Value = "z_parameter";
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