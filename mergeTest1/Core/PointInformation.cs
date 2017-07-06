using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergeFile.Core
{

    /// <summary>
    /// 节点信息说明
    /// </summary>
    public class PointInformation
    {
        public double _XLoad;
        public double _YLoad;
        public double _ZLoad;
        public String _Remark;

        public PointInformation(String strinfor)
        {
            try
            {
                string[] tempValue = strinfor.Split(' ');
                tempValue = tempValue.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                if (tempValue.Length < 4)
                    throw new ApplicationException("传参有误！");
                else if (tempValue.Length == 4)
                {
                    double.TryParse(tempValue[0], out _XLoad);
                    double.TryParse(tempValue[1], out _YLoad);
                    double.TryParse(tempValue[2], out _ZLoad);
                    _Remark = tempValue[3];
                }
                else
                {
                    double.TryParse(tempValue[1], out _XLoad);
                    double.TryParse(tempValue[2], out _YLoad);
                    double.TryParse(tempValue[3], out _ZLoad);
                    _Remark = tempValue[4];
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }
    }
}
