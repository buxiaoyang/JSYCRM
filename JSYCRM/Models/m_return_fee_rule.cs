using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// m_return_fee_rule:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class m_return_fee_rule
    {
        public m_return_fee_rule()
        { }
        #region Model
        private Guid _id;
        private Guid _user_id;
        public Guid AREA_ID { get; set; }
        private int _number;
        private DateTime _time_start;
        private DateTime _time_end;
        private int _status;
        private int _days;
        private decimal _fee_men;
        private decimal _fee_women;
        private string _comments;
        private Guid _create_user_id;
        private DateTime _create_datetime;
        private Guid _update_user_id;
        private DateTime _update_datetime;
        private string _delete_flg;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NUMBER
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TIME_START
        {
            set { _time_start = value; }
            get { return _time_start; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TIME_END
        {
            set { _time_end = value; }
            get { return _time_end; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DAYS
        {
            set { _days = value; }
            get { return _days; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FEE_MEN
        {
            set { _fee_men = value; }
            get { return _fee_men; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FEE_WOMEN
        {
            set { _fee_women = value; }
            get { return _fee_women; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMMENTS
        {
            set { _comments = value; }
            get { return _comments; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid CREATE_USER_ID
        {
            set { _create_user_id = value; }
            get { return _create_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CREATE_DATETIME
        {
            set { _create_datetime = value; }
            get { return _create_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid UPDATE_USER_ID
        {
            set { _update_user_id = value; }
            get { return _update_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UPDATE_DATETIME
        {
            set { _update_datetime = value; }
            get { return _update_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DELETE_FLG
        {
            set { _delete_flg = value; }
            get { return _delete_flg; }
        }
        #endregion Model

    }
}