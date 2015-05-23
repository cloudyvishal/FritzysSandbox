using BCL.Admin.GroomerMngmt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class UploadGroomerAppointments : System.Web.UI.Page
    {
        #region "Global Variable"

        string gname = "", dtTime = "", ApptString = "", ExpPetTime = "", ExpRevAmount = "", StartTm = "", Start_EndTime = "";

        int SeqNum = 0, gid = 0;

        DateTime dtApptDate;

        decimal time = 0;

        DataSet objDataset1 = new DataSet();

        int StartHours, StartMinutes;

        Groomer objgroomer = new Groomer();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool IsValidRevAmt(string expRev)
        {
            // check all validations.
            bool IsValidRev = true;
            if (expRev == "" || expRev.Length > 8)
            {
                IsValidRev = false;
            }

            Regex regEx = new Regex("^\\d*(\\.\\d{1,4})?$");

            Match mtExpRev = Regex.Match(expRev, regEx.ToString());

            if (!(mtExpRev.Success))
            {
                IsValidRev = false;

            }
            return IsValidRev;

        }

        protected bool IsValidAppointment(string dtApptDate, string dtTime, string Others, string gname, string exppettime, int Seqno, string AptSTime, string ExpApptTime)
        {
            bool IsValidAppt = true;

            if (null == dtApptDate || dtApptDate == "" || dtTime == "" || Others == "" || gname == "" || exppettime == "" || exppettime == "0" || exppettime == "0.00" || Seqno == 0 || AptSTime == "" || ExpApptTime == "")
            {
                IsValidAppt = false;

            }

            bool IsGroomerAvail = objgroomer.IsGroomerExists(gname);
            if (IsGroomerAvail.Equals(false))
            {
                IsValidAppt = false;

            }

            //--------------

            if (exppettime.Length > 10)
            {
                IsValidAppt = false;

            }

            Regex regEx = new Regex("^\\d*(\\.\\d{1,4})?$");

            Match mtExpPetTime = Regex.Match(exppettime, regEx.ToString());

            if (!(mtExpPetTime.Success))
            {
                IsValidAppt = false;

            }

            if (AptSTime != "")
            {
                string[] arrSTime = new string[3];

                if (AptSTime.Contains(" "))
                {
                    arrSTime = AptSTime.Split(' ');

                }
                string tt = "";

                string hour = "";

                if (arrSTime.Length > 0)
                {
                    string timepart = arrSTime[1].Trim().ToString();

                    if (timepart.Contains(":"))
                    {
                        string[] arrTPart = new string[3];

                        arrTPart = timepart.Split(':');

                        if (arrTPart.Length > 0)
                        {
                            if (!(null == arrTPart[0]))
                            {
                                hour = arrTPart[0].ToString();
                            }
                        }
                    }

                    if (!(null == arrSTime[2]))
                    {
                        tt = arrSTime[2].Trim().ToString();
                    }
                }

                if (Convert.ToInt32(hour) >= 1 && Convert.ToInt32(hour) < 6 && tt.Equals("AM") || Convert.ToInt32(hour) == 12 && tt.Equals("AM"))
                {
                    IsValidAppt = false;
                }
            }
            return IsValidAppt;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string fn = System.IO.Path.GetFileName(ApptFile.PostedFile.FileName);

                string filepath = ApptFile.PostedFile.FileName;

                string p = ApptFile.FileName.ToString();

                if (ApptFile.HasFile)
                {
                    if (ApptFile.PostedFile.FileName != "")
                    {
                        if (fn.Contains(".xls"))
                        {

                            if (btnUpload.CausesValidation == true)
                            {

                                int IsDeleted = objgroomer.DeleteFutureAppointments();

                                lblError.Text = "";

                                string pat = @"\\(?:.+)\\(.+)\.(.+)";

                                Regex r = new Regex(pat);

                                string filename = Path.GetFileNameWithoutExtension(filepath);

                                string file_ext = Path.GetExtension(filepath);

                                string dtm = (Convert.ToDateTime(DateTime.Now.Date)).ToString("dd-MMM-yyyy") + " " + (DateTime.Now.ToLongTimeString()).ToString();
                                string filedatetime = dtm.Replace(":", "_");

                                string file = filename + filedatetime.ToString() + file_ext;

                                //save the file to the server 
                                ApptFile.PostedFile.SaveAs(Server.MapPath("AppointmentFiles/") + file);

                                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                                 "Data Source= '" + Server.MapPath("AppointmentFiles/") + file + "' " + ";" +
                                                 "Extended Properties=Excel 8.0;";

                                OleDbConnection objConn = new OleDbConnection(sConnectionString);

                                objConn.Open();

                                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [Tasks$]", objConn);

                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

                                objAdapter1.SelectCommand = objCmdSelect;

                                objAdapter1.Fill(objDataset1, "XLData");

                                int c = 0;

                                int NoofInsertedAppt = 0;

                                string ExpEndTimeStr = "";

                                for (int row = 0; row < (objDataset1.Tables["XLData"].Rows.Count); row++)
                                {
                                    string RowInitialValue = objDataset1.Tables["XLData"].Rows[row][0].ToString();

                                    if (!(RowInitialValue).Equals(""))
                                    {
                                        string dtPart2 = "";
                                        string Apptdate = objDataset1.Tables["XLData"].Rows[row][3].ToString();

                                        string ApptStart_Time = objDataset1.Tables["XLData"].Rows[row][4].ToString();

                                        string ApptString = objDataset1.Tables["XLData"].Rows[row][6].ToString();

                                        string ExpApptTime = objDataset1.Tables["XLData"].Rows[row][8].ToString();

                                        string NameofCustomer = objDataset1.Tables["XLData"].Rows[row][5].ToString();

                                        gname = objDataset1.Tables["XLData"].Rows[row][10].ToString();

                                        string ZipCode, zip = "";

                                        if (ApptString != "")
                                        {
                                            string[] arraptstr = new string[25];

                                            arraptstr = ApptString.Split(',');

                                            if (arraptstr.Length > 0)
                                            {
                                                for (int i = 0; i < arraptstr.Length; i++)
                                                {
                                                    if (!(null == arraptstr[i]))
                                                    {
                                                        if (arraptstr[i].Trim().Length == 5 || arraptstr[i].Trim().Length == 6)
                                                        {
                                                            string zcode = "";
                                                            if (arraptstr[i].Trim().Length == 5)
                                                            {
                                                                zcode = arraptstr[i].Trim().ToString();
                                                            }
                                                            else
                                                            {
                                                                if (arraptstr[i].Trim().ToString().StartsWith("*"))
                                                                {
                                                                    zcode = arraptstr[i].Trim().ToString().Substring(1, arraptstr[i].Trim().ToString().Length - 1);
                                                                }
                                                            }
                                                            // check for valid zip code
                                                            bool IsValidZip = CheckZipCode(zcode);

                                                            if (IsValidZip.Equals(true))
                                                            {
                                                                zip = zcode;

                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        ZipCode = zip;

                                        bool IsValidApptDate = false;

                                        if (Apptdate != "")
                                        {
                                            string AptDt = Apptdate;

                                            if (Apptdate.Contains(' '))
                                            {
                                                string[] arraptdt = Apptdate.Split(' ');

                                                AptDt = arraptdt[0].ToString();
                                            }
                                            Regex regexDt = new Regex("^(((0?[1-9]|1[012])/(0?[1-9]|1\\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\\d)\\d{2}|0?2/29/((19|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$");

                                            Match mtApptDt = Regex.Match(AptDt, regexDt.ToString());

                                            if (mtApptDt.Success)
                                            {
                                                IsValidApptDate = true;
                                            }

                                        }

                                        if (IsValidApptDate.Equals(true))
                                        {

                                            string mon = Convert.ToDateTime(Apptdate).Month.ToString();

                                            if (mon.Length == 1)
                                            {
                                                mon = "0" + Convert.ToDateTime(Apptdate).Month.ToString();
                                            }
                                            string dd = Convert.ToDateTime(Apptdate).Day.ToString();

                                            if (dd.Length == 1)
                                            {
                                                dd = "0" + Convert.ToDateTime(Apptdate).Day.ToString();
                                            }

                                            string dtPart1 = mon + dd;

                                            dtPart2 = dtPart1 + ".";
                                        }

                                        string Start_FullTime = "";

                                        string[] arraptStiming0 = null;

                                        if (ApptStart_Time != "")
                                        {
                                            string ActualAptSTime = "";

                                            if (ApptStart_Time.Contains(" "))
                                            {
                                                arraptStiming0 = ApptStart_Time.Split(' ');

                                                if (arraptStiming0.Length > 1)
                                                {
                                                    ActualAptSTime = arraptStiming0[1].ToString();
                                                }
                                            }

                                            if (ActualAptSTime.Contains(":"))
                                            {

                                                string[] arraptStiming1 = ActualAptSTime.Split(':');

                                                if (arraptStiming1.Length > 1)
                                                {
                                                    if (!(null == arraptStiming1[1]))
                                                    {
                                                        StartHours = Convert.ToInt32(arraptStiming1[0].ToString());

                                                        StartMinutes = Convert.ToInt32(arraptStiming1[1].ToString());

                                                        StartTm = arraptStiming0[2].ToString();

                                                        if (StartMinutes == 0)
                                                        {
                                                            Start_FullTime = StartHours.ToString() + "00";
                                                        }
                                                        else
                                                        {
                                                            Start_FullTime = StartHours.ToString() + StartMinutes.ToString();
                                                        }
                                                    }

                                                }

                                                // get end time.
                                                ExpEndTimeStr = "";

                                                if (ExpApptTime != "")
                                                {
                                                    if (ExpApptTime.Contains(' '))
                                                    {
                                                        string[] arrEndTimes = ExpApptTime.Split(' ');

                                                        int arrlen = arrEndTimes.Length;

                                                        int EndHours = 0, EndMinutes = 0;

                                                        if (arrlen <= 2)
                                                        {

                                                            if (!(null == arrEndTimes[0]))
                                                            {
                                                                if (!(null == arrEndTimes[1]))
                                                                {
                                                                    if (arrEndTimes[1].ToString().Equals("hour") || arrEndTimes[1].ToString().Equals("hours"))
                                                                    {
                                                                        EndHours = Convert.ToInt32(arrEndTimes[0].ToString());
                                                                    }
                                                                    else
                                                                    {
                                                                        if (arrEndTimes[1].ToString().Equals("minute") || arrEndTimes[1].ToString().Equals("minutes"))
                                                                        {
                                                                            EndMinutes = Convert.ToInt32(arrEndTimes[0].ToString());

                                                                        }
                                                                    }
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (!(null == arrEndTimes[2]))
                                                            {
                                                                if (arrlen == 4)
                                                                {
                                                                    if ((arrEndTimes[1].ToString().Equals("hour") || arrEndTimes[1].ToString().Equals("hours")) && (arrEndTimes[3].ToString().Equals("minute") || arrEndTimes[3].ToString().Equals("minutes")))
                                                                    {
                                                                        EndHours = Convert.ToInt32(arrEndTimes[0].ToString());

                                                                        EndMinutes = Convert.ToInt32(arrEndTimes[2].ToString());
                                                                    }
                                                                }
                                                            }

                                                        }

                                                        TimeSpan Stime = new TimeSpan(StartHours, StartMinutes, 0);

                                                        TimeSpan Etime = new TimeSpan(EndHours, EndMinutes, 0);

                                                        TimeSpan CalcTime = Stime + Etime;

                                                        time = 0;

                                                        time = Math.Round(Convert.ToDecimal(new TimeSpan(EndHours, EndMinutes, 0).TotalHours), 2);

                                                        string EndMin = CalcTime.Minutes.ToString();

                                                        if (EndMin.Equals("0"))
                                                        {
                                                            EndMin = "00";
                                                        }
                                                        string EndHoursStr = CalcTime.Hours.ToString();

                                                        string tt = StartTm;

                                                        if (CalcTime.Hours >= 12)
                                                        {
                                                            string time_str = CalcTime.Hours + ":00:00";

                                                            TimeSpan time_span = TimeSpan.Parse(time_str);

                                                            DateTime d = new DateTime(time_span.Ticks);

                                                            string tm = d.ToString("hh");

                                                            EndHoursStr = tm;

                                                            tt = "PM";
                                                        }

                                                        ExpEndTimeStr = EndHoursStr + ":" + CalcTime.Minutes.ToString() + " " + tt;

                                                        Start_EndTime = Convert.ToInt32(EndHoursStr) + EndMin;
                                                    }
                                                }

                                            }
                                        }
                                        string ExpRevAmount = "";
                                        if (ApptString.Contains("$"))
                                        {
                                            string[] apptstr = ApptString.Split(',');

                                            if (apptstr.Length > 0)
                                            {
                                                for (int i = 0; i < apptstr.Length; i++)
                                                {
                                                    if (!(null == apptstr[i]))
                                                    {
                                                        if (apptstr[i].ToString().Trim().StartsWith("$"))
                                                        {
                                                            ExpRevAmount = apptstr[i].ToString().Trim().Substring(1).ToString();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }

                                        }

                                        dtTime = dtPart2 + Start_FullTime + "-" + Start_EndTime;

                                        string ExpectedPetTime = time.ToString();

                                        if (IsValidApptDate.Equals(true))
                                        {

                                            DataSet ds = objgroomer.GetGroomername(gname);
                                            if (ds.Tables.Count > 0)
                                            {
                                                if (ds.Tables[0].Rows.Count > 0)
                                                {
                                                    gid = Convert.ToInt32(ds.Tables[0].Rows[0]["GID"].ToString());

                                                    DataSet dsseq = new DataSet();

                                                    Apptdate = Convert.ToDateTime(Apptdate).Date.ToString("MM/dd/yyyy") + " 12:00:00 AM";

                                                    dsseq = objgroomer.GetMaxSequencenoOfGroomer(gid, Apptdate);
                                                    SeqNum = 0;
                                                    if (dsseq.Tables.Count > 0)
                                                    {
                                                        if (dsseq.Tables[0].Rows.Count > 0)
                                                        {
                                                            SeqNum = Convert.ToInt32(dsseq.Tables[0].Rows[0]["sequence"].ToString());
                                                        }
                                                        else
                                                        {
                                                            SeqNum = 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        bool IsValidAppt = IsValidAppointment(Apptdate, dtTime, ApptString, gname, ExpectedPetTime, SeqNum, ApptStart_Time, ExpApptTime);

                                        bool IsValidApptRevenue = IsValidRevAmt(ExpRevAmount);
                                        if (IsValidApptRevenue.Equals(false))
                                        {
                                            ExpRevAmount = "0";
                                        }

                                        if (IsValidAppt.Equals(true))
                                        {

                                            bool IsValidDateSel = false;

                                            if (Convert.ToDateTime(Apptdate).Date >= DateTime.Now.Date)
                                            {
                                                IsValidDateSel = true;

                                            }

                                            if (IsValidDateSel.Equals(true))
                                            {
                                                int IsValidApptment = objgroomer.CheckApptExists(gid, Apptdate, dtTime);

                                                string aptSTiming = arraptStiming0[1].ToString() + " " + arraptStiming0[2].ToString();

                                                if (IsValidApptment.Equals(true))
                                                {
                                                    int ApptID = objgroomer.InsertGroomerAppointment(gid, Apptdate, "", "", ExpRevAmount, ApptString, dtTime, SeqNum, Convert.ToDecimal(ExpectedPetTime), ZipCode, aptSTiming, NameofCustomer, ExpEndTimeStr);

                                                    if (ApptID > 0)
                                                    {
                                                        NoofInsertedAppt++;
                                                    }

                                                    if (ApptString.Contains("REC"))
                                                    {
                                                        DateTime dtAptCreationLastDate = Convert.ToDateTime(Apptdate).AddMonths(6).Date;

                                                        string AppointmentsSpan = "";

                                                        string[] apptstr = ApptString.Split(',');

                                                        if (apptstr.Length > 0)
                                                        {
                                                            for (int i = 0; i < apptstr.Length; i++)
                                                            {
                                                                if (!(null == apptstr[i]))
                                                                {
                                                                    if (apptstr[i].ToString().Trim().StartsWith("REC") && apptstr[i].ToString().Trim().Length <= 5)
                                                                    {
                                                                        AppointmentsSpan = apptstr[i].ToString().Trim().Substring(3).ToString();

                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }


                                                        if (AppointmentsSpan != "")
                                                        {
                                                            int SpanDays = Convert.ToInt32(Convert.ToInt32(AppointmentsSpan) * 7);

                                                            DateTime NextAptDate = Convert.ToDateTime(Apptdate).AddDays(SpanDays).Date;

                                                            while (NextAptDate <= dtAptCreationLastDate)
                                                            {

                                                                string mon = NextAptDate.Month.ToString();
                                                                if (mon.Length == 1)
                                                                {
                                                                    mon = "0" + NextAptDate.Month.ToString();
                                                                }

                                                                string dd = NextAptDate.Day.ToString();

                                                                if (dd.Length == 1)
                                                                {
                                                                    dd = "0" + NextAptDate.Day.ToString();
                                                                }

                                                                string dtPart1 = mon + dd;

                                                                dtPart2 = dtPart1 + ".";

                                                                dtTime = dtPart2 + Start_FullTime + "-" + Start_EndTime;

                                                                DataSet dsseqNo = objgroomer.GetMaxSequencenoOfGroomer(gid, NextAptDate.ToString());

                                                                int SeqNumber = 0;

                                                                if (dsseqNo.Tables.Count > 0)
                                                                {
                                                                    if (dsseqNo.Tables[0].Rows.Count > 0)
                                                                    {
                                                                        SeqNumber = Convert.ToInt32(dsseqNo.Tables[0].Rows[0]["sequence"].ToString());
                                                                    }
                                                                    else
                                                                    {
                                                                        SeqNumber = 1;
                                                                    }
                                                                }

                                                                int IsValidApptments = objgroomer.CheckApptExists(gid, NextAptDate.ToString(), dtTime);

                                                                if (IsValidApptment > 0)
                                                                {
                                                                    int RECApptID = objgroomer.InsertGroomerAppointment(gid, NextAptDate.ToString(), "", "", ExpRevAmount, ApptString, dtTime, SeqNumber, Convert.ToDecimal(ExpectedPetTime), ZipCode, aptSTiming, NameofCustomer, ExpEndTimeStr);

                                                                    if (RECApptID > 0)
                                                                    {
                                                                        NoofInsertedAppt++;
                                                                    }
                                                                }

                                                                NextAptDate = NextAptDate.AddDays(SpanDays).Date;

                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                SuccesfullMessage(NoofInsertedAppt.ToString() + " Appointments created Successfully.");
                            }
                        }
                    }
                }
                else
                {
                    ErrMessage("Please Select file to upload the appointments.");
                }
            }
            catch (Exception ex)
            {
                ErrMessage("Error occured while uploading the appointments data.");
            }
        }

        public void ErrMessage(string Message)
        {

            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        public void SuccesfullMessage(string Message)
        {

            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Int32 result;

            return Int32.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        protected bool CheckZipCode(string code)
        {
            bool blnValidateNumeric = (isNumeric(code, System.Globalization.NumberStyles.Integer));

            return blnValidateNumeric;
        }

        protected bool CheckIsValidTimeSpanAppt(int gid, string Apptdate, string aptSTiming, string ExpEndTime)
        {
            bool IsValid = true;

            Groomer objgroomer = new Groomer();

            DataSet dsAppts = objgroomer.GetAppts(gid, Apptdate);

            if (dsAppts.Tables.Count > 0)
            {
                if (dsAppts.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drows in dsAppts.Tables[0].Rows)
                    {
                        string fromhh = "", fromm = "", tohh = "", tomm = "";

                        if (drows["FROMHOURS"].ToString() != "" && drows["FROMMINUTES"].ToString() != "" && drows["TOHOURS"].ToString() != "" && drows["TOMINUTES"].ToString() != "")
                        {
                            fromhh = drows["FROMHOURS"].ToString();

                            fromm = drows["FROMMINUTES"].ToString();

                            tohh = drows["TOHOURS"].ToString();

                            tomm = drows["TOMINUTES"].ToString();


                            string[] arrUploadSTime = new string[3];

                            if (aptSTiming.Contains(":"))
                            {
                                arrUploadSTime = aptSTiming.Split(':');
                            }
                            if (arrUploadSTime.Length > 0)
                            {
                                string hour = arrUploadSTime[0].ToString();

                                string min = arrUploadSTime[1].ToString();

                                string tt = "";

                                if (arrUploadSTime[2].ToString().Contains(" "))
                                {
                                    string[] arrtt = new string[2];

                                    arrtt = arrUploadSTime[2].ToString().Split(' ');

                                    tt = arrtt[1].ToString();
                                }

                                if (tt.Equals("PM"))
                                {
                                    if (Convert.ToInt32(hour) < 12)
                                    {
                                        hour = (12 + Convert.ToInt32(hour)).ToString();
                                    }
                                }
                                string endhours = "";

                                string endminutes = "";

                                if (ExpEndTime != "")
                                {
                                    string endtt = "";

                                    string[] arrUploadETime = new string[2];

                                    if (ExpEndTime.Contains(":") && ExpEndTime.Contains(" "))
                                    {
                                        arrUploadETime = ExpEndTime.Split(':');

                                        if (arrUploadETime.Length > 0)
                                        {
                                            endhours = arrUploadETime[0].ToString();

                                            string[] arrendtt = new string[2];

                                            arrendtt = arrUploadETime[1].ToString().Split(' ');

                                            endminutes = arrendtt[0].ToString();

                                            endtt = arrendtt[1].ToString();


                                        }
                                        if (endtt.Equals("PM"))
                                        {
                                            if (Convert.ToInt32(endhours) < 12)
                                            {
                                                endhours = (12 + Convert.ToInt32(endhours)).ToString();

                                            }
                                        }
                                    }
                                }

                                TimeSpan start = new TimeSpan(Convert.ToInt32(fromhh), Convert.ToInt32(fromm), 0);

                                TimeSpan end = new TimeSpan(Convert.ToInt32(tohh), Convert.ToInt32(tomm), 0);

                                TimeSpan newtime = new TimeSpan(Convert.ToInt32(hour), Convert.ToInt32(min), 0);

                                TimeSpan newEndtime = new TimeSpan(Convert.ToInt32(endhours), Convert.ToInt32(endminutes), 0);

                                if ((newtime > start) && (newtime < end) || newEndtime > start && newEndtime <= end)
                                {
                                    IsValid = false;
                                    break;
                                }

                                if (newtime == start)
                                {
                                    IsValid = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return IsValid;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;

                Response.Write("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}