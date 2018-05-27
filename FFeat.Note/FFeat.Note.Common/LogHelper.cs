using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFeat.Note.Common
{
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue=new Queue<string>();
        public static List<ILogWriter> LogWriterList = new List<ILogWriter>();
        static LogHelper()
        {
            //LogWriterList.Add(new SqlLogWriter());
            //LogWriterList.Add(new TextLogWriter());
            LogWriterList.Add(new Log4NetWriter());
            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    lock (ExceptionStringQueue)
            //    {

            //        if (ExceptionStringQueue.Count > 0)
            //        {
            //            string str = ExceptionStringQueue.Dequeue();
            //            foreach (var item in LogWriterList)
            //            {
            //                item.LogWriter(str);
            //            }

            //        }
            //        else
            //        {
            //            Thread.Sleep(30);
            //        }
            //    }

            //});
        }
        public static void WriteLog(string exception)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exception);
                ThreadPool.QueueUserWorkItem(o =>
                {
                    lock (ExceptionStringQueue)
                    {

                        if (ExceptionStringQueue.Count > 0)
                        {
                            string str = ExceptionStringQueue.Dequeue();
                            foreach (var item in LogWriterList)
                            {

                                item.LogWriter(str);
                            }

                        }
                        else
                        {
                            Thread.Sleep(30);
                        }
                    }

                });
            }
        }
    }
}
