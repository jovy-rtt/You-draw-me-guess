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
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Userdata", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class Userdata : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AcountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AvartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GradeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> RoomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ScoreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SignField;
        
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
        public string Acount {
            get {
                return this.AcountField;
            }
            set {
                if ((object.ReferenceEquals(this.AcountField, value) != true)) {
                    this.AcountField = value;
                    this.RaisePropertyChanged("Acount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Avart {
            get {
                return this.AvartField;
            }
            set {
                if ((object.ReferenceEquals(this.AvartField, value) != true)) {
                    this.AvartField = value;
                    this.RaisePropertyChanged("Avart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Grade {
            get {
                return this.GradeField;
            }
            set {
                if ((this.GradeField.Equals(value) != true)) {
                    this.GradeField = value;
                    this.RaisePropertyChanged("Grade");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Room {
            get {
                return this.RoomField;
            }
            set {
                if ((this.RoomField.Equals(value) != true)) {
                    this.RoomField = value;
                    this.RaisePropertyChanged("Room");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Score {
            get {
                return this.ScoreField;
            }
            set {
                if ((this.ScoreField.Equals(value) != true)) {
                    this.ScoreField = value;
                    this.RaisePropertyChanged("Score");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sign {
            get {
                return this.SignField;
            }
            set {
                if ((object.ReferenceEquals(this.SignField, value) != true)) {
                    this.SignField = value;
                    this.RaisePropertyChanged("Sign");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="MyService", ConfigurationName="ServiceReference.IService", CallbackContract=typeof(Client.ServiceReference.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/test", ReplyAction="MyService/IService/testResponse")]
        bool test();
        
        [System.ServiceModel.OperationContractAttribute(Action="MyService/IService/test", ReplyAction="MyService/IService/testResponse")]
        System.Threading.Tasks.Task<bool> testAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/SendInk")]
        void SendInk(int room, string ink);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/SendInk")]
        System.Threading.Tasks.Task SendInkAsync(int room, string ink);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Login")]
        void Login(int id, string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Login")]
        System.Threading.Tasks.Task LoginAsync(int id, string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Logout")]
        void Logout(int id, string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Logout")]
        System.Threading.Tasks.Task LogoutAsync(int id, string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Talk")]
        void Talk(string userName, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/Talk")]
        System.Threading.Tasks.Task TalkAsync(string userName, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/EnterRoom")]
        void EnterRoom(string userName, int roomId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/EnterRoom")]
        System.Threading.Tasks.Task EnterRoomAsync(string userName, int roomId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/StartGame")]
        void StartGame(string userName, int roomId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/StartGame")]
        System.Threading.Tasks.Task StartGameAsync(string userName, int roomId);
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
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowInfo")]
        void ShowInfo(Client.ServiceReference.Userdata[] userdatas);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowRoom")]
        void ShowRoom();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowStart")]
        void ShowStart(string userName1, string answer, string tip);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowWin")]
        void ShowWin(string userName, string userName0);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="MyService/IService/ShowNewTurn")]
        void ShowNewTurn(string roommeg, string userName1, string answer, string tip);
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
        
        public bool test() {
            return base.Channel.test();
        }
        
        public System.Threading.Tasks.Task<bool> testAsync() {
            return base.Channel.testAsync();
        }
        
        public void SendInk(int room, string ink) {
            base.Channel.SendInk(room, ink);
        }
        
        public System.Threading.Tasks.Task SendInkAsync(int room, string ink) {
            return base.Channel.SendInkAsync(room, ink);
        }
        
        public void Login(int id, string userName) {
            base.Channel.Login(id, userName);
        }
        
        public System.Threading.Tasks.Task LoginAsync(int id, string userName) {
            return base.Channel.LoginAsync(id, userName);
        }
        
        public void Logout(int id, string userName) {
            base.Channel.Logout(id, userName);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(int id, string userName) {
            return base.Channel.LogoutAsync(id, userName);
        }
        
        public void Talk(string userName, string message) {
            base.Channel.Talk(userName, message);
        }
        
        public System.Threading.Tasks.Task TalkAsync(string userName, string message) {
            return base.Channel.TalkAsync(userName, message);
        }
        
        public void EnterRoom(string userName, int roomId) {
            base.Channel.EnterRoom(userName, roomId);
        }
        
        public System.Threading.Tasks.Task EnterRoomAsync(string userName, int roomId) {
            return base.Channel.EnterRoomAsync(userName, roomId);
        }
        
        public void StartGame(string userName, int roomId) {
            base.Channel.StartGame(userName, roomId);
        }
        
        public System.Threading.Tasks.Task StartGameAsync(string userName, int roomId) {
            return base.Channel.StartGameAsync(userName, roomId);
        }
    }
}
