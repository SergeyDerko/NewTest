using System.ServiceModel;
using System.Threading;
using TestWcfCommon;

namespace TestWcfService
{
    class BaseService<T>
    {
        private volatile bool _stopFlag;
        private Thread _thread;
        private volatile bool _processingError;

        public void Start()
        {
            _thread = new Thread(x =>
            {
                var type = typeof(T);
                var host = new ServiceHost(type);
                Logger.Info("start service: " + type.Name);
                host.Open();

                do
                {

                } while (!SrvUtils.Retarder(30, ref _stopFlag));

                host.Close();
                Logger.Info("stop service: " + type.Name);
            });
            _thread.Start();
        }

        public void Stop()
        {
            _stopFlag = true;
        }
    }
}