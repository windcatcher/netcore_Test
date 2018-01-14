using System;
using log4net;


namespace log4netForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            // 默认简单配置，输出至控制台
            BasicConfigurator.Configure(repository);
            ILog log = LogManager.GetLogger(repository.Name,"NETCorelog4net");

            log.Info("NETCorelog4net log");
            log.Info("test log");
            log.Error("error");
            Console.ReadKey();
        }
    }
}
