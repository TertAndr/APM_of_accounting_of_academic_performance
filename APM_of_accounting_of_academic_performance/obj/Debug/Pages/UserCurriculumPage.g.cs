﻿#pragma checksum "..\..\..\Pages\UserCurriculumPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "02FE037F0D20BEAF1F809B70695DAD8068B4F657253FCF6E646E2CBC2650C6D9"
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
    /// UserCurriculumPage
    /// </summary>
    public partial class UserCurriculumPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Pages\UserCurriculumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LetterrsStackPanel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\UserCurriculumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YearsTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\UserCurriculumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SpecialtysCombobox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\UserCurriculumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CurrentUsersDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/APM_of_accounting_of_academic_performance;component/pages/usercurriculumpage.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\UserCurriculumPage.xaml"
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
            this.LetterrsStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            
            #line 20 "..\..\..\Pages\UserCurriculumPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AllTimesButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.YearsTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Pages\UserCurriculumPage.xaml"
            this.YearsTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.YearsTextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\Pages\UserCurriculumPage.xaml"
            this.YearsTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.YearsTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SpecialtysCombobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\Pages\UserCurriculumPage.xaml"
            this.SpecialtysCombobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SpecialtysCombobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CurrentUsersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

