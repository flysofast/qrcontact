﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace QRCodeDemo.WebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://husc.com/", ConfigurationName="WebService.WebServiceHuscSoap")]
    public interface WebServiceHuscSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://husc.com/DemSoLuongNguoiDung", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BeginDemSoLuongNguoiDung(System.AsyncCallback callback, object asyncState);
        
        int EndDemSoLuongNguoiDung(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://husc.com/DanhSachCacNguoiDung", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BeginDanhSachCacNguoiDung(System.AsyncCallback callback, object asyncState);
        
        QRCodeDemo.WebService.QR_CONTACT[] EndDanhSachCacNguoiDung(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://husc.com/InsertNewUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BeginInsertNewUser(string name, string phone, string address, System.AsyncCallback callback, object asyncState);
        
        int EndInsertNewUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://husc.com/SignUp", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BeginSignUp(string username, string password, System.AsyncCallback callback, object asyncState);
        
        int EndSignUp(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://husc.com/Login", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BeginLogin(string username, string password, System.AsyncCallback callback, object asyncState);
        
        int EndLogin(System.IAsyncResult result);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://husc.com/")]
    public partial class QR_CONTACT : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string nameField;
        
        private string phoneField;
        
        private string addressField;
        
        private string usernameField;
        
        private string passwordField;
        
        private System.Nullable<System.DateTime> birthdayField;
        
        private string emailField;
        
        private string websiteField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
                this.RaisePropertyChanged("phone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
                this.RaisePropertyChanged("address");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
        public System.Nullable<System.DateTime> birthday {
            get {
                return this.birthdayField;
            }
            set {
                this.birthdayField = value;
                this.RaisePropertyChanged("birthday");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string website {
            get {
                return this.websiteField;
            }
            set {
                this.websiteField = value;
                this.RaisePropertyChanged("website");
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
    public interface WebServiceHuscSoapChannel : QRCodeDemo.WebService.WebServiceHuscSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DemSoLuongNguoiDungCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DemSoLuongNguoiDungCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DanhSachCacNguoiDungCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DanhSachCacNguoiDungCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public QRCodeDemo.WebService.QR_CONTACT[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((QRCodeDemo.WebService.QR_CONTACT[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InsertNewUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public InsertNewUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SignUpCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SignUpCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public LoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceHuscSoapClient : System.ServiceModel.ClientBase<QRCodeDemo.WebService.WebServiceHuscSoap>, QRCodeDemo.WebService.WebServiceHuscSoap {
        
        private BeginOperationDelegate onBeginDemSoLuongNguoiDungDelegate;
        
        private EndOperationDelegate onEndDemSoLuongNguoiDungDelegate;
        
        private System.Threading.SendOrPostCallback onDemSoLuongNguoiDungCompletedDelegate;
        
        private BeginOperationDelegate onBeginDanhSachCacNguoiDungDelegate;
        
        private EndOperationDelegate onEndDanhSachCacNguoiDungDelegate;
        
        private System.Threading.SendOrPostCallback onDanhSachCacNguoiDungCompletedDelegate;
        
        private BeginOperationDelegate onBeginInsertNewUserDelegate;
        
        private EndOperationDelegate onEndInsertNewUserDelegate;
        
        private System.Threading.SendOrPostCallback onInsertNewUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginSignUpDelegate;
        
        private EndOperationDelegate onEndSignUpDelegate;
        
        private System.Threading.SendOrPostCallback onSignUpCompletedDelegate;
        
        private BeginOperationDelegate onBeginLoginDelegate;
        
        private EndOperationDelegate onEndLoginDelegate;
        
        private System.Threading.SendOrPostCallback onLoginCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public WebServiceHuscSoapClient() {
        }
        
        public WebServiceHuscSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceHuscSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceHuscSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceHuscSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<DemSoLuongNguoiDungCompletedEventArgs> DemSoLuongNguoiDungCompleted;
        
        public event System.EventHandler<DanhSachCacNguoiDungCompletedEventArgs> DanhSachCacNguoiDungCompleted;
        
        public event System.EventHandler<InsertNewUserCompletedEventArgs> InsertNewUserCompleted;
        
        public event System.EventHandler<SignUpCompletedEventArgs> SignUpCompleted;
        
        public event System.EventHandler<LoginCompletedEventArgs> LoginCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult QRCodeDemo.WebService.WebServiceHuscSoap.BeginDemSoLuongNguoiDung(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDemSoLuongNguoiDung(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int QRCodeDemo.WebService.WebServiceHuscSoap.EndDemSoLuongNguoiDung(System.IAsyncResult result) {
            return base.Channel.EndDemSoLuongNguoiDung(result);
        }
        
        private System.IAsyncResult OnBeginDemSoLuongNguoiDung(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).BeginDemSoLuongNguoiDung(callback, asyncState);
        }
        
        private object[] OnEndDemSoLuongNguoiDung(System.IAsyncResult result) {
            int retVal = ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).EndDemSoLuongNguoiDung(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDemSoLuongNguoiDungCompleted(object state) {
            if ((this.DemSoLuongNguoiDungCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DemSoLuongNguoiDungCompleted(this, new DemSoLuongNguoiDungCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DemSoLuongNguoiDungAsync() {
            this.DemSoLuongNguoiDungAsync(null);
        }
        
        public void DemSoLuongNguoiDungAsync(object userState) {
            if ((this.onBeginDemSoLuongNguoiDungDelegate == null)) {
                this.onBeginDemSoLuongNguoiDungDelegate = new BeginOperationDelegate(this.OnBeginDemSoLuongNguoiDung);
            }
            if ((this.onEndDemSoLuongNguoiDungDelegate == null)) {
                this.onEndDemSoLuongNguoiDungDelegate = new EndOperationDelegate(this.OnEndDemSoLuongNguoiDung);
            }
            if ((this.onDemSoLuongNguoiDungCompletedDelegate == null)) {
                this.onDemSoLuongNguoiDungCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDemSoLuongNguoiDungCompleted);
            }
            base.InvokeAsync(this.onBeginDemSoLuongNguoiDungDelegate, null, this.onEndDemSoLuongNguoiDungDelegate, this.onDemSoLuongNguoiDungCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult QRCodeDemo.WebService.WebServiceHuscSoap.BeginDanhSachCacNguoiDung(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDanhSachCacNguoiDung(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        QRCodeDemo.WebService.QR_CONTACT[] QRCodeDemo.WebService.WebServiceHuscSoap.EndDanhSachCacNguoiDung(System.IAsyncResult result) {
            return base.Channel.EndDanhSachCacNguoiDung(result);
        }
        
        private System.IAsyncResult OnBeginDanhSachCacNguoiDung(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).BeginDanhSachCacNguoiDung(callback, asyncState);
        }
        
        private object[] OnEndDanhSachCacNguoiDung(System.IAsyncResult result) {
            QRCodeDemo.WebService.QR_CONTACT[] retVal = ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).EndDanhSachCacNguoiDung(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDanhSachCacNguoiDungCompleted(object state) {
            if ((this.DanhSachCacNguoiDungCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DanhSachCacNguoiDungCompleted(this, new DanhSachCacNguoiDungCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DanhSachCacNguoiDungAsync() {
            this.DanhSachCacNguoiDungAsync(null);
        }
        
        public void DanhSachCacNguoiDungAsync(object userState) {
            if ((this.onBeginDanhSachCacNguoiDungDelegate == null)) {
                this.onBeginDanhSachCacNguoiDungDelegate = new BeginOperationDelegate(this.OnBeginDanhSachCacNguoiDung);
            }
            if ((this.onEndDanhSachCacNguoiDungDelegate == null)) {
                this.onEndDanhSachCacNguoiDungDelegate = new EndOperationDelegate(this.OnEndDanhSachCacNguoiDung);
            }
            if ((this.onDanhSachCacNguoiDungCompletedDelegate == null)) {
                this.onDanhSachCacNguoiDungCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDanhSachCacNguoiDungCompleted);
            }
            base.InvokeAsync(this.onBeginDanhSachCacNguoiDungDelegate, null, this.onEndDanhSachCacNguoiDungDelegate, this.onDanhSachCacNguoiDungCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult QRCodeDemo.WebService.WebServiceHuscSoap.BeginInsertNewUser(string name, string phone, string address, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginInsertNewUser(name, phone, address, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int QRCodeDemo.WebService.WebServiceHuscSoap.EndInsertNewUser(System.IAsyncResult result) {
            return base.Channel.EndInsertNewUser(result);
        }
        
        private System.IAsyncResult OnBeginInsertNewUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string name = ((string)(inValues[0]));
            string phone = ((string)(inValues[1]));
            string address = ((string)(inValues[2]));
            return ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).BeginInsertNewUser(name, phone, address, callback, asyncState);
        }
        
        private object[] OnEndInsertNewUser(System.IAsyncResult result) {
            int retVal = ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).EndInsertNewUser(result);
            return new object[] {
                    retVal};
        }
        
        private void OnInsertNewUserCompleted(object state) {
            if ((this.InsertNewUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.InsertNewUserCompleted(this, new InsertNewUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void InsertNewUserAsync(string name, string phone, string address) {
            this.InsertNewUserAsync(name, phone, address, null);
        }
        
        public void InsertNewUserAsync(string name, string phone, string address, object userState) {
            if ((this.onBeginInsertNewUserDelegate == null)) {
                this.onBeginInsertNewUserDelegate = new BeginOperationDelegate(this.OnBeginInsertNewUser);
            }
            if ((this.onEndInsertNewUserDelegate == null)) {
                this.onEndInsertNewUserDelegate = new EndOperationDelegate(this.OnEndInsertNewUser);
            }
            if ((this.onInsertNewUserCompletedDelegate == null)) {
                this.onInsertNewUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnInsertNewUserCompleted);
            }
            base.InvokeAsync(this.onBeginInsertNewUserDelegate, new object[] {
                        name,
                        phone,
                        address}, this.onEndInsertNewUserDelegate, this.onInsertNewUserCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult QRCodeDemo.WebService.WebServiceHuscSoap.BeginSignUp(string username, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSignUp(username, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int QRCodeDemo.WebService.WebServiceHuscSoap.EndSignUp(System.IAsyncResult result) {
            return base.Channel.EndSignUp(result);
        }
        
        private System.IAsyncResult OnBeginSignUp(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).BeginSignUp(username, password, callback, asyncState);
        }
        
        private object[] OnEndSignUp(System.IAsyncResult result) {
            int retVal = ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).EndSignUp(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSignUpCompleted(object state) {
            if ((this.SignUpCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SignUpCompleted(this, new SignUpCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SignUpAsync(string username, string password) {
            this.SignUpAsync(username, password, null);
        }
        
        public void SignUpAsync(string username, string password, object userState) {
            if ((this.onBeginSignUpDelegate == null)) {
                this.onBeginSignUpDelegate = new BeginOperationDelegate(this.OnBeginSignUp);
            }
            if ((this.onEndSignUpDelegate == null)) {
                this.onEndSignUpDelegate = new EndOperationDelegate(this.OnEndSignUp);
            }
            if ((this.onSignUpCompletedDelegate == null)) {
                this.onSignUpCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSignUpCompleted);
            }
            base.InvokeAsync(this.onBeginSignUpDelegate, new object[] {
                        username,
                        password}, this.onEndSignUpDelegate, this.onSignUpCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult QRCodeDemo.WebService.WebServiceHuscSoap.BeginLogin(string username, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginLogin(username, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int QRCodeDemo.WebService.WebServiceHuscSoap.EndLogin(System.IAsyncResult result) {
            return base.Channel.EndLogin(result);
        }
        
        private System.IAsyncResult OnBeginLogin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).BeginLogin(username, password, callback, asyncState);
        }
        
        private object[] OnEndLogin(System.IAsyncResult result) {
            int retVal = ((QRCodeDemo.WebService.WebServiceHuscSoap)(this)).EndLogin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnLoginCompleted(object state) {
            if ((this.LoginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.LoginCompleted(this, new LoginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void LoginAsync(string username, string password) {
            this.LoginAsync(username, password, null);
        }
        
        public void LoginAsync(string username, string password, object userState) {
            if ((this.onBeginLoginDelegate == null)) {
                this.onBeginLoginDelegate = new BeginOperationDelegate(this.OnBeginLogin);
            }
            if ((this.onEndLoginDelegate == null)) {
                this.onEndLoginDelegate = new EndOperationDelegate(this.OnEndLogin);
            }
            if ((this.onLoginCompletedDelegate == null)) {
                this.onLoginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLoginCompleted);
            }
            base.InvokeAsync(this.onBeginLoginDelegate, new object[] {
                        username,
                        password}, this.onEndLoginDelegate, this.onLoginCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override QRCodeDemo.WebService.WebServiceHuscSoap CreateChannel() {
            return new WebServiceHuscSoapClientChannel(this);
        }
        
        private class WebServiceHuscSoapClientChannel : ChannelBase<QRCodeDemo.WebService.WebServiceHuscSoap>, QRCodeDemo.WebService.WebServiceHuscSoap {
            
            public WebServiceHuscSoapClientChannel(System.ServiceModel.ClientBase<QRCodeDemo.WebService.WebServiceHuscSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginDemSoLuongNguoiDung(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("DemSoLuongNguoiDung", _args, callback, asyncState);
                return _result;
            }
            
            public int EndDemSoLuongNguoiDung(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("DemSoLuongNguoiDung", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginDanhSachCacNguoiDung(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("DanhSachCacNguoiDung", _args, callback, asyncState);
                return _result;
            }
            
            public QRCodeDemo.WebService.QR_CONTACT[] EndDanhSachCacNguoiDung(System.IAsyncResult result) {
                object[] _args = new object[0];
                QRCodeDemo.WebService.QR_CONTACT[] _result = ((QRCodeDemo.WebService.QR_CONTACT[])(base.EndInvoke("DanhSachCacNguoiDung", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginInsertNewUser(string name, string phone, string address, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[3];
                _args[0] = name;
                _args[1] = phone;
                _args[2] = address;
                System.IAsyncResult _result = base.BeginInvoke("InsertNewUser", _args, callback, asyncState);
                return _result;
            }
            
            public int EndInsertNewUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("InsertNewUser", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSignUp(string username, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = username;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("SignUp", _args, callback, asyncState);
                return _result;
            }
            
            public int EndSignUp(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("SignUp", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginLogin(string username, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = username;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("Login", _args, callback, asyncState);
                return _result;
            }
            
            public int EndLogin(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("Login", _args, result)));
                return _result;
            }
        }
    }
}
