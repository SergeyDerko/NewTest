using System.ServiceModel;

namespace SergeyDerkoLibrary
{
    [ServiceContract]
    interface IReadLog
    {

        [OperationContract]
        ReadLog ReadServiseLog();


    }
}
