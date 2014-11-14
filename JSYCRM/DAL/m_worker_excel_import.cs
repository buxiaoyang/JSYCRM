using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace JSYCRM.DAL
{
    public class m_worker_excel_import
    {
        //我的工友，工友信息库导入
        public String getWorkerImportList(DataTable dtInput, Boolean isPool, Guid sessionUserId)
        {
            DAL.z_parameter dal_z_parameter = new z_parameter();
            DAL.z_user dal_z_user = new z_user();
            DAL.m_worker dal_m_worker = new m_worker();
            DataColumn Col = dtInput.Columns.Add("序号");
            Col.SetOrdinal(0);// to put the column in position 0;
            dtInput.Columns.Add(new DataColumn("导入结果"));

            int newAddedItemNumber = 0;
            int updatedItemNumber = 0;
            int notImportedItemNumber = 0;
            for (int i = 0; i < dtInput.Rows.Count; i++)
            {
                string B_NAME = dtInput.Rows[i]["姓名"].ToString().Trim();
                string B_GENDER = dtInput.Rows[i]["性别"].ToString().Trim();
                string B_TEL = dtInput.Rows[i]["联系方式"].ToString().Trim();
                string B_ADDRESS = dtInput.Rows[i]["联系地址"].ToString().Trim();
                string B_CREATE_AREA = dtInput.Rows[i]["创建地区"].ToString().Trim();
                string B_EXPIRY_DATA = dtInput.Rows[i]["到期时间"].ToString().Trim();
                string B_ID_CARD = dtInput.Rows[i]["身份证号"].ToString().Trim();
                //string B_ASSOCIATED_USER = dtInput.Rows[i]["管道"].ToString().Trim();
                string W_WORK_AREA = dtInput.Rows[i]["工作地点"].ToString().Trim();
                int STATUS = isPool ? Common.Variables.WORKER_STATUS_IN_POOL : Common.Variables.WORKER_STATUS_ON_HOLD;

                Guid B_CREATE_AREA_ID = dal_z_parameter.GetID("分公司", B_CREATE_AREA);
                Guid W_WORK_AREA_ID = dal_z_parameter.GetID("地区", W_WORK_AREA);
                Guid B_ASSOCIATED_USER_ID = sessionUserId;

                string inputResult = null;
                if ((B_CREATE_AREA != "" && B_CREATE_AREA_ID == Guid.Empty) || (W_WORK_AREA != "" && W_WORK_AREA_ID == Guid.Empty) )
                {
                    //Product or language are not found in the tool
                    inputResult = "<span class='ImportError'>未导入。创建地点、或工作地点在系统中不存在。</span>";
                    notImportedItemNumber++;
                }
                else
                {
                    Models.m_worker model_m_worker = dal_m_worker.GetModel(B_TEL, B_NAME);
                    if (model_m_worker == null)
                    {
                        model_m_worker = new Models.m_worker();
                        model_m_worker.ID = Guid.NewGuid();
                        model_m_worker.B_NAME = B_NAME;
                        model_m_worker.B_GENDER = B_GENDER;
                        model_m_worker.B_TEL = B_TEL;
                        model_m_worker.B_ADDRESS = B_ADDRESS;
                        model_m_worker.B_ID_CARD = B_ID_CARD;
                        model_m_worker.B_CREATE_AREA_ID = B_CREATE_AREA_ID;
                        model_m_worker.B_ASSOCIATED_USER_ID = B_ASSOCIATED_USER_ID;
                        model_m_worker.B_ASSOCIATED_DATA = DateTime.Now;
                        model_m_worker.B_EXPIRY_DATA = DateTime.Parse(B_EXPIRY_DATA);
                        model_m_worker.W_WORK_AREA_ID = W_WORK_AREA_ID;
                        model_m_worker.STATUS = STATUS;
                        model_m_worker.CREATE_USER_ID = sessionUserId;
                        model_m_worker.CREATE_DATETIME = DateTime.Now;
                        model_m_worker.UPDATE_USER_ID = sessionUserId;
                        model_m_worker.UPDATE_DATETIME = DateTime.Now;
                        model_m_worker.DELETE_FLG = "0";
                        dal_m_worker.Add(model_m_worker);
                        //Can't find currently term with product and language in the tool. will add then.
                        inputResult = "<span class='ImportNewItem'>导入。创建新工友。</span>";
                        newAddedItemNumber++;
                    }
                    else
                    {
                        inputResult = "<span class='ImportItemExist'>未导入。该联系方式的工友已存在。</span>";
                        notImportedItemNumber++;

                        /*
                        inputResult = "<span class='UpdateGlossary'>Imported. Update exist item.</span>";
                        updatedItemNumber++;
                        model_g_glossary_items.DEFINITION = DEFINITION;
                        model_g_glossary_items.TRANSLATED_TERM = REVISED_TRANSLATION;
                        model_g_glossary_items.TRANSLATION_COMMENTS = TRANSLATION_COMMENTS;
                        model_g_glossary_items.SYNCHRONOUS = 0;
                        model_g_glossary_items.UPDATE_USER_ID = model_z_user.ID;
                        model_g_glossary_items.UPDATE_DATETIME = DateTime.Now;
                        model_g_glossary_items.DELETE_FLG = "0";
                        dal_g_glossary_items.Update(model_g_glossary_items);
                            * */
                    }
                }
                //build the result column
                dtInput.Rows[i][0] = i + 1;
                dtInput.Rows[i][dtInput.Columns.Count - 1] = inputResult;

            }
            return "<br/><span><b>导入结果:</b></span>" +
                                              "<br/><span>总工友数: <b>" + dtInput.Rows.Count + "</b></span>" +
                                              " <span><b>" + newAddedItemNumber + "</b> 个工友新增。</span>" +
                                              " <span><b>" + updatedItemNumber + "</b> 个工友更新。</span>" +
                                              " <span><b>" + notImportedItemNumber + "</b> 个工友未导入。</span><br/>"
                                              + bulidTableHtml(dtInput);

        }

        //工友面试信息导入
        public String getWorkerImportListInterview(DataTable dtInput, Guid sessionUserId)
        {
            DAL.z_parameter dal_z_parameter = new z_parameter();
            DAL.z_user dal_z_user = new z_user();
            DAL.m_worker dal_m_worker = new m_worker();
            DataColumn Col = dtInput.Columns.Add("序号");
            Col.SetOrdinal(0);// to put the column in position 0;
            dtInput.Columns.Add(new DataColumn("导入结果"));

            //int newAddedItemNumber = 0;
            int updatedItemNumber = 0;
            int notImportedItemNumber = 0;
            for (int i = 0; i < dtInput.Rows.Count; i++)
            {
                string B_NAME = dtInput.Rows[i]["姓名"].ToString().Trim();
                string B_GENDER = dtInput.Rows[i]["性别"].ToString().Trim();
                string B_TEL = dtInput.Rows[i]["联系方式"].ToString().Trim();
                string B_ADDRESS = dtInput.Rows[i]["联系地址"].ToString().Trim();
                string B_ID_CARD = dtInput.Rows[i]["身份证号"].ToString().Trim();
                string B_ASSOCIATED_USER = dtInput.Rows[i]["管道"].ToString().Trim();
                string W_WORK_AREA = dtInput.Rows[i]["工作地点"].ToString().Trim();
                string W_IS_PASS_INTERVIEW = dtInput.Rows[i]["是否通过面试"].ToString().Trim();
                string W_INTERVIEW_DATA = dtInput.Rows[i]["通过面试日期"].ToString().Trim();

                Guid W_WORK_AREA_ID = dal_z_parameter.GetID("地区", W_WORK_AREA);
                Guid B_ASSOCIATED_USER_ID = dal_z_user.GetID(B_ASSOCIATED_USER);

                string inputResult = null;

                Models.m_worker model_m_worker = dal_m_worker.GetModel(B_NAME, B_ASSOCIATED_USER_ID);
                if (model_m_worker == null)
                {
                    inputResult = "<span class='ImportError'>未导入。姓名为：" + B_NAME + "，并且管道为：" + B_ASSOCIATED_USER + " 的工友不存在，或者不唯一。请检查该工友是否重名或是否存在。</span>";
                    notImportedItemNumber++;
                }
                else if (W_IS_PASS_INTERVIEW != "是" && W_IS_PASS_INTERVIEW != "否")
                {

                    inputResult = "<span class='ImportError'>未导入。\"是否通过面试\"值必须为\"是\"或者\"否\"。当前输入\"" + W_IS_PASS_INTERVIEW + "\"不合法。</span>";
                    notImportedItemNumber++;
                }
                else if (W_WORK_AREA_ID == Guid.Empty)
                {
                    inputResult = "<span class='ImportError'>未导入。工作地点\"" + W_WORK_AREA + "\"在系统中不存在。请用系统中存在的工作地点。</span>";
                    notImportedItemNumber++;
                }
                else
                {
                    try
                    {
                        model_m_worker.W_IS_PASS_INTERVIEW = W_IS_PASS_INTERVIEW == "是" ? 1 : 0;
                        if (model_m_worker.W_IS_PASS_INTERVIEW == 1)
                        {
                            model_m_worker.STATUS = Common.Variables.WORKER_STATUS_PASS_INTERVIEW;
                            model_m_worker.W_INTERVIEW_DATA = DateTime.Parse(W_INTERVIEW_DATA);
                        }
                        else
                        {
                            model_m_worker.W_INTERVIEW_DATA = null;
                        }
                        if (B_ADDRESS.Trim() != "")
                        {
                            model_m_worker.B_ADDRESS = B_ADDRESS;
                        }
                        if (B_ID_CARD.Trim() != "")
                        {
                            model_m_worker.B_ID_CARD = B_ID_CARD;
                        }
                        dal_m_worker.Update(model_m_worker);
                        inputResult = "<span class='ImportUpdateItem'>导入成功，工友已更新。</span>";
                        updatedItemNumber++;
                    }
                    catch(Exception ex)
                    {
                        inputResult = "<span class='ImportError'>未导入。发生错误：\"" + ex.Message + "\"。请尝试查看日期格式是否正确，正确格式为（2014-5-5）。</span>";
                        notImportedItemNumber++;
                    }
                    
                }
                //build the result column
                dtInput.Rows[i][0] = i + 1;
                dtInput.Rows[i][dtInput.Columns.Count - 1] = inputResult;

            }
            return "<br/><span><b>导入结果:</b></span>" +
                                              "<br/><span>总工友数: <b>" + dtInput.Rows.Count + "</b>。</span>" +
                                              " <span><b>" + updatedItemNumber + "</b> 个工友更新。</span>" +
                                              " <span><b>" + notImportedItemNumber + "</b> 个工友未导入。</span><br/>"
                                              + bulidTableHtml(dtInput);

        }

        //工友在职信息导入
        public String getWorkerImportListInWork(DataTable dtInput, Guid sessionUserId)
        {
            DAL.z_parameter dal_z_parameter = new z_parameter();
            DAL.z_user dal_z_user = new z_user();
            DAL.m_worker dal_m_worker = new m_worker();
            DataColumn Col = dtInput.Columns.Add("序号");
            Col.SetOrdinal(0);// to put the column in position 0;
            dtInput.Columns.Add(new DataColumn("导入结果"));

            //int newAddedItemNumber = 0;
            int updatedItemNumber = 0;
            int notImportedItemNumber = 0;
            for (int i = 0; i < dtInput.Rows.Count; i++)
            {
                string B_NAME = dtInput.Rows[i]["姓名"].ToString().Trim();
                string B_GENDER = dtInput.Rows[i]["性别"].ToString().Trim();
                string B_TEL = dtInput.Rows[i]["联系方式"].ToString().Trim();
                string B_ADDRESS = dtInput.Rows[i]["联系地址"].ToString().Trim();
                string B_ID_CARD = dtInput.Rows[i]["身份证号"].ToString().Trim();
                string B_ASSOCIATED_USER = dtInput.Rows[i]["管道"].ToString().Trim();
                string W_WORK_AREA = dtInput.Rows[i]["工作地点"].ToString().Trim();
                string W_IS_ONBOARD = dtInput.Rows[i]["是否报道"].ToString().Trim();
                string W_ONBOARD_DATA = dtInput.Rows[i]["报道日期"].ToString().Trim();
                string W_IS_RESIGNATION = dtInput.Rows[i]["是否离职"].ToString().Trim();
                string W_RESIGNATION_DATA = dtInput.Rows[i]["离职日期"].ToString().Trim();

                Guid W_WORK_AREA_ID = dal_z_parameter.GetID("地区", W_WORK_AREA);
                Guid B_ASSOCIATED_USER_ID = dal_z_user.GetID(B_ASSOCIATED_USER);

                string inputResult = null;

                Models.m_worker model_m_worker = dal_m_worker.GetModel(B_NAME, B_ASSOCIATED_USER_ID);
                if (model_m_worker == null)
                {
                    inputResult = "<span class='ImportError'>未导入。姓名为：" + B_NAME + "，并且管道为：" + B_ASSOCIATED_USER + " 的工友不存在，或者不唯一。请检查该工友是否重名或是否存在。</span>";
                    notImportedItemNumber++;
                }
                else if (W_IS_ONBOARD != "是" && W_IS_ONBOARD != "否")
                {

                    inputResult = "<span class='ImportError'>未导入。\"是否报道\"值必须为\"是\"或者\"否\"。当前输入\"" + W_IS_ONBOARD + "\"不合法。</span>";
                    notImportedItemNumber++;
                }
                else if (W_IS_RESIGNATION != "是" && W_IS_RESIGNATION != "否")
                {

                    inputResult = "<span class='ImportError'>未导入。\"是否离职\"值必须为\"是\"或者\"否\"。当前输入\"" + W_IS_RESIGNATION + "\"不合法。</span>";
                    notImportedItemNumber++;
                }
                else if (W_WORK_AREA_ID == Guid.Empty)
                {
                    inputResult = "<span class='ImportError'>未导入。工作地点\"" + W_WORK_AREA + "\"在系统中不存在。请用系统中存在的工作地点。</span>";
                    notImportedItemNumber++;
                }
                else
                {
                    try
                    {
                        model_m_worker.W_IS_ONBOARD = W_IS_ONBOARD == "是" ? 1 : 0;
                        if (model_m_worker.W_IS_ONBOARD == 1)
                        {
                            model_m_worker.STATUS = Common.Variables.WORKER_STATUS_IS_ONBOARD;
                            model_m_worker.W_ONBOARD_DATA = DateTime.Parse(W_ONBOARD_DATA);
                        }
                        else
                        {
                            model_m_worker.W_ONBOARD_DATA = null;
                        }

                        model_m_worker.W_IS_RESIGNATION = W_IS_RESIGNATION == "是" ? 1 : 0;
                        if (model_m_worker.W_IS_RESIGNATION == 1)
                        {
                            model_m_worker.STATUS = Common.Variables.WORKER_STATUS_IS_RESIGNATION;
                            model_m_worker.W_RESIGNATION_DATA = DateTime.Parse(W_RESIGNATION_DATA);
                        }
                        else
                        {
                            model_m_worker.W_RESIGNATION_DATA = null;
                        }
                        if (B_ADDRESS.Trim() != "")
                        {
                            model_m_worker.B_ADDRESS = B_ADDRESS;
                        }
                        if (B_ID_CARD.Trim() != "")
                        {
                            model_m_worker.B_ID_CARD = B_ID_CARD;
                        }
                        dal_m_worker.Update(model_m_worker);
                        inputResult = "<span class='ImportUpdateItem'>导入成功，工友已更新。</span>";
                        updatedItemNumber++;
                    }
                    catch (Exception ex)
                    {
                        inputResult = "<span class='ImportError'>未导入。发生错误：\"" + ex.Message + "\"。请尝试查看日期格式是否正确，正确格式为（2014-5-5）。</span>";
                        notImportedItemNumber++;
                    }

                }
                //build the result column
                dtInput.Rows[i][0] = i + 1;
                dtInput.Rows[i][dtInput.Columns.Count - 1] = inputResult;

            }
            return "<br/><span><b>导入结果:</b></span>" +
                                              "<br/><span>总工友数: <b>" + dtInput.Rows.Count + "</b></span>" +
                                              " <span><b>" + updatedItemNumber + "</b> 个工友更新。</span>" +
                                              " <span><b>" + notImportedItemNumber + "</b> 个工友未导入。</span><br/>"
                                              + bulidTableHtml(dtInput);

        }

        protected string bulidTableHtml(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='tableImportResult'><tbody>");
            // handling header.
            sb.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append("<th>" + column.ColumnName + "</th>");
            }
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append("<td>" + dr[i] + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</tbody></table>");
            return sb.ToString();
        }

    }
}