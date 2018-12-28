﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EAD_Project.SMS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="WS", ConfigurationName="SMS.SMSSoap")]
    public interface SMSSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="WS/sendMessage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string sendMessage(string SMSAccount, string Pwd, string Mobile, string Message);
        
        [System.ServiceModel.OperationContractAttribute(Action="WS/sendMessage", ReplyAction="*")]
        System.Threading.Tasks.Task<string> sendMessageAsync(string SMSAccount, string Pwd, string Mobile, string Message);
        
        [System.ServiceModel.OperationContractAttribute(Action="WS/receiveMessage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        EAD_Project.SMS.SMSData[] receiveMessage(string SMSAccount, string SMSPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="WS/receiveMessage", ReplyAction="*")]
        System.Threading.Tasks.Task<EAD_Project.SMS.SMSData[]> receiveMessageAsync(string SMSAccount, string SMSPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="WS/setMessagesStatusToUnread", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string setMessagesStatusToUnread(string SMSAccount, string SMSPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="WS/setMessagesStatusToUnread", ReplyAction="*")]
        System.Threading.Tasks.Task<string> setMessagesStatusToUnreadAsync(string SMSAccount, string SMSPassword);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="WS")]
    public partial class SMSData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        private string originatorField;
        
        private string dateReceivedField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("Message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Originator {
            get {
                return this.originatorField;
            }
            set {
                this.originatorField = value;
                this.RaisePropertyChanged("Originator");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string DateReceived {
            get {
                return this.dateReceivedField;
            }
            set {
                this.dateReceivedField = value;
                this.RaisePropertyChanged("DateReceived");
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
    public interface SMSSoapChannel : EAD_Project.SMS.SMSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SMSSoapClient : System.ServiceModel.ClientBase<EAD_Project.SMS.SMSSoap>, EAD_Project.SMS.SMSSoap {
        
        public SMSSoapClient() {
        }
        
        public SMSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SMSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SMSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SMSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string sendMessage(string SMSAccount, string Pwd, string Mobile, string Message) {
            return base.Channel.sendMessage(SMSAccount, Pwd, Mobile, Message);
        }
        
        public System.Threading.Tasks.Task<string> sendMessageAsync(string SMSAccount, string Pwd, string Mobile, string Message) {
            return base.Channel.sendMessageAsync(SMSAccount, Pwd, Mobile, Message);
        }
        
        public EAD_Project.SMS.SMSData[] receiveMessage(string SMSAccount, string SMSPassword) {
            return base.Channel.receiveMessage(SMSAccount, SMSPassword);
        }
        
        public System.Threading.Tasks.Task<EAD_Project.SMS.SMSData[]> receiveMessageAsync(string SMSAccount, string SMSPassword) {
            return base.Channel.receiveMessageAsync(SMSAccount, SMSPassword);
        }
        
        public string setMessagesStatusToUnread(string SMSAccount, string SMSPassword) {
            return base.Channel.setMessagesStatusToUnread(SMSAccount, SMSPassword);
        }
        
        public System.Threading.Tasks.Task<string> setMessagesStatusToUnreadAsync(string SMSAccount, string SMSPassword) {
            return base.Channel.setMessagesStatusToUnreadAsync(SMSAccount, SMSPassword);
        }
    }
}