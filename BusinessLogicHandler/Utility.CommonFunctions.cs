using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace BCL.Utility.CommonMethods
{
    public class CommonFunctions
    {
        public void FillDropDownList(System.Web.UI.WebControls.DropDownList ddl, System.Data.DataSet ds, string valueField, string textField, string firstRowValue, string firstRowText, string selectedValue)
        {
            ddl.Items.Clear();
            
            ddl.DataTextField = textField;
            
            ddl.DataValueField = valueField;
           
            ddl.DataSource = ds;
            
            ddl.DataBind();
            
            if (firstRowValue != null && firstRowValue != "")
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem(firstRowText, firstRowValue);
                
                ddl.Items.Insert(0, l);
            }
            if (selectedValue != null && selectedValue != "")
            {
                System.Web.UI.WebControls.ListItem li = ddl.Items.FindByValue(selectedValue);
                
                ddl.ClearSelection();
                if (li != null)
                {
                    li.Selected = true;
                }
            }
        }

        public static void Setserial(GridView tempGrid, string tempstr)
        {
            int m;
            m = tempGrid.PageIndex * (tempGrid.PageSize);
            
            foreach (GridViewRow tempGridrow in tempGrid.Rows)
            {
                Label lablesr = ((Label)(tempGridrow.FindControl(tempstr)));
                
                string s1 = (System.Convert.ToString(m + 1));
               
                lablesr.Text = s1;
                
                m = m + 1;
            }
        }

        public static string GetCheckedRow(GridView tempGrid, string Control)
        {
            CheckBox CheckBox;

            int KeyId;
           
            string Id = "";
            
            foreach (GridViewRow GridViewRow in tempGrid.Rows)
            {
                CheckBox = ((CheckBox)(GridViewRow.FindControl(Control)));
                
                if (CheckBox.Checked)
                {
                    
                    KeyId = System.Convert.ToInt32(tempGrid.DataKeys[GridViewRow.RowIndex].Value);
                    
                    if (Id == "")
                    {
                        Id = KeyId.ToString();
                    }
                    else
                    {
                        Id = Id + "," + KeyId.ToString();
                    }
                }
            }
            return Id;
        }

        public static string GetCheckedRowString(GridView tempGrid, string Control)
        {
            CheckBox CheckBox;

            string KeyId;
           
            string Id = "";
            
            foreach (GridViewRow GridViewRow in tempGrid.Rows)
            {
                CheckBox = ((CheckBox)(GridViewRow.FindControl(Control)));
                
                if (CheckBox.Checked)
                {
                    
                    KeyId = tempGrid.DataKeys[GridViewRow.RowIndex].Value.ToString();
                    
                    if (Id == "")
                    {
                        Id = KeyId.ToString();
                    }
                    else
                    {
                        Id = Id + "," + KeyId.ToString();
                    }
                }
            }
            return Id;
        }

        public static string yyyymmdd(string dt)
        {
            string[] _dt;
            _dt = dt.Split('/');
            return (_dt[2] + "-" + _dt[1] + "-" + _dt[0]);
        }

        public static string yyyymmdd_ajax(string dt)
        {
            string[] _dt;
            _dt = dt.Split('/');
            return (_dt[2] + "-" + _dt[0] + "-" + _dt[1]);
        }

        public static string StripHtml(string html, bool allowHarmlessTags)
        {
            if (html == null || html == string.Empty)
                return string.Empty;

            if (allowHarmlessTags)
            {
                return System.Text.RegularExpressions.Regex.Replace(html, "", string.Empty);
            }
            else
            {
                return System.Text.RegularExpressions.Regex.Replace(html, "<[^>]*>", string.Empty);
            }
        }

        public static string ExceptionType(string str)
        {
            string result = "";
            if (str.Length > 0)
            {
                switch (str)
                {

                    //NoNullAllowedException
                    case "1": result = "Try to attempt to Insert blank values in database."; break;
                    //DataException
                    case "2": result = "Fails to Establish the database Connection."; break;
                    //NullReferenceException
                    case "3": result = "Value is blank"; break;
                    //SyntaxErrorException
                    case "4": result = "Programming Error"; break;
                    //NotFiniteNumberException
                    case "5": result = "Input Field must be not a Number"; break;
                    //IndexOutOfRangeException
                    case "6": result = "Try to access array index out of bound"; break;
                    //TimeoutException
                    case "7": result = "Time out occures for the current process"; break;
                    //ViewStateException
                    case "8": result = ""; break;
                    //InvalidCastException
                    case "9": result = "Fails to cast the values"; break;
                    //ArgumentException
                    case "10": result = "Invalid parameter to method"; break;
                    //ArgumentOutOfRangeException
                    case "11": result = "Out of range parameter value send to method"; break;
                    //OdbcException
                    case "12": result = "Sql Syntex Error Found in query"; break;
                    default: result = "Unable to be determined"; break;

                }
            }


            return result;
        }
    }
}
