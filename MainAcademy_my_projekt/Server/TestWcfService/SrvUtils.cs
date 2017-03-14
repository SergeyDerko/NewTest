using System.Threading;

namespace TestWcfService
{
    public static class SrvUtils
    {
        /// <summary>
        /// Замедляет работу основного потока на указанное количество секунд.
        /// </summary>
        /// <param name="seconds">Количество секунд задержки</param>
        /// <param name="stop">ссылка на ключ остановки службы</param>
         public static int TimeScanStopParam = 500;
        public static bool Retarder(int seconds, ref bool stop)
        {
            for (int i = 0; !stop && i < seconds * 1000 / TimeScanStopParam; i++)
            {
                Thread.Sleep(TimeScanStopParam);
            }
            return stop;
        }
    }
}