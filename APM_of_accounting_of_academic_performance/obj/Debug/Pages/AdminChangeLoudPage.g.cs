#pragma checksum "..\..\..\Pages\AdminChangeLoudPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "004314D0C4FC0F4F8B23551A314D065B2695407CCA69984D296C7BCFAD83D18E"
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
    /// AdminChangeLoudPage
    /// </summary>
    public partial class AdminChangeLoudPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Pages\AdminChangeLoudPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FIOCombobox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\AdminChangeLoudPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SpecialityCombobox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\AdminChangeLoudPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GroupsCombobox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\AdminChangeLoudPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateLoudDatePicker;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\AdminChangeLoudPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HoursTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\AdminChangeLoudPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClocksTypeCombobox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\AdminChangeLoudPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectAddCombobox;
        
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
            System.Uri resourceLocater = new System.Uri("/APM_of_accounting_of_academic_performance;component/pages/adminchangeloudpage.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AdminChangeLoudPage.xaml"
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
            this.FIOCombobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.SpecialityCombobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.GroupsCombobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.DateLoudDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.HoursTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\Pages\AdminChangeLoudPage.xaml"
            this.HoursTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.HoursTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ClocksTypeCombobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.SubjectAddCombobox = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Pages\AdminChangeLoudPage.xaml"
            this.SubjectAddCombobox.Click += new System.Windows.RoutedEventHandler(this.LoudsChangeButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

