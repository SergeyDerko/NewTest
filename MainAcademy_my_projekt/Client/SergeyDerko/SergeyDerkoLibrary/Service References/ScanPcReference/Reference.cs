﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SergeyDerkoLibrary.Service_References.ScanPcReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ScanPcReference.IScanPc")]
    public interface IScanPc {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScanPc/Info", ReplyAction="http://tempuri.org/IScanPc/InfoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.DivideByZeroException), Action="http://tempuri.org/IScanPc/InfoDivideByZeroExceptionFault", Name="DivideByZeroException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        System.Collections.Generic.Dictionary<string, string> Info();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScanPc/Info", ReplyAction="http://tempuri.org/IScanPc/InfoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>> InfoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IScanPcChannel : IScanPc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ScanPcClient : System.ServiceModel.ClientBase<IScanPc>, IScanPc {
        
        public ScanPcClient() {
        }
        
        public ScanPcClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ScanPcClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ScanPcClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ScanPcClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.Dictionary<string, string> Info() {
            return base.Channel.Info();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>> InfoAsync() {
            return base.Channel.InfoAsync();
        }
    }
}