﻿#pragma checksum "..\..\SelectCharacters.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07CC39E835E41BCD01CAB7F7A39985BDDD4D00CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SentinelsAutoTrackerWPFFrontend;
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


namespace SentinelsAutoTrackerWPFFrontend {
    
    
    /// <summary>
    /// SelectCharacters
    /// </summary>
    public partial class SelectCharacters : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\SelectCharacters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbHeroList1;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\SelectCharacters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbHeroList2;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\SelectCharacters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbHeroList3;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\SelectCharacters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbHeroList4;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\SelectCharacters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbHeroList5;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\SelectCharacters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_SubmitErrorMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/SentinelsAutoTrackerWPFFrontend;component/selectcharacters.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectCharacters.xaml"
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
            this.cbHeroList1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cbHeroList2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.cbHeroList3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbHeroList4 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbHeroList5 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 76 "..\..\SelectCharacters.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Submit_ButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tb_SubmitErrorMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

