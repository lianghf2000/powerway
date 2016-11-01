using System;
using System.IO;
using System.Web.UI.WebControls;

    /// <summary>
    ///UploadHelper 的摘要说明
    /// </summary>
    public class UploadHelper
    {
        public UploadHelper()
        {
            
        }
        public UploadHelper(bool autorename,bool overwrite,bool usedatepath)
        {
            this.autorename = autorename;
            this.overwrite = overwrite;
            this.usedatepath = usedatepath;
        }

        private bool autorename = false;
        private bool overwrite = true;
        private bool usedatepath = true;

        public bool AutoRename
        {
            get { return autorename; }
            set { autorename = value; }
        }

        public bool OverWrite
        {
            get { return overwrite; }
            set { overwrite = value; }
        }
        public bool UseDatePath
        {
            get { return usedatepath; }
            set { usedatepath = value; }
        }        

        public string Upload(string savepath,FileUpload ctrl)
        {
            if (!ctrl.HasFile)
            {
                return string.Empty;
            }
            string filename = ctrl.FileName;
            if (this.autorename)
            {
                filename = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "")+DateTime.Now.Millisecond.ToString();
                Random rnd = new Random();
                for (int i = 0; i < 3; i++)
                {
                    filename += rnd.Next(9).ToString();
                }
                filename += "."+ctrl.FileName.Split('.')[1];
            }
            string savep = savepath;
            string path = string.Empty;
            if (this.usedatepath)
            {
                path="/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
                savep += path;
                savep.Replace("//", "/");
                if (!Directory.Exists(savep))
                {
                    Directory.CreateDirectory(savep);
                }
            }

            if (!this.overwrite)
            {
                if (File.Exists(savep + "/" + filename))
                {
                    throw new Exception("已存在同名文件");
                }
            }

            try
            {
                if (path.StartsWith("/"))
                {
                    path = path.Trim('/');
                }
                ctrl.SaveAs(savep + "/" + filename);
                return path + "/" + filename;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }

