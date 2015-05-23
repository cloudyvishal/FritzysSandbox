using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.IO.Compression;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Ionic.Zip;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class SiteBackup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string FileName;

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        protected void btnSiteDownload_Click(object sender, EventArgs e)
        {
            Response.Clear();

            Response.BufferOutput = false;

            string sitebkp = ConfigurationManager.AppSettings["ApplicationPath"].ToString();

            string backupFileName = "FritzyCodeBackup" + DateTime.Now.ToString("yyyy-MMM-dd-HHmmss") + ".zip";

            string fileStoragePath = ConfigurationManager.AppSettings["WebBackupPath"] +"\\"+ backupFileName;

            ZipFile zip = new ZipFile(backupFileName);

            zip.AddDirectory(sitebkp); // AddDirectory recurses subdirectories

            zip.Save(fileStoragePath);

            Response.End();
        }

        protected void btnDatabaseDownload_Click(object sender, EventArgs e)
        {
            string filename = "";

            DirectoryInfo info1 = new DirectoryInfo(ConfigurationManager.AppSettings["DLPathNew"]);

            foreach (FileInfo f1 in info1.GetFiles())
            {
                if (f1.Extension == ".zip")
                {
                    filename = Path.GetFileName(f1.FullName);
                }
            }
            string pp = ConfigurationManager.AppSettings["HomePathValue"] + "Download/" + filename;
            Response.Redirect(pp);

        }

        protected void btndatabasedwn_Click(object sender, EventArgs e)
        {
            String databaseName = "fritzylive";

            String userName = "sa";

            String password = "Sql@123";

            String serverName = "VISHALJ\\SQLEXPRESS";

            String destinationPath = ConfigurationManager.AppSettings["DLPathNew"];

            BackupDatabase(databaseName, userName, password, serverName, destinationPath);

            SuccesfullMessage("Database backup completed successfully.");
        }

        private void BackupDatabase(string databaseName, string userName, string password, string serverName, string destinationPath)
        {
            Backup sqlBackup = new Backup();

            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.BackupSetDescription = "ArchiveDataBase:" +
                                             DateTime.Now.ToShortDateString();
            sqlBackup.BackupSetName = "Archive";

            sqlBackup.Database = databaseName;

            BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);

            ServerConnection connection = new ServerConnection(serverName, userName, password);

            Server sqlServer = new Server(connection);

            Database db = sqlServer.Databases[databaseName];

            sqlBackup.Initialize = true;

            sqlBackup.Checksum = true;

            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(deviceItem);

            sqlBackup.Incremental = false;

            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);

            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

            sqlBackup.FormatMedia = false;

            sqlBackup.SqlBackup(sqlServer);

            ZipFile(ConfigurationManager.AppSettings["DLPathNew"] + FileName, ConfigurationManager.AppSettings["DLPathNew"] + FileName + ".zip");
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string filename = "";

            DirectoryInfo info1 = new DirectoryInfo(ConfigurationManager.AppSettings["DLPathNew"]);

            foreach (FileInfo f1 in info1.GetFiles())
            {
                if (f1.Extension == ".zip")
                {
                    filename = Path.GetFileName(f1.FullName);
                }
            }

            string pp = ConfigurationManager.AppSettings["HomePathValue"] + "Download/" + filename;

            Response.Redirect(pp);
        }

        private void ZipFile(string srcFile, string dstFile)
        {
            FileStream fsIn = null; // will open and read the srcFile
            FileStream fsOut = null; // will be used by the GZipStream for output to the dstFile
            GZipStream zip = null;
            byte[] buffer;
            int count = 0;

            try
            {
                fsOut = new FileStream(dstFile, FileMode.Create, FileAccess.Write, FileShare.None);
                zip = new GZipStream(fsOut, CompressionMode.Compress, true);

                fsIn = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                buffer = new byte[fsIn.Length];
                count = fsIn.Read(buffer, 0, buffer.Length);
                fsIn.Close();
                fsIn = null;

                // compress to the destination file
                zip.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                // handle or display the error 
                System.Diagnostics.Debug.Assert(false, ex.ToString());
            }
            finally
            {
                if (zip != null)
                {
                    zip.Close();
                    zip = null;
                }
                if (fsOut != null)
                {
                    fsOut.Close();
                    fsOut = null;
                }
                if (fsIn != null)
                {
                    fsIn.Close();
                    fsIn = null;
                }
            }
        }
    }
}