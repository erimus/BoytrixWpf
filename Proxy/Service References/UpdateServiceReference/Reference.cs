﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boytrix.Logic.DataTransfer.Materializer.UpdateServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UpdateServiceReference.IUpdateService")]
    public interface IUpdateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateService/SaveChanges", ReplyAction="http://tempuri.org/IUpdateService/SaveChangesResponse")]
        string SaveChanges(string sqlStatements);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateService/SaveChanges", ReplyAction="http://tempuri.org/IUpdateService/SaveChangesResponse")]
        System.Threading.Tasks.Task<string> SaveChangesAsync(string sqlStatements);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateService/GetWithSql", ReplyAction="http://tempuri.org/IUpdateService/GetWithSqlResponse")]
        string GetWithSql(string className, string sqlStatements);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateService/GetWithSql", ReplyAction="http://tempuri.org/IUpdateService/GetWithSqlResponse")]
        System.Threading.Tasks.Task<string> GetWithSqlAsync(string className, string sqlStatements);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateService/GetWithSp", ReplyAction="http://tempuri.org/IUpdateService/GetWithSpResponse")]
        string GetWithSp(string Sql, int TimeoutSecs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUpdateService/GetWithSp", ReplyAction="http://tempuri.org/IUpdateService/GetWithSpResponse")]
        System.Threading.Tasks.Task<string> GetWithSpAsync(string Sql, int TimeoutSecs);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUpdateServiceChannel : Boytrix.Logic.DataTransfer.Materializer.UpdateServiceReference.IUpdateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateServiceClient : System.ServiceModel.ClientBase<Boytrix.Logic.DataTransfer.Materializer.UpdateServiceReference.IUpdateService>, Boytrix.Logic.DataTransfer.Materializer.UpdateServiceReference.IUpdateService {
        
        public UpdateServiceClient() {
        }
        
        public UpdateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UpdateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SaveChanges(string sqlStatements) {
            return base.Channel.SaveChanges(sqlStatements);
        }
        
        public System.Threading.Tasks.Task<string> SaveChangesAsync(string sqlStatements) {
            return base.Channel.SaveChangesAsync(sqlStatements);
        }
        
        public string GetWithSql(string className, string sqlStatements) {
            return base.Channel.GetWithSql(className, sqlStatements);
        }
        
        public System.Threading.Tasks.Task<string> GetWithSqlAsync(string className, string sqlStatements) {
            return base.Channel.GetWithSqlAsync(className, sqlStatements);
        }
        
        public string GetWithSp(string Sql, int TimeoutSecs) {
            return base.Channel.GetWithSp(Sql, TimeoutSecs);
        }
        
        public System.Threading.Tasks.Task<string> GetWithSpAsync(string Sql, int TimeoutSecs) {
            return base.Channel.GetWithSpAsync(Sql, TimeoutSecs);
        }
    }
}
