using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Extensions
{
    public static class ConvertExt
    {
        public static Guid ConvertStringToGuid(string str)
        {
            try
            {
                Guid guid = new Guid(str);
                return guid;
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
