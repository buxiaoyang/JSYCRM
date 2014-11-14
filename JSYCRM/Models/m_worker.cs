using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// m_worker:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class m_worker
    {
        public m_worker()
        { }
        #region Model
        private Guid _id;
        private string _b_name;
        private string _b_gender;
        private string _b_tel;
        private string _b_address;
        private string _b_id_card;
        private Guid _b_create_area_id;

        public string B_CREATE_AREA { get; set; }

        private Guid _b_associated_user_id;

        public string B_ASSOCIATED_USER { get; set; }

        private DateTime _b_associated_data;
        private DateTime _b_expiry_data;
        private Guid _w_work_area_id;

        public string W_WORK_AREA { get; set; }

        private int? _w_is_delivery;
        private DateTime? _w_delivery_data;
        private int? _w_is_pass_interview;
        private DateTime? _w_interview_data;
        private int? _w_is_onboard;
        private DateTime? _w_onboard_data;
        private int? _w_is_resignation;
        private DateTime? _w_resignation_data;
        private DateTime? _a_graduate_data;
        private string _a_census;
        private string _a_edu_background;
        private string _a_home_tel;
        private string _a_home_address;
        private int _status;
        private string _comments;
        private Guid _create_user_id;
        public string CREATE_USER { get; set; }

        private DateTime _create_datetime;
        private Guid _update_user_id;
        public string UPDATE_USER { get; set; }
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
        public string B_NAME
        {
            set { _b_name = value; }
            get { return _b_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_GENDER
        {
            set { _b_gender = value; }
            get { return _b_gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_TEL
        {
            set { _b_tel = value; }
            get { return _b_tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_ADDRESS
        {
            set { _b_address = value; }
            get { return _b_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_ID_CARD
        {
            set { _b_id_card = value; }
            get { return _b_id_card; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid B_CREATE_AREA_ID
        {
            set { _b_create_area_id = value; }
            get { return _b_create_area_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid B_ASSOCIATED_USER_ID
        {
            set { _b_associated_user_id = value; }
            get { return _b_associated_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime B_ASSOCIATED_DATA
        {
            set { _b_associated_data = value; }
            get { return _b_associated_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime B_EXPIRY_DATA
        {
            set { _b_expiry_data = value; }
            get { return _b_expiry_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid W_WORK_AREA_ID
        {
            set { _w_work_area_id = value; }
            get { return _w_work_area_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? W_IS_DELIVERY
        {
            set { _w_is_delivery = value; }
            get { return _w_is_delivery; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? W_DELIVERY_DATA
        {
            set { _w_delivery_data = value; }
            get { return _w_delivery_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? W_IS_PASS_INTERVIEW
        {
            set { _w_is_pass_interview = value; }
            get { return _w_is_pass_interview; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? W_INTERVIEW_DATA
        {
            set { _w_interview_data = value; }
            get { return _w_interview_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? W_IS_ONBOARD
        {
            set { _w_is_onboard = value; }
            get { return _w_is_onboard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? W_ONBOARD_DATA
        {
            set { _w_onboard_data = value; }
            get { return _w_onboard_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? W_IS_RESIGNATION
        {
            set { _w_is_resignation = value; }
            get { return _w_is_resignation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? W_RESIGNATION_DATA
        {
            set { _w_resignation_data = value; }
            get { return _w_resignation_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? A_GRADUATE_DATA
        {
            set { _a_graduate_data = value; }
            get { return _a_graduate_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A_CENSUS
        {
            set { _a_census = value; }
            get { return _a_census; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A_EDU_BACKGROUND
        {
            set { _a_edu_background = value; }
            get { return _a_edu_background; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A_HOME_TEL
        {
            set { _a_home_tel = value; }
            get { return _a_home_tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A_HOME_ADDRESS
        {
            set { _a_home_address = value; }
            get { return _a_home_address; }
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