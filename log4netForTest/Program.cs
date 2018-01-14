using System;
using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace log4netForTest {
    class Program {
        static void Main (string[] args) {
            //  RunLogOnConsole ();
            LogForFile();
        }

        static void RunLogOnConsole () {
            ILoggerRepository repository = LogManager.CreateRepository ("NETCoreRepository");
            // 默认简单配置，输出至控制台
            BasicConfigurator.Configure (repository);
            ILog log = LogManager.GetLogger (repository.Name, "NETCorelog4net");

            log.Info ("NETCorelog4net log");
            log.Info ("test log");
            log.Error ("error");
            Console.ReadKey ();
        }

        static void LogForFile()
        {
            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            log.Info("NETCorelog4net log");
            log.Info("test log");
            log.Error("error");
            log.Info("linezero");
            Console.ReadKey();
        }
    }
}