﻿#pragma checksum "..\..\..\Pages\AdminChangeTeachersPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FD26416D253EDD6963A8B5B83B75CD7FB860F6BA191521FE0715BBF87C026A58"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using APM_of_accounting_of_academic_performance.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace APM_of_accounting_of_academic_performance.Pages {
    
    
    /// <summary>
    /// AdminChangeTeachersPage
    /// </summary>
    public partial class AdminChangeTeachersPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Pages\AdminChangeTeachersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Namey_Textbox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\AdminChangeTeachersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PhotoImage;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\AdminChangeTeachersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhotoPathTextBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\AdminChangeTeachersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchPhotoButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/APM_of_accounting_of_academic_performance;component/pages/adminchangeteacherspag" +
                    "e.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AdminChangeTeachersPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Namey_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PhotoImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.PhotoPathTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SearchPhotoButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Pages\AdminChangeTeachersPage.xaml"
            this.SearchPhotoButton.Click += new System.Windows.RoutedEventHandler(this.SearchPhotoButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

