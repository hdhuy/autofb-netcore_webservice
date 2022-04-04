using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Extensions
{
    public static class FileExt
    {
        public static string LoadFile(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    using (StreamReader sr = File.OpenText(Path))
                    {
                        string savedText = sr.ReadToEnd();
                        return savedText;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}
