using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergeFile.Core
{
    /// <summary>
    /// 文件内容说明类
    /// </summary>
    public class ControlInfor
    {
        public int _IdNum;
        public int _InforNum;
        public int _num3;
        public int _num4;

        public ControlInfor(string strFirstLine)
        {
            String[] strsFirstLine = strFirstLine.Split(' ');
            strsFirstLine = strsFirstLine.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (!int.TryParse(strsFirstLine[0], out _IdNum))
                throw new ApplicationException("节点数量出错");
            if (!int.TryParse(strsFirstLine[1], out _InforNum))
                throw new ApplicationException("节点信息数量出错");
            int.TryParse(strsFirstLine[2], out _num3);
            int.TryParse(strsFirstLine[3], out _num4);
        }
    }
}
