using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO; // for file read / write / create / delete ect...
using System.Globalization;
using System.IO.Compression;
using SQLDMO;

namespace LogicSQLDMO
{
    public class BusinessLogicLayer
    {

        private static StreamReader sr;
        private enum addScriptStatus : uint
        {
            dbScriptAdded = 1,
            dbDiskNotReady = 2,
            dbFileNotFound = 3,
            dbScriptCorrupted = 4
        }
        SQLDMO.SQLServer gSQLServerDMO = new SQLDMO.SQLServer();
        SQLDMO.Database nDatabase = new SQLDMO.Database();
        private SQLServer sqlObject = new SQLServer();


        public void dIsplayServerList(DropDownList dropDownListName)
        {
            SQLDMO.Application oSQLServerDMOApp = new SQLDMO.Application();
            SQLDMO.NameList oNameList;
            oNameList = oSQLServerDMOApp.ListAvailableSQLServers();
            for (int intIndex = 0; intIndex <= oNameList.Count - 1; intIndex++)
            {
                if (oNameList.Item(intIndex as object) != null)
                {
                    dropDownListName.Items.Add(oNameList.Item(intIndex).ToString());
                }
                else
                {
                    dropDownListName.Items.Add("(Local)");

                }
            }
            dropDownListName.SelectedIndex = 0;
            //if (dropDownListName.Items.Count = != null)
            //{
            dropDownListName.Items.Add("(Local)");

            //}
        }
        public void dIsplayDatabases(DropDownList cboDatabase, InfoSQLDMO.informationLayer info)
        {//This is for Database listing.
            try
            {
                SQLDMO._SQLServer SQLServer = new SQLDMO.SQLServer();

                cboDatabase.Items.Clear();
                SQLServer.Connect(info.strServerName, info.strLoginName, info.strPwd);
                foreach (SQLDMO.Database db in SQLServer.Databases)
                {
                    if (db.Name != null)
                        cboDatabase.Items.Add(db.Name);
                }
                if (cboDatabase.Items.Count == 0) cboDatabase.Text = "<No databases found>";
            }
            catch (Exception err)
            {
                info.ErrorMessageDataLayer = err.Message;

            }
        }

