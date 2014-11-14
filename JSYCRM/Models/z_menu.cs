using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// z_menu:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class z_menu
    {
        public z_menu()
        { }
        #region Model
        private Guid _id;
        private string _name;
        private string _value;
        private string _description;
        private int _menu_order;
        private string _all_access_flg;
        private Guid _rootmenu_id;
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
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VALUE
        {
            set { _value = value; }
            get { return _value; }
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
        public int MENU_ORDER
        {
            set { _menu_order = value; }
            get { return _menu_order; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ALL_ACCESS_FLG
        {
            set { _all_access_flg = value; }
            get { return _all_access_flg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ROOTMENU_ID
        {
            set { _rootmenu_id = value; }
            get { return _rootmenu_id; }
        }
        #endregion Model

    }
}