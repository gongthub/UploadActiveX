using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace UploadActiveX
{
    [Guid("83C1F24A-56C0-4882-87A2-E49295536527")]
    public class UploadActiveX : ActiveXControl
    {
        public FileModel GetFileStream(string filePath)
        {
            FileModel fileModel = new FileModel();
            try
            {
                if (File.Exists(filePath))
                {
                    //c#文件流读文件 
                    using (FileStream fsRead = new FileStream(filePath, FileMode.Open))
                    {
                        int fsLen = (int)fsRead.Length;
                        byte[] heByte = new byte[fsLen];
                        int r = fsRead.Read(heByte, 0, heByte.Length);
                        //strStream = System.Text.Encoding.UTF8.GetString(heByte);
                        fileModel.Fileby = heByte;
                        fileModel.FileStr = ToStringM(heByte);
                        fileModel.FileName = Path.GetFileName(filePath);
                        fileModel.Msg = "读取成功";
                    }
                }
                else
                {
                    fileModel.Msg = "文件不存在";
                }
            }
            catch (Exception e)
            {
                fileModel.Msg = "读取失败，" + e.Message;
            }

            return fileModel;
        }

        public string ToStringM(byte[] heByte)
        {
            string str = string.Empty;
            if (heByte != null && heByte.Length > 0)
            {
                for (int i = 0; i < heByte.Length; i++)
                {
                    str += heByte[i] + ",";
                }
            }
            return str;
        }
    }
}