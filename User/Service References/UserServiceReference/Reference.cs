﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boytrix.Logic.DataAccess.Proxies.UserService.UserServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserFromDBFromId", ReplyAction="http://tempuri.org/IUserService/GetUserFromDBFromIdResponse")]
        string GetUserFromDBFromId(int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserFromDBFromId", ReplyAction="http://tempuri.org/IUserService/GetUserFromDBFromIdResponse")]
        System.Threading.Tasks.Task<string> GetUserFromDBFromIdAsync(int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserFromDBFromLogin", ReplyAction="http://tempuri.org/IUserService/GetUserFromDBFromLoginResponse")]
        string GetUserFromDBFromLogin(string Login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserFromDBFromLogin", ReplyAction="http://tempuri.org/IUserService/GetUserFromDBFromLoginResponse")]
        System.Threading.Tasks.Task<string> GetUserFromDBFromLoginAsync(string Login);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Boytrix.Logic.DataAccess.Proxies.UserService.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Boytrix.Logic.DataAccess.Proxies.UserService.UserServiceReference.IUserService>, Boytrix.Logic.DataAccess.Proxies.UserService.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetUserFromDBFromId(int UserID) {
            return base.Channel.GetUserFromDBFromId(UserID);
        }
        
        public System.Threading.Tasks.Task<string> GetUserFromDBFromIdAsync(int UserID) {
            return base.Channel.GetUserFromDBFromIdAsync(UserID);
        }
        
        public string GetUserFromDBFromLogin(string Login) {
            return base.Channel.GetUserFromDBFromLogin(Login);
        }
        
        public System.Threading.Tasks.Task<string> GetUserFromDBFromLoginAsync(string Login) {
            return base.Channel.GetUserFromDBFromLoginAsync(Login);
        }
    }
}
