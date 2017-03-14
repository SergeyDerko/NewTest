using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SergeyDerkoLibrary
{
    [ServiceContract]
    public interface IScanPc
    {
        [OperationContract]
        [FaultContract(typeof(DivideByZeroException))]
        Dictionary<string, string> Info();

    }
}
