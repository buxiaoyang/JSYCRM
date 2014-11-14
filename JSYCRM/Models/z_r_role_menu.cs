using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    public class z_r_role_menu
    {
        public z_r_role_menu()
        { }
        #region Model
        private Guid _role_id;
        private Guid _MENU_ID;
        /// <summary>
        /// 
        /// </summary>
        public Guid ROLE_ID
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid MENU_ID
        {
            set { _MENU_ID = value; }
            get { return _MENU_ID; }
        }
        #endregion Model
    }
}