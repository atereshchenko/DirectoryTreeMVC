using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace DirectoryTree.Models
{
    public class Log
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Info(string text)
        {
            logger.Info($"{text}");
        }

        public static void Info(string text1, string text2)
        {
            logger.Info($"{text1}|{text2}");
        }
        public static void Error(string text)
        {
            logger.Error(text);
        }
    }
}