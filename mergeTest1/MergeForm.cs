using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using mergeFile.Core;




namespace mergeFile
{
    public partial class MergeForm : Form
    {        public MergeForm()
        {
            InitializeComponent();
            filePath1Text.Text = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            filePath2Text.Text = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        public String fileNamePath1 = "";
        public String fileNamePath2 = "";
        public String mergeFileName = "";     
    
        /// <summary>
        /// 按钮点击事件，选择合并文件1,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filepath1_Click(object sender, EventArgs e)
        {
            filePath1Text.Text = openFileDialog();
            fileNamePath1 = filePath1Text.Text;
        }
        /// <summary>
        /// 按钮点击事件，选择合并文件2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filepath2_Click(object sender, EventArgs e)
        {
            filePath2Text.Text = openFileDialog();
            fileNamePath2 = filePath2Text.Text;
        }
        
        /// <summary>
        /// 执行合并任务事件，判断各种异常并抛出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void merge_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(fileNamePath1))
                    throw new ApplicationException("文件1不存在");
                else if (!File.Exists(fileNamePath2))
                    throw new ApplicationException("文件2不存在");

                ControlInfor file1ControlInfor = Process.readControlInfor(fileNamePath1);
                ControlInfor file2ControlInfor = Process.readControlInfor(fileNamePath2);

                if (file1ControlInfor._IdNum == file2ControlInfor._IdNum)
                {
                    if (!Process.isLeagalFile(fileNamePath1))
                        throw new ApplicationException("文件 1 内部节点数和节点信息数不合法");
                    if (!Process.isLeagalFile(fileNamePath2))
                        throw new ApplicationException("文件 2 内部节点数和节点信息数不合法");

                    Dictionary<int, LinkedList<PointInformation>> pointDictionary1 = Process.readFile(fileNamePath1);
                    Dictionary<int, LinkedList<PointInformation>> pointDictionary2 = Process.readFile(fileNamePath2);

                    if (pointDictionary1 == null || pointDictionary2 == null)
                        throw new ApplicationException("获取节点信息为空");

                    if (!Process.isMatchedPointId(pointDictionary1, pointDictionary2))
                        throw new ApplicationException("两文件中节点Id不匹配");

                    mergeFileName = createFileDialog();
                    if (!File.Exists(mergeFileName))
                        throw new ApplicationException("合并的文件不存在");

                    if (!Process.writeControlInfor(mergeFileName, file1ControlInfor, file2ControlInfor))
                        throw new ApplicationException("写控制信息失败");

                    if (!Process.writeFile(mergeFileName, pointDictionary1, pointDictionary2))
                        throw new ApplicationException("写文件失败");

                }
                else
                     throw new ApplicationException("两文件节点数量不匹配");
                MessageBox.Show("OK！合并完成");
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        /// <summary>
        /// 打开对话框选择文件
        /// </summary>
        /// <returns></returns>
        String openFileDialog()   // 调用方法,打开文件对话框
        {
            OpenFileDialog openfile2 = new OpenFileDialog();
            if (openfile2.ShowDialog() == DialogResult.OK)
            {
                return openfile2.FileName;
            }
            else
                return null;
        }
        /// <summary>
        /// 打开对话框创建文件
        /// </summary>
        /// <returns></returns>
        String createFileDialog()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            String filename;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                filename = saveFile.FileName;
                //tempPos = Path.GetExtension(filename).ToLower();
                if (!File.Exists(filename))
                    File.Create(filename).Close();
                //if (!tempPos.Equals(".inp"))
                //    throw new ApplicationException("文件名后缀不是 .inp，建议使用inp后缀名");
                return filename;
            }
            return null;
        }
    } 
}
