﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoapWebServ.SoapWebServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SoapWebServiceReference.WebServiceSoap")]
    public interface WebServiceSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        SoapWebServ.SoapWebServiceReference.HelloWorldResponse HelloWorld(SoapWebServ.SoapWebServiceReference.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<SoapWebServ.SoapWebServiceReference.HelloWorldResponse> HelloWorldAsync(SoapWebServ.SoapWebServiceReference.HelloWorldRequest request);
        
        // CODEGEN: Generating message contract since element name ShowRacesResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ShowRaces", ReplyAction="*")]
        SoapWebServ.SoapWebServiceReference.ShowRacesResponse ShowRaces(SoapWebServ.SoapWebServiceReference.ShowRacesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ShowRaces", ReplyAction="*")]
        System.Threading.Tasks.Task<SoapWebServ.SoapWebServiceReference.ShowRacesResponse> ShowRacesAsync(SoapWebServ.SoapWebServiceReference.ShowRacesRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public SoapWebServ.SoapWebServiceReference.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(SoapWebServ.SoapWebServiceReference.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public SoapWebServ.SoapWebServiceReference.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(SoapWebServ.SoapWebServiceReference.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShowRacesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShowRaces", Namespace="http://tempuri.org/", Order=0)]
        public SoapWebServ.SoapWebServiceReference.ShowRacesRequestBody Body;
        
        public ShowRacesRequest() {
        }
        
        public ShowRacesRequest(SoapWebServ.SoapWebServiceReference.ShowRacesRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ShowRacesRequestBody {
        
        public ShowRacesRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShowRacesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShowRacesResponse", Namespace="http://tempuri.org/", Order=0)]
        public SoapWebServ.SoapWebServiceReference.ShowRacesResponseBody Body;
        
        public ShowRacesResponse() {
        }
        
        public ShowRacesResponse(SoapWebServ.SoapWebServiceReference.ShowRacesResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ShowRacesResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ShowRacesResult;
        
        public ShowRacesResponseBody() {
        }
        
        public ShowRacesResponseBody(string ShowRacesResult) {
            this.ShowRacesResult = ShowRacesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSoapChannel : SoapWebServ.SoapWebServiceReference.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<SoapWebServ.SoapWebServiceReference.WebServiceSoap>, SoapWebServ.SoapWebServiceReference.WebServiceSoap {
        
        public WebServiceSoapClient() {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SoapWebServ.SoapWebServiceReference.HelloWorldResponse SoapWebServ.SoapWebServiceReference.WebServiceSoap.HelloWorld(SoapWebServ.SoapWebServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            SoapWebServ.SoapWebServiceReference.HelloWorldRequest inValue = new SoapWebServ.SoapWebServiceReference.HelloWorldRequest();
            inValue.Body = new SoapWebServ.SoapWebServiceReference.HelloWorldRequestBody();
            SoapWebServ.SoapWebServiceReference.HelloWorldResponse retVal = ((SoapWebServ.SoapWebServiceReference.WebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SoapWebServ.SoapWebServiceReference.HelloWorldResponse> SoapWebServ.SoapWebServiceReference.WebServiceSoap.HelloWorldAsync(SoapWebServ.SoapWebServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<SoapWebServ.SoapWebServiceReference.HelloWorldResponse> HelloWorldAsync() {
            SoapWebServ.SoapWebServiceReference.HelloWorldRequest inValue = new SoapWebServ.SoapWebServiceReference.HelloWorldRequest();
            inValue.Body = new SoapWebServ.SoapWebServiceReference.HelloWorldRequestBody();
            return ((SoapWebServ.SoapWebServiceReference.WebServiceSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SoapWebServ.SoapWebServiceReference.ShowRacesResponse SoapWebServ.SoapWebServiceReference.WebServiceSoap.ShowRaces(SoapWebServ.SoapWebServiceReference.ShowRacesRequest request) {
            return base.Channel.ShowRaces(request);
        }
        
        public string ShowRaces() {
            SoapWebServ.SoapWebServiceReference.ShowRacesRequest inValue = new SoapWebServ.SoapWebServiceReference.ShowRacesRequest();
            inValue.Body = new SoapWebServ.SoapWebServiceReference.ShowRacesRequestBody();
            SoapWebServ.SoapWebServiceReference.ShowRacesResponse retVal = ((SoapWebServ.SoapWebServiceReference.WebServiceSoap)(this)).ShowRaces(inValue);
            return retVal.Body.ShowRacesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SoapWebServ.SoapWebServiceReference.ShowRacesResponse> SoapWebServ.SoapWebServiceReference.WebServiceSoap.ShowRacesAsync(SoapWebServ.SoapWebServiceReference.ShowRacesRequest request) {
            return base.Channel.ShowRacesAsync(request);
        }
        
        public System.Threading.Tasks.Task<SoapWebServ.SoapWebServiceReference.ShowRacesResponse> ShowRacesAsync() {
            SoapWebServ.SoapWebServiceReference.ShowRacesRequest inValue = new SoapWebServ.SoapWebServiceReference.ShowRacesRequest();
            inValue.Body = new SoapWebServ.SoapWebServiceReference.ShowRacesRequestBody();
            return ((SoapWebServ.SoapWebServiceReference.WebServiceSoap)(this)).ShowRacesAsync(inValue);
        }
    }
}
