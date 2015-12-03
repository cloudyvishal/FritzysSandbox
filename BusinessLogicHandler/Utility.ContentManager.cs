using System;
using System.IO;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

namespace BCL.Utility.Contents
{
    public class ContentManager
    {
        public ContentManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="filename"></param>
        public static void SaveContent(string fileContent, string filename)
        {
            try
            {
                string FilePath = System.Web.HttpContext.Current.Session["StaticContentPhysicalPath"].ToString();

                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string FullPath = FilePath + filename;
                FileStream file = new FileStream(FullPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(fileContent);
                sw.Close();
                file.Close();
            }
            finally
            { }
        }

        public static void SaveRightHandSectionContent(string fileContent, string filename)
        {
            try
            {
                //string FilePath = System.Web.HttpContext.Current.Session["StaticRightHandSectionPhysicalPath"].ToString();
                string FilePath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/";
                FilePath = GetPhysicalPath(FilePath);
                System.Web.HttpContext.Current.Session["StaticSectionPhysicalPath"] = FilePath;

                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string FullPath = FilePath + filename;
                FileStream file = new FileStream(FullPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(fileContent);
                sw.Close();
                file.Close();
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetFileContent(string FileName)
        {
            try
            {
                string content = "";
                string appPath = System.Web.HttpContext.Current.Session["StaticContentPhysicalPath"].ToString();
                string FilePath = appPath + "\\" + FileName;
                if (FilePath.IndexOf(".htm") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".htm", ".txt");
                    }
                }
                else if (FilePath.IndexOf(".txt") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".txt", ".htm");
                    }
                }
                FileInfo f = new FileInfo(FilePath);
                if (f.Exists)
                {
                    FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(file);
                    content = sr.ReadToEnd();
                    sr.Close();
                    file.Close();
                }
                return content;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetRightHandSectionFileContent(string FileName)
        {
            try
            {
                string content = "";
                //string appPath = System.Web.HttpContext.Current.Session["StaticRightHandSectionPhysicalPath"].ToString();

                string appPath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/";
                appPath = GetPhysicalPath(appPath);
                System.Web.HttpContext.Current.Session["StaticSectionPhysicalPath"] = appPath;

                string FilePath = appPath + "\\" + FileName;
                if (FilePath.IndexOf(".htm") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".htm", ".txt");
                    }
                }
                else if (FilePath.IndexOf(".txt") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".txt", ".htm");
                    }
                }
                FileInfo f = new FileInfo(FilePath);
                if (f.Exists)
                {
                    FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(file);
                    content = sr.ReadToEnd();
                    sr.Close();
                    file.Close();
                }
                return content;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetFileContentRightSection(string FileName)
        {
            try
            {
                string content = "";
                string appPath = System.Web.HttpContext.Current.Session["StaticContentPhysicalPath"].ToString();
                string FilePath = appPath + FileName;

                if (FilePath.IndexOf(".htm") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".htm", ".txt");
                    }
                }
                else if (FilePath.IndexOf(".txt") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".txt", ".htm");
                    }
                }
                FileInfo f = new FileInfo(FilePath);
                if (f.Exists)
                {
                    FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(file);
                    content = sr.ReadToEnd();
                    sr.Close();
                    file.Close();
                }
                return content;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetFileContentView(string FileName)
        {
            try
            {
                string content = "";

                string appPath = HttpContext.Current.Request.PhysicalApplicationPath.ToString();

                string FilePath = FileName;

                if (FilePath.IndexOf(".htm") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".htm", ".txt");
                    }
                }
                else if (FilePath.IndexOf(".txt") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".txt", ".htm");
                    }
                }
                FileInfo f = new FileInfo(FilePath);
                if (f.Exists)
                {
                    FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(file);
                    content = sr.ReadToEnd();
                    sr.Close();
                    file.Close();
                }
                return content;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetFileContent1(string FileName)
        {
            try
            {
                string content = "";
                string appPath = System.Web.HttpContext.Current.Session["ProductContentPhysicalPath"].ToString();
                string FilePath = appPath + "\\" + FileName;

                if (FilePath.IndexOf(".htm") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".htm", ".txt");
                    }
                }
                else if (FilePath.IndexOf(".txt") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".txt", ".htm");
                    }
                }
                FileInfo f = new FileInfo(FilePath);
                if (f.Exists)
                {
                    FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(file);
                    content = sr.ReadToEnd();
                    sr.Close();
                    file.Close();
                }
                return content;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="filename"></param>
        public static void SaveContent1(string fileContent, string filename)
        {
            try
            {
                string FilePath = System.Web.HttpContext.Current.Session["ProductContentPhysicalPath"].ToString();

                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string FullPath = FilePath + "\\" + filename;
                FileStream file = new FileStream(FullPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(fileContent);
                sw.Close();
                file.Close();
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="StoreID"></param>
        public static void SetSession(HttpContext context, int StoreID)
        {
            try
            {
                context.Session["StaticContentPath"] = context.Session["HomePath"] + "storedata/customcontent/";
                context.Session["StaticContentPhysicalPath"] = GetPhysicalPath((string)context.Session["StaticContentPath"]);

                context.Session["StaticRightHandSectionPath"] = context.Session["HomePath"] + "StoreData/";
                context.Session["StaticRightHandSectionPhysicalPath"] = GetPhysicalPath((string)context.Session["StaticRightHandSectionPath"]);
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public static string GetPhysicalPath(string virtualPath)
        {
            try
            {
                string filepath = "";
                if (virtualPath.IndexOf("localhost:") >= 0)
                {
                    string path = virtualPath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                    if (path.IndexOf(":") >= 0)
                    {
                        int lenindex = path.IndexOf('/');
                        path = path.Remove(0, lenindex);
                    }
                    filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
                }
                else
                {
                    string path = virtualPath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                    filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
                }
                return filepath;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public string GetPhysicalPath1(string virtualPath)
        {
            try
            {
                string filepath = "";
                if (virtualPath.IndexOf("localhost:") >= 0)
                {
                    string path = virtualPath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                    if (path.IndexOf(":") >= 0)
                    {
                        int lenindex = path.IndexOf('/');
                        path = path.Remove(0, lenindex);
                    }
                    filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
                }
                else
                {
                    string path = virtualPath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                    filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
                }
                return filepath;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetStaticeContent(string FileName)
        {
            try
            {
                string content = "";
                //string appPath = System.Web.HttpContext.Current.Session["StaticRightHandSectionPhysicalPath"].ToString();

                string appPath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/StaticeContent/";
                appPath = GetPhysicalPath(appPath);
                System.Web.HttpContext.Current.Session["StaticSectionPhysicalPath"] = appPath;

                string FilePath = appPath + "\\" + FileName;
                if (FilePath.IndexOf(".htm") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".htm", ".txt");
                    }
                }
                else if (FilePath.IndexOf(".txt") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".txt", ".htm");
                    }
                }
                FileInfo f = new FileInfo(FilePath);
                if (f.Exists)
                {
                    FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(file);
                    content = sr.ReadToEnd();
                    sr.Close();
                    file.Close();
                }
                return content;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetStaticeContentEmail(string FileName)
        {
            try
            {
                string content = "";
                //string appPath = System.Web.HttpContext.Current.Session["StaticRightHandSectionPhysicalPath"].ToString();

                string appPath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/Email/";
                appPath = GetPhysicalPath(appPath);
                System.Web.HttpContext.Current.Session["StaticSectionPhysicalPath"] = appPath;

                string FilePath = appPath + "\\" + FileName;
                if (FilePath.IndexOf(".htm") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".htm", ".txt");
                    }
                }
                else if (FilePath.IndexOf(".txt") > 0)
                {
                    if (!System.IO.File.Exists(FilePath))
                    {
                        FilePath = FilePath.Replace(".txt", ".htm");
                    }
                }
                FileInfo f = new FileInfo(FilePath);
                if (f.Exists)
                {
                    FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(file);
                    content = sr.ReadToEnd();
                    sr.Close();
                    file.Close();
                }
                return content;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbrestorepath"></param>
        /// <returns></returns>
        public static string GetPhysicalPathnew(string dbrestorepath)
        {
            try
            {
                string filepath = "";
                if (dbrestorepath.IndexOf("localhost:") >= 0)
                {
                    string path = dbrestorepath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                    if (path.IndexOf(":") >= 0)
                    {
                        int lenindex = path.IndexOf('/');
                        path = path.Remove(0, lenindex);
                    }
                    filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
                }
                else
                {
                    string path = dbrestorepath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                    filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
                }
                return filepath;
            }
            finally
            { }
        }
    }
}
