﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StartNewInstance", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class StartNewInstance : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TrackIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TrackId {
            get {
                return this.TrackIdField;
            }
            set {
                if ((this.TrackIdField.Equals(value) != true)) {
                    this.TrackIdField = value;
                    this.RaisePropertyChanged("TrackId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExampleAppProxy.IService")]
    public interface IService {
        
        // CODEGEN: Generating message contract since the operation StartNewInstance is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/StartNewInstance", ReplyAction="http://tempuri.org/IService/StartNewInstanceResponse")]
        Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceResponse StartNewInstance(Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/StartNewInstance", ReplyAction="http://tempuri.org/IService/StartNewInstanceResponse")]
        System.Threading.Tasks.Task<Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceResponse> StartNewInstanceAsync(Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class StartNewInstanceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstance StartNewInstance;
        
        public StartNewInstanceRequest() {
        }
        
        public StartNewInstanceRequest(Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstance StartNewInstance) {
            this.StartNewInstance = StartNewInstance;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class StartNewInstanceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/", Order=0)]
        public System.Nullable<int> @int;
        
        public StartNewInstanceResponse() {
        }
        
        public StartNewInstanceResponse(System.Nullable<int> @int) {
            this.@int = @int;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.IService>, Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceResponse Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.IService.StartNewInstance(Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest request) {
            return base.Channel.StartNewInstance(request);
        }
        
        public System.Nullable<int> StartNewInstance(Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstance StartNewInstance1) {
            Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest inValue = new Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest();
            inValue.StartNewInstance = StartNewInstance1;
            Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceResponse retVal = ((Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.IService)(this)).StartNewInstance(inValue);
            return retVal.@int;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceResponse> Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.IService.StartNewInstanceAsync(Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest request) {
            return base.Channel.StartNewInstanceAsync(request);
        }
        
        public System.Threading.Tasks.Task<Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceResponse> StartNewInstanceAsync(Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstance StartNewInstance) {
            Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest inValue = new Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.StartNewInstanceRequest();
            inValue.StartNewInstance = StartNewInstance;
            return ((Sychev.Monitoring.Workflow.Example.Proxy.ExampleAppProxy.IService)(this)).StartNewInstanceAsync(inValue);
        }
    }
}