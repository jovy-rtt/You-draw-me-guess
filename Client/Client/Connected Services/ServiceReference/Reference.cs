﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="MyService", ConfigurationName="ServiceReference.IService", CallbackContract=typeof(Client.ServiceReference.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/Login", ReplyAction="MyService/IService/LoginResponse")]
        bool Login(string id, string pw);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/Login", ReplyAction="MyService/IService/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string id, string pw);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/Registered", ReplyAction="MyService/IService/RegisteredResponse")]
        bool Registered(string id, string pw, byte[] phote, string sn, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/Registered", ReplyAction="MyService/IService/RegisteredResponse")]
        System.Threading.Tasks.Task<bool> RegisteredAsync(string id, string pw, byte[] phote, string sn, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/ForgetPassword", ReplyAction="MyService/IService/ForgetPasswordResponse")]
        bool ForgetPassword(string id, string ps);
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/ForgetPassword", ReplyAction="MyService/IService/ForgetPasswordResponse")]
        System.Threading.Tasks.Task<bool> ForgetPasswordAsync(string id, string ps);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/SendInk")]
        void SendInk(int room, string ink);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/SendInk")]
        System.Threading.Tasks.Task SendInkAsync(int room, string ink);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Logout")]
        void Logout(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Logout")]
        System.Threading.Tasks.Task LogoutAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Talk")]
        void Talk(string userName, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Talk")]
        System.Threading.Tasks.Task TalkAsync(string userName, string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowInk")]
        void ShowInk(string ink);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowLogin")]
        void ShowLogin(string loginUserName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowLogout")]
        void ShowLogout(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowTalk")]
        void ShowTalk(string userName, string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Client.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<Client.ServiceReference.IService>, Client.ServiceReference.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool Login(string id, string pw) {
            return base.Channel.Login(id, pw);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string id, string pw) {
            return base.Channel.LoginAsync(id, pw);
        }
        
        public bool Registered(string id, string pw, byte[] phote, string sn, string name) {
            return base.Channel.Registered(id, pw, phote, sn, name);
        }
        
        public System.Threading.Tasks.Task<bool> RegisteredAsync(string id, string pw, byte[] phote, string sn, string name) {
            return base.Channel.RegisteredAsync(id, pw, phote, sn, name);
        }
        
        public bool ForgetPassword(string id, string ps) {
            return base.Channel.ForgetPassword(id, ps);
        }
        
        public System.Threading.Tasks.Task<bool> ForgetPasswordAsync(string id, string ps) {
            return base.Channel.ForgetPasswordAsync(id, ps);
        }
        
        public void SendInk(int room, string ink) {
            base.Channel.SendInk(room, ink);
        }
        
        public System.Threading.Tasks.Task SendInkAsync(int room, string ink) {
            return base.Channel.SendInkAsync(room, ink);
        }
        
        public void Logout(string userName) {
            base.Channel.Logout(userName);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(string userName) {
            return base.Channel.LogoutAsync(userName);
        }
        
        public void Talk(string userName, string message) {
            base.Channel.Talk(userName, message);
        }
        
        public System.Threading.Tasks.Task TalkAsync(string userName, string message) {
            return base.Channel.TalkAsync(userName, message);
        }
    }
}
