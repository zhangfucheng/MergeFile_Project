
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mergeFile.Core
{
    /// <summary>
    /// 功能性函数
    /// </summary>
    public class Process
    {
        /// <summary>
        /// 检查文件内容是否符合格式要求
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static bool isLeagalFile(string filepath)  // 检查INP文件合法性
        {
            try
            {
                bool flag = true;
                //FileStream fs = new FileStream();
                StreamReader reader = new StreamReader(filepath);
                String line1 = reader.ReadLine();
                String[] strLine1 = line1.Split(' ');
                strLine1 = strLine1.Where(s => !String.IsNullOrEmpty(s)).ToArray();

                int IdNum, inforNum;
                if (!int.TryParse(strLine1[0], out IdNum))
                    throw new ApplicationException("节点数量出错");
                if (!int.TryParse(strLine1[1], out inforNum))
                    throw new ApplicationException("节点信息数量出错");
                for (int id = 0; id < IdNum; id++)
                {
                    line1 = reader.ReadLine();
                    strLine1 = line1.Split(' ');
                    strLine1 = strLine1.Where(s => !String.IsNullOrEmpty(s)).ToArray();
                    if (strLine1.Length != 5)
                        throw new ApplicationException("带编号的信息出错");
                    for (int infor = 0; infor < inforNum - 1; infor++)
                    {
                        line1 = reader.ReadLine();
                        strLine1 = line1.Split(' ');
                        strLine1 = strLine1.Where(s => !String.IsNullOrEmpty(s)).ToArray();
                        if (strLine1.Length != 4)
                            throw new ApplicationException("信息出错");
                    }
                }
                reader.Close();
                return flag;
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }
        /// <summary>
        /// 检查两个文件中的节点编号是否匹配
        /// </summary>
        /// <param name="pointDictionary1"></param>
        /// <param name="pointDictionary2"></param>
        /// <returns></returns>
        public static bool isMatchedPointId(Dictionary<int, LinkedList<PointInformation>> pointDictionary1, Dictionary<int, LinkedList<PointInformation>> pointDictionary2)
        {
            try
            {
                foreach (var point1 in pointDictionary1)
                {
                    int tempId = point1.Key;
                    bool flag = false;
                    foreach (var point2 in pointDictionary2)
                    {
                        if (tempId == point2.Key)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                        throw new ApplicationException(tempId.ToString() + "节点号在文件2中不存在");
                }
                foreach (var point2 in pointDictionary2)
                {
                    int tempId = point2.Key;
                    bool flag = false;
                    foreach (var point1 in pointDictionary1)
                    {
                        if (tempId == point1.Key)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                        throw new ApplicationException(tempId.ToString() + "节点号在文件1中不存在");
                }
                return true;
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }
        /// <summary>
        /// 读取文件，将文件中关键点信息输出到字典中
        /// </summary>
        /// <param name="filepathname"></param>
        /// <returns></returns>
        public static Dictionary<int, LinkedList<PointInformation>> readFile(string filepathname)
        {
            try
            {
                StreamReader reader = new StreamReader(filepathname);
                String firstLine = reader.ReadLine();
                String[] firstLines = firstLine.Split(' ');
                firstLines = firstLines.Where(s => !String.IsNullOrEmpty(s)).ToArray();
                int IdNum, informationNum;
                int.TryParse(firstLines[0], out IdNum);
                int.TryParse(firstLines[1], out informationNum);

                Dictionary<int, LinkedList<PointInformation>> pointDictionary = new Dictionary<int, LinkedList<PointInformation>>();
                PointInformation pointInfor;

                for (int tempIdNum = 0; tempIdNum < IdNum; tempIdNum++)
                {
                    LinkedList<PointInformation> pointList = new LinkedList<PointInformation>();
                    String information = reader.ReadLine();
                    String[] informations = information.Split(' ');
                    informations = informations.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                    int tempId;
                    int.TryParse(informations[0], out tempId);
                    pointInfor = new PointInformation(information);
                    pointDictionary.Add(tempId, pointList);
                    pointDictionary[tempId].AddLast(pointInfor);
                    for (int inforNum = 0; inforNum < informationNum - 1; inforNum++)
                    {
                        information = reader.ReadLine();
                        pointInfor = new PointInformation(information);
                        pointDictionary[tempId].AddLast(pointInfor);
                    }
                }
                reader.Close();
                return pointDictionary;
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }
        /// <summary>
        /// 写文件，将两个字典中节点信息，按照匹配关系重新写入文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="pointDictionary1"></param>
        /// <param name="pointDictionary2"></param>
        /// <returns></returns>
        public static bool writeFile(String filename, Dictionary<int, LinkedList<PointInformation>> pointDictionary1, Dictionary<int, LinkedList<PointInformation>> pointDictionary2)
        {
            try
            {
                FileStream fileStream = new FileStream(filename, FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                foreach (var point1 in pointDictionary1)
                {
                    StringBuilder tempText = new StringBuilder();
                    int tempId = point1.Key;
                    tempText.Append("\r" + tempId.ToString());
                    foreach (var tempInfor in pointDictionary1[tempId])
                    {
                        tempText.Append("  " + tempInfor._XLoad.ToString());
                        tempText.Append("  " + tempInfor._YLoad.ToString());
                        tempText.Append("  " + tempInfor._ZLoad.ToString());
                        tempText.Append("  " + tempInfor._Remark);
                        tempText.Append("\n  ");
                    }
                    foreach (var tempInfor in pointDictionary2[tempId])
                    {
                        tempText.Append("  " + tempInfor._XLoad.ToString());
                        tempText.Append("  " + tempInfor._YLoad.ToString());
                        tempText.Append("  " + tempInfor._ZLoad.ToString());
                        tempText.Append("  " + tempInfor._Remark);
                        tempText.Append("\n  ");
                    }
                    streamWriter.Write(tempText);
                    streamWriter.Flush();
                }

                streamWriter.Close();
                fileStream.Close();
                return true;
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }
        /// <summary>
        /// 写控制信息
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="file1ControlInfor"></param>
        /// <param name="file2ControlInfor"></param>
        /// <returns></returns>
        public static bool writeControlInfor(String filename, Core.ControlInfor file1ControlInfor, Core.ControlInfor file2ControlInfor)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            String text = file1ControlInfor._IdNum.ToString();
            text += "  " + (file1ControlInfor._InforNum + file2ControlInfor._InforNum).ToString();
            text += "  " + file1ControlInfor._num3.ToString();
            text += "  " + file1ControlInfor._num4.ToString();
            text += "\n";

            streamWriter.Write(text);
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
            return true;
        }

        /// <summary>
        /// 读取控制信息
        /// </summary>
        /// <param name="filepathname"></param>
        /// <returns></returns>
        public static ControlInfor readControlInfor(String filepathname)
        {
            try
            {
                StreamReader reader = new StreamReader(filepathname);
                String strFirsteLine = reader.ReadLine();
                String[] strsFirstLine = strFirsteLine.Split(' ');
                strsFirstLine = strsFirstLine.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                int IdNum, inforNum, num3, num4;
                if (!int.TryParse(strsFirstLine[0], out IdNum))
                    throw new ApplicationException("节点数量出错");
                if (!int.TryParse(strsFirstLine[1], out inforNum))
                    throw new ApplicationException("节点信息数量出错");
                int.TryParse(strsFirstLine[2], out num3);
                int.TryParse(strsFirstLine[3], out num4);
                reader.Close();
                int[] tempIdNum = { IdNum, inforNum, num3, num4 };
                Core.ControlInfor controlInfor = new Core.ControlInfor(strFirsteLine);
                return controlInfor;
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }
    }
}