        public void addSQLScriptToDataBase(InfoSQLDMO.informationLayer info)
        {
            sqlObject.Connect(info.strServerName, info.strLoginName, info.strPwd);
            SQLDMO.Database dataBase = new SQLDMO.Database();
            string queryString = "";
            try
            {
                dataBase = (SQLDMO.Database)sqlObject.Databases.Item("Master", "");
                FileStream fs = new FileStream(info.scriptFilePath, FileMode.Open);

                if (fs.CanRead)
                {
                    sr = new StreamReader(fs);
                    queryString = sr.ReadToEnd();
                }
                fs.Flush();
                fs.Close();
                fs = null;
                dataBase.ExecuteImmediate(queryString, SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_Default | SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError, "");
            }
            catch (Exception e)
            {
                string exceptionMessage = e.Message;
                info.ErrorMessageDataLayer = "LL:" + e.Message;
            }
            finally
            {
                dataBase = null;
            }

        }
        public void cReateSQLDatabaseBackup(InfoSQLDMO.informationLayer InSQLDMO)
        {//This is for Creating Database Backup.
            try
            {
                DateTime dt = DateTime.Now;
                String[] format = { "dd-MM-yy" };
                string date;
                date = dt.ToString(format[0], DateTimeFormatInfo.InvariantInfo);
                string FileName = "bkp" + InSQLDMO.strdbName + date + ".bkp";
                string myDocPath = InSQLDMO.strmyDocPath;
                FileName = myDocPath + "\\Backup\\" + FileName;
                //  this.txtFile.Text = FileName;
                if (Directory.Exists(myDocPath + "\\Backup"))
                {
                    if (File.Exists(FileName) == false)
                    {
                        SQLDMO._SQLServer SqlSever = new SQLDMO.SQLServer();
                        SqlSever.Connect(InSQLDMO.strServerName, InSQLDMO.strLoginName, InSQLDMO.strPwd);
                        SQLDMO.Backup bak = new SQLDMO.Backup();
                        bak.Devices = bak.Files;
                        bak.Files = FileName;
                        bak.Database = InSQLDMO.strdbName;
                        bak.SQLBackup(SqlSever);
                        string DestFile = myDocPath + "\\Backup" + "\\" + "bkp" + InSQLDMO.strdbName + date + ".zip";
                        zIpDatabseFile(FileName, DestFile);
                        if (File.Exists(FileName))
                        {
                            File.Delete(FileName);
                        }
                        InSQLDMO.ErrorMessageDataLayer = "Database Backup Process " + InSQLDMO.strdbName + " Sucessfully Completed";

                    }
                    else
                    {
                        InSQLDMO.ErrorMessageDataLayer = "The Backup file " + InSQLDMO.strdbName + " is already  exists !. Do You Want to Continue..... '";

                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(myDocPath + "\\Backup");
                    SQLDMO._SQLServer SqlSever = new SQLDMO.SQLServer();
                    SqlSever.Connect(InSQLDMO.strServerName, InSQLDMO.strLoginName, InSQLDMO.strPwd);
                    SQLDMO.Backup bak = new SQLDMO.Backup();
                    bak.Devices = bak.Files;
                    bak.Files = FileName;
                    bak.Database = InSQLDMO.strdbName;
                    bak.SQLBackup(SqlSever);
                    string DestFile = myDocPath + "\\Backup" + "\\" + "bkp" + date + ".zip";
                    zIpDatabseFile(FileName, DestFile);
                    if (File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                    InSQLDMO.ErrorMessageDataLayer = "Backup Process " + InSQLDMO.strdbName + " Sucessfully Completed";
                }
            }

            catch (Exception err)
            {
                InSQLDMO.ErrorMessageDataLayer = err.Message;
            }
        }
        public void cReateSqlDatabseRestore(InfoSQLDMO.informationLayer InSQLDMO)
        {// Tis is for Creating Database restoring.
            try
            {

                string myDocPath = InSQLDMO.strmyDocPath;
                string FileName = InSQLDMO.zipFileName;
                string destPath = InSQLDMO.bkpFileName;

                uNzIpDatabaseFile(FileName, destPath);
                if (File.Exists(destPath) == true)
                {
                    SQLDMO._SQLServer SqlSever = new SQLDMO.SQLServer();
                    SqlSever.Connect(InSQLDMO.strServerName, InSQLDMO.strLoginName, InSQLDMO.strPwd);
                    SQLDMO.Restore res = new SQLDMO.Restore();
                    res.Devices = res.Files;
                    res.Files = destPath;
                    res.Database = InSQLDMO.strdbName;
                    res.ReplaceDatabase = true;
                    res.SQLRestore(SqlSever);
                    InSQLDMO.ErrorMessageDataLayer = "Database Restore Process " + InSQLDMO.strdbName + " Sucessfully Completed";
                    File.Delete(destPath);
                }
                else
                {
                    InSQLDMO.ErrorMessageDataLayer = "Database Restore Process " + InSQLDMO.strdbName + " Sucessfully Completed";
                }
            }
            catch (Exception err)
            {
                InSQLDMO.ErrorMessageDataLayer = err.Message;
            }
        }
        private void zIpDatabseFile(string srcPath, string destPath)
        {//This is for  Zip a File
            byte[] bufferWrite;
            FileStream fsSource;
            FileStream fsDest;
            GZipStream gzCompressed;
            fsSource = new FileStream(srcPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            bufferWrite = new byte[fsSource.Length];
            fsSource.Read(bufferWrite, 0, bufferWrite.Length);
            fsDest = new FileStream(destPath, FileMode.OpenOrCreate, FileAccess.Write);
            gzCompressed = new GZipStream(fsDest, CompressionMode.Compress, true);
            gzCompressed.Write(bufferWrite, 0, bufferWrite.Length);
            fsSource.Close();
            gzCompressed.Close();
            fsDest.Close();
        }

        private void uNzIpDatabaseFile(string SrcPath, string DestPath)
        {// This is for unzip a files.
            byte[] bufferWrite;
            FileStream fsSource;
            FileStream fsDest;
            GZipStream gzDecompressed;
            fsSource = new FileStream(SrcPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            gzDecompressed = new GZipStream(fsSource, CompressionMode.Decompress, true);

            bufferWrite = new byte[4];
            fsSource.Position = (int)fsSource.Length - 4;
            fsSource.Read(bufferWrite, 0, 4);
            fsSource.Position = 0;
            int bufferLength = BitConverter.ToInt32(bufferWrite, 0);

            byte[] buffer = new byte[bufferLength + 100];
            int readOffset = 0;
            int totalBytes = 0;

            while (true)
            {
                int bytesRead = gzDecompressed.Read(buffer, readOffset, 100);

                if (bytesRead == 0)
                    break;

                readOffset += bytesRead;
                totalBytes += bytesRead;
            }

            fsDest = new FileStream(DestPath, FileMode.Create);
            fsDest.Write(buffer, 0, totalBytes);

            fsSource.Close();
            gzDecompressed.Close();
            fsDest.Close();
        }
    }

}
