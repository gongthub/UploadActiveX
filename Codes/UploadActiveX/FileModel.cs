using System;
using System.Collections.Generic;
using System.Text;

namespace UploadActiveX
{
    public class FileModel
    {
        public string FileName { set; get; }
        public string FileStr { set; get; }

        public byte[] Fileby { set; get; }

        public string Msg { set; get; }
    }
}
