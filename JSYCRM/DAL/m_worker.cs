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
    /// 数据访问类:m_worker
    /// </summary>
    public partial class m_worker
    {
        public m_worker()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from m_worker");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool isWorkerDuplicate(string B_NAME, string B_TEL, string B_ID_CARD, string ID)
        {
            StringBuilder strSql = new StringBuilder();
            if (ID == null)
            {
                strSql.Append("select count(1) from m_worker where B_TEL = '" + B_TEL + "' and B_NAME = '" + B_NAME + "' ");
            }
            else
            {
                strSql.Append("select count(1) from m_worker where B_TEL = '" + B_TEL + "' and B_NAME = '" + B_NAME + "'  and ID != '" + ID + "' ");
            }
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Models.m_worker model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_worker(");
            strSql.Append("ID,B_NAME,B_GENDER,B_TEL,B_ADDRESS,B_ID_CARD,B_CREATE_AREA_ID,B_ASSOCIATED_USER_ID,B_ASSOCIATED_DATA,B_EXPIRY_DATA,W_WORK_AREA_ID,W_IS_DELIVERY,W_DELIVERY_DATA,W_IS_PASS_INTERVIEW,W_INTERVIEW_DATA,W_IS_ONBOARD,W_ONBOARD_DATA,W_IS_RESIGNATION,W_RESIGNATION_DATA,A_GRADUATE_DATA,A_CENSUS,A_EDU_BACKGROUND,A_HOME_TEL,A_HOME_ADDRESS,STATUS,COMMENTS,CREATE_USER_ID,CREATE_DATETIME,UPDATE_USER_ID,UPDATE_DATETIME,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@B_NAME,@B_GENDER,@B_TEL,@B_ADDRESS,@B_ID_CARD,@B_CREATE_AREA_ID,@B_ASSOCIATED_USER_ID,@B_ASSOCIATED_DATA,@B_EXPIRY_DATA,@W_WORK_AREA_ID,@W_IS_DELIVERY,@W_DELIVERY_DATA,@W_IS_PASS_INTERVIEW,@W_INTERVIEW_DATA,@W_IS_ONBOARD,@W_ONBOARD_DATA,@W_IS_RESIGNATION,@W_RESIGNATION_DATA,@A_GRADUATE_DATA,@A_CENSUS,@A_EDU_BACKGROUND,@A_HOME_TEL,@A_HOME_ADDRESS,@STATUS,@COMMENTS,@CREATE_USER_ID,@CREATE_DATETIME,@UPDATE_USER_ID,@UPDATE_DATETIME,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@B_GENDER", SqlDbType.NVarChar,50),
					new SqlParameter("@B_TEL", SqlDbType.NVarChar,50),
					new SqlParameter("@B_ADDRESS", SqlDbType.NVarChar,500),
					new SqlParameter("@B_ID_CARD", SqlDbType.NVarChar,50),
					new SqlParameter("@B_CREATE_AREA_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_ASSOCIATED_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_ASSOCIATED_DATA", SqlDbType.DateTime),
					new SqlParameter("@B_EXPIRY_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_WORK_AREA_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@W_IS_DELIVERY", SqlDbType.Int,4),
					new SqlParameter("@W_DELIVERY_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_IS_PASS_INTERVIEW", SqlDbType.Int,4),
					new SqlParameter("@W_INTERVIEW_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_IS_ONBOARD", SqlDbType.Int,4),
					new SqlParameter("@W_ONBOARD_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_IS_RESIGNATION", SqlDbType.Int,4),
					new SqlParameter("@W_RESIGNATION_DATA", SqlDbType.DateTime),
					new SqlParameter("@A_GRADUATE_DATA", SqlDbType.DateTime),
					new SqlParameter("@A_CENSUS", SqlDbType.NVarChar,50),
					new SqlParameter("@A_EDU_BACKGROUND", SqlDbType.NVarChar,50),
					new SqlParameter("@A_HOME_TEL", SqlDbType.NVarChar,50),
					new SqlParameter("@A_HOME_ADDRESS", SqlDbType.NVarChar,500),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@COMMENTS", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.B_NAME;
            parameters[2].Value = model.B_GENDER;
            parameters[3].Value = model.B_TEL;
            parameters[4].Value = model.B_ADDRESS;
            parameters[5].Value = model.B_ID_CARD;
            parameters[6].Value = model.B_CREATE_AREA_ID;
            parameters[7].Value = model.B_ASSOCIATED_USER_ID;
            parameters[8].Value = model.B_ASSOCIATED_DATA;
            parameters[9].Value = model.B_EXPIRY_DATA;
            parameters[10].Value = model.W_WORK_AREA_ID;
            parameters[11].Value = model.W_IS_DELIVERY;
            parameters[12].Value = model.W_DELIVERY_DATA;
            parameters[13].Value = model.W_IS_PASS_INTERVIEW;
            parameters[14].Value = model.W_INTERVIEW_DATA;
            parameters[15].Value = model.W_IS_ONBOARD;
            parameters[16].Value = model.W_ONBOARD_DATA;
            parameters[17].Value = model.W_IS_RESIGNATION;
            parameters[18].Value = model.W_RESIGNATION_DATA;
            parameters[19].Value = model.A_GRADUATE_DATA;
            parameters[20].Value = model.A_CENSUS;
            parameters[21].Value = model.A_EDU_BACKGROUND;
            parameters[22].Value = model.A_HOME_TEL;
            parameters[23].Value = model.A_HOME_ADDRESS;
            parameters[24].Value = model.STATUS;
            parameters[25].Value = model.COMMENTS;
            parameters[26].Value = model.CREATE_USER_ID;
            parameters[27].Value = model.CREATE_DATETIME;
            parameters[28].Value = model.UPDATE_USER_ID;
            parameters[29].Value = model.UPDATE_DATETIME;
            parameters[30].Value = model.DELETE_FLG;

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
        public bool Update(Models.m_worker model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_worker set ");
            strSql.Append("B_NAME=@B_NAME,");
            strSql.Append("B_GENDER=@B_GENDER,");
            strSql.Append("B_TEL=@B_TEL,");
            strSql.Append("B_ADDRESS=@B_ADDRESS,");
            strSql.Append("B_ID_CARD=@B_ID_CARD,");
            strSql.Append("B_CREATE_AREA_ID=@B_CREATE_AREA_ID,");
            strSql.Append("B_ASSOCIATED_USER_ID=@B_ASSOCIATED_USER_ID,");
            strSql.Append("B_ASSOCIATED_DATA=@B_ASSOCIATED_DATA,");
            strSql.Append("B_EXPIRY_DATA=@B_EXPIRY_DATA,");
            strSql.Append("W_WORK_AREA_ID=@W_WORK_AREA_ID,");
            strSql.Append("W_IS_DELIVERY=@W_IS_DELIVERY,");
            strSql.Append("W_DELIVERY_DATA=@W_DELIVERY_DATA,");
            strSql.Append("W_IS_PASS_INTERVIEW=@W_IS_PASS_INTERVIEW,");
            strSql.Append("W_INTERVIEW_DATA=@W_INTERVIEW_DATA,");
            strSql.Append("W_IS_ONBOARD=@W_IS_ONBOARD,");
            strSql.Append("W_ONBOARD_DATA=@W_ONBOARD_DATA,");
            strSql.Append("W_IS_RESIGNATION=@W_IS_RESIGNATION,");
            strSql.Append("W_RESIGNATION_DATA=@W_RESIGNATION_DATA,");
            strSql.Append("A_GRADUATE_DATA=@A_GRADUATE_DATA,");
            strSql.Append("A_CENSUS=@A_CENSUS,");
            strSql.Append("A_EDU_BACKGROUND=@A_EDU_BACKGROUND,");
            strSql.Append("A_HOME_TEL=@A_HOME_TEL,");
            strSql.Append("A_HOME_ADDRESS=@A_HOME_ADDRESS,");
            strSql.Append("STATUS=@STATUS,");
            strSql.Append("COMMENTS=@COMMENTS,");
            strSql.Append("CREATE_USER_ID=@CREATE_USER_ID,");
            strSql.Append("CREATE_DATETIME=@CREATE_DATETIME,");
            strSql.Append("UPDATE_USER_ID=@UPDATE_USER_ID,");
            strSql.Append("UPDATE_DATETIME=@UPDATE_DATETIME,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@B_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@B_GENDER", SqlDbType.NVarChar,50),
					new SqlParameter("@B_TEL", SqlDbType.NVarChar,50),
					new SqlParameter("@B_ADDRESS", SqlDbType.NVarChar,500),
					new SqlParameter("@B_ID_CARD", SqlDbType.NVarChar,50),
					new SqlParameter("@B_CREATE_AREA_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_ASSOCIATED_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@B_ASSOCIATED_DATA", SqlDbType.DateTime),
					new SqlParameter("@B_EXPIRY_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_WORK_AREA_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@W_IS_DELIVERY", SqlDbType.Int,4),
					new SqlParameter("@W_DELIVERY_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_IS_PASS_INTERVIEW", SqlDbType.Int,4),
					new SqlParameter("@W_INTERVIEW_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_IS_ONBOARD", SqlDbType.Int,4),
					new SqlParameter("@W_ONBOARD_DATA", SqlDbType.DateTime),
					new SqlParameter("@W_IS_RESIGNATION", SqlDbType.Int,4),
					new SqlParameter("@W_RESIGNATION_DATA", SqlDbType.DateTime),
					new SqlParameter("@A_GRADUATE_DATA", SqlDbType.DateTime),
					new SqlParameter("@A_CENSUS", SqlDbType.NVarChar,50),
					new SqlParameter("@A_EDU_BACKGROUND", SqlDbType.NVarChar,50),
					new SqlParameter("@A_HOME_TEL", SqlDbType.NVarChar,50),
					new SqlParameter("@A_HOME_ADDRESS", SqlDbType.NVarChar,500),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@COMMENTS", SqlDbType.NVarChar,-1),
					new SqlParameter("@CREATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_USER_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.B_NAME;
            parameters[1].Value = model.B_GENDER;
            parameters[2].Value = model.B_TEL;
            parameters[3].Value = model.B_ADDRESS;
            parameters[4].Value = model.B_ID_CARD;
            parameters[5].Value = model.B_CREATE_AREA_ID;
            parameters[6].Value = model.B_ASSOCIATED_USER_ID;
            parameters[7].Value = model.B_ASSOCIATED_DATA;
            parameters[8].Value = model.B_EXPIRY_DATA;
            parameters[9].Value = model.W_WORK_AREA_ID;
            parameters[10].Value = model.W_IS_DELIVERY;
            parameters[11].Value = model.W_DELIVERY_DATA;
            parameters[12].Value = model.W_IS_PASS_INTERVIEW;
            parameters[13].Value = model.W_INTERVIEW_DATA;
            parameters[14].Value = model.W_IS_ONBOARD;
            parameters[15].Value = model.W_ONBOARD_DATA;
            parameters[16].Value = model.W_IS_RESIGNATION;
            parameters[17].Value = model.W_RESIGNATION_DATA;
            parameters[18].Value = model.A_GRADUATE_DATA;
            parameters[19].Value = model.A_CENSUS;
            parameters[20].Value = model.A_EDU_BACKGROUND;
            parameters[21].Value = model.A_HOME_TEL;
            parameters[22].Value = model.A_HOME_ADDRESS;
            parameters[23].Value = model.STATUS;
            parameters[24].Value = model.COMMENTS;
            parameters[25].Value = model.CREATE_USER_ID;
            parameters[26].Value = model.CREATE_DATETIME;
            parameters[27].Value = model.UPDATE_USER_ID;
            parameters[28].Value = model.UPDATE_DATETIME;
            parameters[29].Value = model.DELETE_FLG;
            parameters[30].Value = model.ID;

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
        public bool UpdataStatus(Guid ID, int Status, string B_ASSOCIATED_USER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update m_worker set STATUS =  " + Status);
            if (B_ASSOCIATED_USER_ID != null)
            {
                strSql.Append(" , B_ASSOCIATED_USER_ID = '" + B_ASSOCIATED_USER_ID + "', B_EXPIRY_DATA = dateadd(dd,7,getdate()) ");
                strSql.Append(" , B_ASSOCIATED_DATA = getdate() ");
            }
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
        public bool saveHistory(Guid ID, Guid UserID)
        {
            DAL.m_worker_history dal_m_worker_history = new m_worker_history();

            Models.m_worker model_m_worker = GetModel(ID);

            Models.m_worker_history model_m_worker_history = new Models.m_worker_history();
            model_m_worker_history.ID = Guid.NewGuid();
            model_m_worker_history.WORKER_ID = ID;
            model_m_worker_history.COMMENTS = model_m_worker.COMMENTS;
            model_m_worker_history.CREATE_USER_ID = UserID;
            model_m_worker_history.CREATE_DATETIME = DateTime.Now;
            model_m_worker_history.UPDATE_USER_ID = UserID;
            model_m_worker_history.UPDATE_DATETIME = DateTime.Now;
            model_m_worker_history.DELETE_FLG = "0";
            dal_m_worker_history.Add(model_m_worker_history);

            model_m_worker.STATUS = Common.Variables.WORKER_STATUS_IN_POOL;
            model_m_worker.COMMENTS = "";
            model_m_worker.UPDATE_USER_ID = UserID;
            model_m_worker.UPDATE_DATETIME = DateTime.Now;
            return Update(model_m_worker);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool followUp(Guid ID, Guid UserID)
        {

            Models.m_worker model_m_worker = GetModel(ID);
            model_m_worker.B_EXPIRY_DATA = DateTime.Now;
            model_m_worker.UPDATE_USER_ID = UserID;
            model_m_worker.UPDATE_DATETIME = DateTime.Now;
            return Update(model_m_worker);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdataStatus(string IDlist, int Status, string B_ASSOCIATED_USER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update m_worker set STATUS =  " + Status);
            if (B_ASSOCIATED_USER_ID != null)
            {
                strSql.Append(" , B_ASSOCIATED_USER_ID = '" + B_ASSOCIATED_USER_ID + "', B_EXPIRY_DATA = dateadd(dd,7,getdate()) ");
                strSql.Append(" , B_ASSOCIATED_DATA = getdate() ");
            }
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_worker ");
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
            strSql.Append("delete from m_worker ");
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
        public Models.m_worker GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TT.*, T2.VALUE AS  B_CREATE_AREA, T3.VALUE AS W_WORK_AREA, U2.LAST_NAME AS B_ASSOCIATED_USER, U3.LAST_NAME AS CREATE_USER,U4.LAST_NAME AS UPDATE_USER from m_worker  as TT");
            strSql.Append(" left join z_parameter AS T2 on TT.B_CREATE_AREA_ID = T2.ID ");
            strSql.Append(" left join z_parameter AS T3 on TT.W_WORK_AREA_ID = T3.ID ");
            strSql.Append(" left join z_user as U2 on TT.B_ASSOCIATED_USER_ID = U2.ID ");
            strSql.Append(" left join z_user as U3 on TT.CREATE_USER_ID = U3.ID ");
            strSql.Append(" left join z_user as U4 on TT.UPDATE_USER_ID = U4.ID");
            strSql.Append(" where TT.ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            Models.m_worker model = new Models.m_worker();
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
        public Models.m_worker GetModel(string B_TEL, string B_NAME)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TT.*, T2.VALUE AS  B_CREATE_AREA, T3.VALUE AS W_WORK_AREA, U2.LAST_NAME AS B_ASSOCIATED_USER, U3.LAST_NAME AS CREATE_USER,U4.LAST_NAME AS UPDATE_USER from m_worker  as TT");
            strSql.Append(" left join z_parameter AS T2 on TT.B_CREATE_AREA_ID = T2.ID ");
            strSql.Append(" left join z_parameter AS T3 on TT.W_WORK_AREA_ID = T3.ID ");
            strSql.Append(" left join z_user as U2 on TT.B_ASSOCIATED_USER_ID = U2.ID ");
            strSql.Append(" left join z_user as U3 on TT.CREATE_USER_ID = U3.ID ");
            strSql.Append(" left join z_user as U4 on TT.UPDATE_USER_ID = U4.ID");
            strSql.Append(" where TT.B_TEL=@B_TEL and TT.B_NAME=@B_NAME ");
            SqlParameter[] parameters = {
					                        new SqlParameter("@B_TEL", SqlDbType.NVarChar,50),
                                            new SqlParameter("@B_NAME", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = B_TEL;
            parameters[1].Value = B_NAME;

            Models.m_worker model = new Models.m_worker();
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
        public Models.m_worker GetModel(string B_NAME, Guid B_ASSOCIATED_USER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TT.*, T2.VALUE AS  B_CREATE_AREA, T3.VALUE AS W_WORK_AREA, U2.LAST_NAME AS B_ASSOCIATED_USER, U3.LAST_NAME AS CREATE_USER,U4.LAST_NAME AS UPDATE_USER from m_worker  as TT");
            strSql.Append(" left join z_parameter AS T2 on TT.B_CREATE_AREA_ID = T2.ID ");
            strSql.Append(" left join z_parameter AS T3 on TT.W_WORK_AREA_ID = T3.ID ");
            strSql.Append(" left join z_user as U2 on TT.B_ASSOCIATED_USER_ID = U2.ID ");
            strSql.Append(" left join z_user as U3 on TT.CREATE_USER_ID = U3.ID ");
            strSql.Append(" left join z_user as U4 on TT.UPDATE_USER_ID = U4.ID");
            strSql.Append(" where TT.B_ASSOCIATED_USER_ID=@B_ASSOCIATED_USER_ID and TT.B_NAME=@B_NAME ");
            SqlParameter[] parameters = {
					                        new SqlParameter("@B_ASSOCIATED_USER_ID", SqlDbType.UniqueIdentifier,16),
                                            new SqlParameter("@B_NAME", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = B_ASSOCIATED_USER_ID;
            parameters[1].Value = B_NAME;

            Models.m_worker model = new Models.m_worker();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count == 1)
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
        public Models.m_worker DataRowToModel(DataRow row)
        {
            Models.m_worker model = new Models.m_worker();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["B_NAME"] != null)
                {
                    model.B_NAME = row["B_NAME"].ToString();
                }
                if (row["B_GENDER"] != null)
                {
                    model.B_GENDER = row["B_GENDER"].ToString();
                }
                if (row["B_TEL"] != null)
                {
                    model.B_TEL = row["B_TEL"].ToString();
                }
                if (row["B_ADDRESS"] != null)
                {
                    model.B_ADDRESS = row["B_ADDRESS"].ToString();
                }
                if (row["B_ID_CARD"] != null)
                {
                    model.B_ID_CARD = row["B_ID_CARD"].ToString();
                }
                if (row["B_CREATE_AREA_ID"] != null && row["B_CREATE_AREA_ID"].ToString() != "")
                {
                    model.B_CREATE_AREA_ID = new Guid(row["B_CREATE_AREA_ID"].ToString());
                }
                if (row["B_ASSOCIATED_USER_ID"] != null && row["B_ASSOCIATED_USER_ID"].ToString() != "")
                {
                    model.B_ASSOCIATED_USER_ID = new Guid(row["B_ASSOCIATED_USER_ID"].ToString());
                }
                if (row["B_ASSOCIATED_DATA"] != null && row["B_ASSOCIATED_DATA"].ToString() != "")
                {
                    model.B_ASSOCIATED_DATA = DateTime.Parse(row["B_ASSOCIATED_DATA"].ToString());
                }
                if (row["B_EXPIRY_DATA"] != null && row["B_EXPIRY_DATA"].ToString() != "")
                {
                    model.B_EXPIRY_DATA = DateTime.Parse(row["B_EXPIRY_DATA"].ToString());
                }
                if (row["W_WORK_AREA_ID"] != null && row["W_WORK_AREA_ID"].ToString() != "")
                {
                    model.W_WORK_AREA_ID = new Guid(row["W_WORK_AREA_ID"].ToString());
                }
                if (row["W_IS_DELIVERY"] != null && row["W_IS_DELIVERY"].ToString() != "")
                {
                    model.W_IS_DELIVERY = int.Parse(row["W_IS_DELIVERY"].ToString());
                }
                if (row["W_DELIVERY_DATA"] != null && row["W_DELIVERY_DATA"].ToString() != "")
                {
                    model.W_DELIVERY_DATA = DateTime.Parse(row["W_DELIVERY_DATA"].ToString());
                }
                if (row["W_IS_PASS_INTERVIEW"] != null && row["W_IS_PASS_INTERVIEW"].ToString() != "")
                {
                    model.W_IS_PASS_INTERVIEW = int.Parse(row["W_IS_PASS_INTERVIEW"].ToString());
                }
                if (row["W_INTERVIEW_DATA"] != null && row["W_INTERVIEW_DATA"].ToString() != "")
                {
                    model.W_INTERVIEW_DATA = DateTime.Parse(row["W_INTERVIEW_DATA"].ToString());
                }
                if (row["W_IS_ONBOARD"] != null && row["W_IS_ONBOARD"].ToString() != "")
                {
                    model.W_IS_ONBOARD = int.Parse(row["W_IS_ONBOARD"].ToString());
                }
                if (row["W_ONBOARD_DATA"] != null && row["W_ONBOARD_DATA"].ToString() != "")
                {
                    model.W_ONBOARD_DATA = DateTime.Parse(row["W_ONBOARD_DATA"].ToString());
                }
                if (row["W_IS_RESIGNATION"] != null && row["W_IS_RESIGNATION"].ToString() != "")
                {
                    model.W_IS_RESIGNATION = int.Parse(row["W_IS_RESIGNATION"].ToString());
                }
                if (row["W_RESIGNATION_DATA"] != null && row["W_RESIGNATION_DATA"].ToString() != "")
                {
                    model.W_RESIGNATION_DATA = DateTime.Parse(row["W_RESIGNATION_DATA"].ToString());
                }
                if (row["A_GRADUATE_DATA"] != null && row["A_GRADUATE_DATA"].ToString() != "")
                {
                    model.A_GRADUATE_DATA = DateTime.Parse(row["A_GRADUATE_DATA"].ToString());
                }
                if (row["A_CENSUS"] != null)
                {
                    model.A_CENSUS = row["A_CENSUS"].ToString();
                }
                if (row["A_EDU_BACKGROUND"] != null)
                {
                    model.A_EDU_BACKGROUND = row["A_EDU_BACKGROUND"].ToString();
                }
                if (row["A_HOME_TEL"] != null)
                {
                    model.A_HOME_TEL = row["A_HOME_TEL"].ToString();
                }
                if (row["A_HOME_ADDRESS"] != null)
                {
                    model.A_HOME_ADDRESS = row["A_HOME_ADDRESS"].ToString();
                }
                if (row["STATUS"] != null && row["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(row["STATUS"].ToString());
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
                    model.B_CREATE_AREA = row["B_CREATE_AREA"].ToString();
                }
                catch
                {
                    model.B_CREATE_AREA = "";
                }
                try
                {
                    model.W_WORK_AREA = row["W_WORK_AREA"].ToString();
                }
                catch
                {
                    model.W_WORK_AREA = "";
                }
                try
                {
                    model.B_ASSOCIATED_USER = row["B_ASSOCIATED_USER"].ToString();
                }
                catch
                {
                    model.B_ASSOCIATED_USER = "";
                }
                try
                {
                    model.CREATE_USER = row["CREATE_USER"].ToString();
                }
                catch
                {
                    model.CREATE_USER = "";
                }
                try
                {
                    model.UPDATE_USER = row["UPDATE_USER"].ToString();
                }
                catch
                {
                    model.UPDATE_USER = "";
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string OrderBy, Boolean isPool)
        {
            string isInPool = " 1=1 ";
            if (isPool)
            {
                isInPool = "STATUS = 1";
            }
            else
            {
                isInPool = "STATUS != 1";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT TT.*, T2.VALUE AS  B_CREATE_AREA, T3.VALUE AS W_WORK_AREA, U2.LAST_NAME AS B_ASSOCIATED_USER, U3.LAST_NAME AS CREATE_USER,U4.LAST_NAME AS UPDATE_USER FROM ");
            strSql.Append(" ( ");
            strSql.Append("select * ");
            strSql.Append(" FROM m_worker ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE  " + isInPool + strWhere);
            }
            else
            {
                strSql.Append(" WHERE  " + isInPool);
            }
            strSql.Append(" )  TT ");
            strSql.Append(" left join z_parameter AS T2 on TT.B_CREATE_AREA_ID = T2.ID  ");
            strSql.Append(" left join z_parameter AS T3 on TT.W_WORK_AREA_ID = T3.ID  ");
            strSql.Append(" left join z_user as U2 on TT.B_ASSOCIATED_USER_ID = U2.ID  ");
            strSql.Append(" left join z_user as U3 on TT.CREATE_USER_ID = U3.ID  ");
            strSql.Append(" left join z_user as U4 on TT.UPDATE_USER_ID = U4.ID ");
            if (!string.IsNullOrEmpty(OrderBy.Trim()))
            {
                strSql.Append(" order by TT." + OrderBy);
            }
            else
            {
                strSql.Append(" order by TT.B_NAME");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public DataSet GetList(string field, string condition, string search, string by, Boolean isPool)
        {
            string byTime = "B_EXPIRY_DATA";
            if (isPool)
            {
                byTime = "CREATE_DATETIME";
            }
            String where = "";
            if (field != "" && field != null && condition != "" && condition != null && search != "" && search != null)
            {
                switch (condition)
                {
                    case "contains":
                        where = "and " + field + " like '%" + search + "%'";
                        break;
                    case "not_contain":
                        where = "and " + field + " not like '%" + search + "%'";
                        break;
                    case "is":
                        where = "and " + field + " = '" + search + "'";
                        break;
                    case "isnot":
                        where = "and " + field + " != '" + search + "'";
                        break;
                    case "start_with":
                        where = "and " + field + " like '" + search + "%'";
                        break;
                    case "end_with":
                        where = "and " + field + " like '%" + search + "'";
                        break;
                }
            }
            if (by != "" && by != null)
            {
                switch (by)
                {
                    case "is_onhold":
                        where += " and STATUS = 2 ";
                        break;
                    case "is_delivery":
                        where += " and STATUS = 3 ";
                        break;
                    case "is_passinterview":
                        where += " and STATUS = 4 ";
                        break;
                    case "is_onboard":
                        where += " and STATUS = 5 ";
                        break;
                    case "is_resignation":
                        where += " and STATUS = 6 ";
                        break;
                    case "today":
                        where += " and " + byTime + " <= '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "week":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(8).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "d15":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(16).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "d30":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(31).ToString("yyyy-MM-dd") + "' ";
                        break;
                }
            }
            String OrderBy = "";
            if (by == "add")
            {
                OrderBy = "CREATE_DATETIME desc";
            }
            else if (by == "update")
            {
                OrderBy = "UPDATE_DATETIME desc";
            }
            return GetList(where, OrderBy, isPool);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, Boolean isPool)
        {
            string isInPool = " 1=1 ";
            if (isPool)
            {
                isInPool = "STATUS = 1";
            }
            else
            {
                isInPool = "STATUS != 1";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.*, U2.LAST_NAME AS B_ASSOCIATED_USER, U3.LAST_NAME AS CREATE_USER,U4.LAST_NAME AS UPDATE_USER FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.B_NAME");
            }
            strSql.Append(")AS Row, T.* , F2.VALUE AS  B_CREATE_AREA, F3.VALUE AS W_WORK_AREA  from m_worker T ");
            strSql.Append(" left join z_parameter AS F2 on T.B_CREATE_AREA_ID = F2.ID ");
            strSql.Append(" left join z_parameter AS F3 on T.W_WORK_AREA_ID = F3.ID ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE  " + isInPool + strWhere);
            }
            else
            {
                strSql.Append(" WHERE  " + isInPool);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join z_user as U2 on TT.B_ASSOCIATED_USER_ID = U2.ID ");
            strSql.Append(" left join z_user as U3 on TT.CREATE_USER_ID = U3.ID ");
            strSql.Append(" left join z_user as U4 on TT.UPDATE_USER_ID = U4.ID");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public DataSet GetReport(string company, string start_time, string end_time)
        {
            StringBuilder timeWhere = new StringBuilder();
            if (start_time != null && start_time != "")
            {
                timeWhere.Append(" and B_ASSOCIATED_DATA >= '" + start_time + "' ");
            }
            if (end_time != null && end_time != "")
            {
                timeWhere.Append(" and B_ASSOCIATED_DATA <= dateadd(dd,1,'" + end_time + "') ");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select C.VALUE as AREA, A.B_ASSOCIATED_USER_ID as USER_ID, B.LAST_NAME as USER_NAME, ");
            strSql.Append(" A.ADD_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where B_ASSOCIATED_USER_ID = A.B_ASSOCIATED_USER_ID and STATUS=3" + timeWhere.ToString() + ") as DELIVERY_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where B_ASSOCIATED_USER_ID = A.B_ASSOCIATED_USER_ID and STATUS=4" + timeWhere.ToString() + ") as PASS_INTERVIEW_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where B_ASSOCIATED_USER_ID = A.B_ASSOCIATED_USER_ID and STATUS=5" + timeWhere.ToString() + ") as ONBOARD_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where B_ASSOCIATED_USER_ID = A.B_ASSOCIATED_USER_ID and STATUS=6" + timeWhere.ToString() + ") as RESIGNATION_WORKER ");
            strSql.Append(" from  ");
            strSql.Append(" ( ");
            strSql.Append(" select B_ASSOCIATED_USER_ID, count(*) as ADD_WORKER from dbo.m_worker ");
            strSql.Append(" where STATUS != 1 ");
            strSql.Append(timeWhere.ToString());
            strSql.Append(" group by B_ASSOCIATED_USER_ID ");
            strSql.Append(" ) A ");
            strSql.Append(" left join dbo.z_user as B on A.B_ASSOCIATED_USER_ID = B.ID ");
            strSql.Append(" left join dbo.z_parameter as C on B.COMPANY_ID = C.ID ");
            if (company != null && company != "")
            {
                strSql.Append(" where B.COMPANY_ID = '" + company + "' ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetReportChart(string area, string associated_user, string start_time, string end_time)
        {
            StringBuilder timeWhere = new StringBuilder();
            if (start_time != null && start_time != "")
            {
                timeWhere.Append(" and B_ASSOCIATED_DATA >= '" + start_time + "' ");
            }
            if (end_time != null && end_time != "")
            {
                timeWhere.Append(" and B_ASSOCIATED_DATA <= dateadd(dd,1,'" + end_time + "') ");
            }
            StringBuilder associatedUserWhere = new StringBuilder();
            if (associated_user != null && associated_user != "")
            {
                associatedUserWhere.Append(" and B_ASSOCIATED_USER_ID = '" + associated_user + "' ");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select A.VALUE as AREA, ");
            strSql.Append(" (select count(*) from dbo.m_worker where W_WORK_AREA_ID = A.ID and STATUS!=1 " + associatedUserWhere + timeWhere + ") as ADD_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where W_WORK_AREA_ID = A.ID and STATUS=3 " + associatedUserWhere + timeWhere + ") as DELIVERY_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where W_WORK_AREA_ID = A.ID and STATUS=4 " + associatedUserWhere + timeWhere + ") as PASS_INTERVIEW_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where W_WORK_AREA_ID = A.ID and STATUS=5 " + associatedUserWhere + timeWhere + ") as ONBOARD_WORKER, ");
            strSql.Append(" (select count(*) from dbo.m_worker where W_WORK_AREA_ID = A.ID and STATUS=6 " + associatedUserWhere + timeWhere + ") as RESIGNATION_WORKER ");
            strSql.Append(" from ");
            strSql.Append(" ( ");
            strSql.Append(" select ID, VALUE from z_parameter where NAME = '地区' ");
            if (area != null && area != "")
            {
                strSql.Append(" and ID = '" + area + "' ");
            }
            strSql.Append(" ) A ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        public DataTable GetReturnFee(string area, Guid user_id)
        {
            DataTable dt = null;
            DAL.m_return_fee_rule dal_m_return_fee_rule = new m_return_fee_rule();
            List<Models.m_return_fee_rule> model_list_m_return_fee_rule = dal_m_return_fee_rule.GetListModel(user_id, new Guid(area));
            foreach (Models.m_return_fee_rule model in model_list_m_return_fee_rule)
            {
                string rule_number = "规则" + Common.Common.getChineseNumber(model.NUMBER);
                string rule_detail = model.TIME_START.ToString("yyyy-MM-dd") + "~" + model.TIME_END.ToString("yyyy-MM-dd") + "期间（" + Common.Common.getWorkerStatus(model.STATUS) + model.DAYS + "天 男返" + model.FEE_MEN + " 女返" + model.FEE_WOMEN + "）";
                string statusField = Common.Common.getWorkerStatusField(model.STATUS);
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select A.ID, A.B_NAME, A.B_GENDER, A.B_TEL, A.B_ADDRESS,  ");
                strSql.Append(" A.B_CREATE_AREA_ID, B.VALUE as B_CREATE_AREA, A.B_ASSOCIATED_USER_ID, C.LAST_NAME as B_ASSOCIATED_USER,  ");
                strSql.Append(" A.CREATE_DATETIME, A.STATUS, A." + statusField + " as STATUS_DATA, ");
                strSql.Append(" '" + rule_number + "' as RULE_NAME, '" + rule_detail + "' as RULE_DETAIL, CONVERT(decimal(8,2), " + model.FEE_MEN + ")  as FEE_MAN, CONVERT(decimal(8,2), " + model.FEE_WOMEN + ")  as FEE_WOMEN ");
                strSql.Append(" from dbo.m_worker as A  ");
                strSql.Append(" left join z_parameter as B on A.W_WORK_AREA_ID = B.ID ");
                strSql.Append(" left join z_user as C on A.B_ASSOCIATED_USER_ID = C.ID ");
                strSql.Append(" where A.STATUS = " + model.STATUS + "  ");
                if (area != null && area != "")
                {
                    strSql.Append(" and A.W_WORK_AREA_ID = '" + area + "'  ");
                }
                strSql.Append(" and dateadd(dd," + model.DAYS + ", A." + statusField + ") >= '" + model.TIME_START.ToString("yyyy-MM-dd") + "'  ");
                strSql.Append(" and dateadd(dd," + model.DAYS + ", A." + statusField + ") <= '" + model.TIME_END.ToString("yyyy-MM-dd") + "' ");
                if (dt == null)
                {
                    dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                }
                else
                {
                    dt.Merge(DbHelperSQL.Query(strSql.ToString()).Tables[0]);
                }
            }
            if (dt == null)
            {
                dt = new DataTable();
            }
            return dt;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string field, string condition, string search, string by, Boolean isPool, Guid user_id)
        {
            string isInPool = " 1=1 ";
            string byTime = "B_EXPIRY_DATA";
            if (isPool)
            {
                isInPool = "STATUS = 1 ";
                byTime = "CREATE_DATETIME";
            }
            else
            {
                isInPool = "STATUS != 1 and B_ASSOCIATED_USER_ID = '" + user_id.ToString() + "' ";
            }
            String where = "";
            if (field != "" && field != null && condition != "" && condition != null && search != "" && search != null)
            {
                switch (condition)
                {
                    case "contains":
                        where += "and " + field + " like '%" + search + "%'";
                        break;
                    case "not_contain":
                        where += "and " + field + " not like '%" + search + "%'";
                        break;
                    case "is":
                        where += "and " + field + " = '" + search + "'";
                        break;
                    case "isnot":
                        where += "and " + field + " != '" + search + "'";
                        break;
                    case "start_with":
                        where += "and " + field + " like '" + search + "%'";
                        break;
                    case "end_with":
                        where += "and " + field + " like '%" + search + "'";
                        break;
                }
            }
            if (by != "" && by != null)
            {
                switch (by)
                {
                    case "is_onhold":
                        where += " and STATUS = 2 ";
                        break;
                    case "is_delivery":
                        where += " and STATUS = 3 ";
                        break;
                    case "is_passinterview":
                        where += " and STATUS = 4 ";
                        break;
                    case "is_onboard":
                        where += " and STATUS = 5 ";
                        break;
                    case "is_resignation":
                        where += " and STATUS = 6 ";
                        break;
                    case "today":
                        where += " and " + byTime + " <= '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "week":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(8).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "d15":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(16).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "d30":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(31).ToString("yyyy-MM-dd") + "' ";
                        break;
                }
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM m_worker as TT ");
            strSql.Append(" left join z_parameter AS F2 on TT.B_CREATE_AREA_ID = F2.ID ");
            strSql.Append(" left join z_parameter AS F3 on TT.W_WORK_AREA_ID = F3.ID ");
            if (where != "" && where != null)
            {
                strSql.Append("where " + isInPool + where);
            }
            else
            {
                strSql.Append(" WHERE  " + isInPool);
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
        public List<Models.m_worker> GetListModelByPage(string field, string condition, string search, string by, int startIndex, int endIndex, Boolean isPool, Guid user_id)
        {
            string byTime = "B_EXPIRY_DATA";
            String where = "";
            if (isPool)
            {
                byTime = "CREATE_DATETIME";
            }
            else
            {
                where += " and B_ASSOCIATED_USER_ID = '" + user_id.ToString() + "' ";
            }
            if (field != "" && field != null && condition != "" && condition != null && search != "" && search != null)
            {
                switch (condition)
                {
                    case "contains":
                        where += "and " + field + " like '%" + search + "%'";
                        break;
                    case "not_contain":
                        where += "and " + field + " not like '%" + search + "%'";
                        break;
                    case "is":
                        where += "and " + field + " = '" + search + "'";
                        break;
                    case "isnot":
                        where += "and " + field + " != '" + search + "'";
                        break;
                    case "start_with":
                        where += "and " + field + " like '" + search + "%'";
                        break;
                    case "end_with":
                        where += "and " + field + " like '%" + search + "'";
                        break;
                }
            }
            if (by != "" && by != null)
            {
                switch (by)
                {
                    case "is_onhold":
                        where += " and STATUS = 2 ";
                        break;
                    case "is_delivery":
                        where += " and STATUS = 3 ";
                        break;
                    case "is_passinterview":
                        where += " and STATUS = 4 ";
                        break;
                    case "is_onboard":
                        where += " and STATUS = 5 ";
                        break;
                    case "is_resignation":
                        where += " and STATUS = 6 ";
                        break;
                    case "today":
                        where += " and " + byTime + " <= '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "week":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(8).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "d15":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(16).ToString("yyyy-MM-dd") + "' ";
                        break;
                    case "d30":
                        where += " and  " + byTime + " <= '" + DateTime.Now.AddDays(31).ToString("yyyy-MM-dd") + "' ";
                        break;
                }
            }
            String OrderBy = "";
            if (by == "add")
            {
                OrderBy = "CREATE_DATETIME desc";
            }
            else if (by == "update")
            {
                OrderBy = "UPDATE_DATETIME desc";
            }
            List<Models.m_worker> m_worker_list = new List<Models.m_worker>();
            DataSet ds = GetListByPage(where, OrderBy, startIndex, endIndex, isPool);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.m_worker model_m_worker = DataRowToModel(row);
                m_worker_list.Add(model_m_worker);
            }
            return m_worker_list;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}