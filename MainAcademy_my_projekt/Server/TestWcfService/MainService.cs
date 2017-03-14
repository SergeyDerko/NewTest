using System.ServiceProcess;
using SergeyDerkoLibrary;
using TestWcfCommon;


namespace TestWcfService
{
    internal class MainService : ServiceBase
    {
        
        private readonly BaseService<ScanPc> _scanPcService = new BaseService<ScanPc>();
        private readonly BaseService<ReadLog> _readLogService = new BaseService<ReadLog>();
        
        public void StartSvc()
        {
            Logger.Enter();
           
            _scanPcService.Start();
            _readLogService.Start();
            
            Logger.Leave();
        }

        public void StopSvc()
        {
            Logger.Enter();
           
            _scanPcService.Stop();
            _readLogService.Stop();
            
            Logger.Leave();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            StartSvc();
        }

        protected override void OnStop()
        {
            base.OnStop();
            StopSvc();
        }
    }
}