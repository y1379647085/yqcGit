using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ExtendMethods
{
    public class FileOperate
    {
        /// <summary>
        /// 打开指定的文件并展示
        /// </summary>
        /// <param name="fileFullName">文件路径</param>
        private void OpenFile(String fileFullName)
        {
            var proc = new Process {StartInfo = {FileName = fileFullName}};
            //打开资源管理器
            //proc.StartInfo.Arguments = @"/select," + fileFullName;
            proc.Start();

        }
    }
}
