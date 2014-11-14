using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// z_user:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class z_user
    {
        public z_user()
        { }
        #region Model
        private Guid _id;
        private string _user_cd;
        private string _password;
        private string _first_name;
        private string _last_name;
        private string _gender;
        private string _email;
        private string _company_tel;
        private Guid _company_id;
        private string _mobile_num;
        private Guid _position_id;
        private string _description;
        private DateTime _create_datetime;
        private DateTime _update_datetime;
        private string _delete_flg;

        public string COMPANY { get; set; }
        public string POSITION { get; set; }
        public string ROLE { get; set; }
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
        public string USER_CD
        {
            set { _user_cd = value; }
            get { return _user_cd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FIRST_NAME
        {
            set { _first_name = value; }
            get { return _first_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_NAME
        {
            set { _last_name = value; }
            get { return _last_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GENDER
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_TEL
        {
            set { _company_tel = value; }
            get { return _company_tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid COMPANY_ID
        {
            set { _company_id = value; }
            get { return _company_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MOBILE_NUM
        {
            set { _mobile_num = value; }
            get { return _mobile_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid POSITION_ID
        {
            set { _position_id = value; }
            get { return _position_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
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