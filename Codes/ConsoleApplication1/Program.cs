using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileModel fileModel = new FileModel();
            try
            {
                if (File.Exists("C:\\tmp.bmp"))
                {
                    //c#文件流读文件 
                    using (FileStream fsRead = new FileStream("C:\\tmp.bmp", FileMode.Open))
                    {
                        int fsLen = (int)fsRead.Length;
                        byte[] heByte = new byte[fsLen];
                        int r = fsRead.Read(heByte, 0, heByte.Length);
                        //strStream = System.Text.Encoding.UTF8.GetString(heByte);
                        fileModel.Fileby = heByte;
                        fileModel.FileName = Path.GetFileName("C:\\tmp.bmp");
                        fileModel.FileName = Path.GetExtension("C:\\tmp.bmp");
                        fileModel.Msg = "读取成功";
                       
                        string ay = heByte.ToString();
                        string str = System.Text.Encoding.Default.GetString(heByte);
                        byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
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


        }
    }
    public class FileModel
    {
        public string FileName { set; get; }

        public byte[] Fileby { set; get; }

        public string Msg { set; get; }
    }
}
