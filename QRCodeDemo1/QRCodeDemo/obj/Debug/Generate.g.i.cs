﻿#pragma checksum "E:\QrCode\QRCodeDemo1\QRCodeDemo\Generate.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A3655CB09509EB0D62EF2B61BFB5D93"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace QRCodeDemo {
    
    
    public partial class Generate : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.CheckBox CbPhone;
        
        internal System.Windows.Controls.CheckBox CbMail;
        
        internal System.Windows.Controls.CheckBox CbAdd;
        
        internal System.Windows.Controls.CheckBox CbName;
        
        internal System.Windows.Controls.TextBox TbAdd;
        
        internal System.Windows.Controls.TextBox TbName;
        
        internal System.Windows.Controls.TextBox TbPhone;
        
        internal System.Windows.Controls.TextBox TbMail;
        
        internal System.Windows.Controls.Button BtGenerate;
        
        internal System.Windows.Controls.Image img_qr;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/QRCodeDemo;component/Generate.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.CbPhone = ((System.Windows.Controls.CheckBox)(this.FindName("CbPhone")));
            this.CbMail = ((System.Windows.Controls.CheckBox)(this.FindName("CbMail")));
            this.CbAdd = ((System.Windows.Controls.CheckBox)(this.FindName("CbAdd")));
            this.CbName = ((System.Windows.Controls.CheckBox)(this.FindName("CbName")));
            this.TbAdd = ((System.Windows.Controls.TextBox)(this.FindName("TbAdd")));
            this.TbName = ((System.Windows.Controls.TextBox)(this.FindName("TbName")));
            this.TbPhone = ((System.Windows.Controls.TextBox)(this.FindName("TbPhone")));
            this.TbMail = ((System.Windows.Controls.TextBox)(this.FindName("TbMail")));
            this.BtGenerate = ((System.Windows.Controls.Button)(this.FindName("BtGenerate")));
            this.img_qr = ((System.Windows.Controls.Image)(this.FindName("img_qr")));
        }
    }
}

