﻿#pragma checksum "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9CEE753C123F3D00CF28F98EE2799B24E90C14600378D1B74751060DCBDA9496"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Diplom.Components.MotherBoard;
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


namespace Diplom.Components.MotherBoard {
    
    
    /// <summary>
    /// MotherBoardWindow
    /// </summary>
    public partial class MotherBoardWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 18 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LvMotherBoard;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddMotherBoard;
        
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
            System.Uri resourceLocater = new System.Uri("/Diplom;component/components/motherboard/motherboardwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
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
            this.LvMotherBoard = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.BtnAddMotherBoard = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
            this.BtnAddMotherBoard.Click += new System.Windows.RoutedEventHandler(this.BtnAddMotherBoard_Click);
            
            #line default
            #line hidden
            
            #line 137 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
            this.BtnAddMotherBoard.Loaded += new System.Windows.RoutedEventHandler(this.AdminCheck_loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 84 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AdminCheck_loaded);
            
            #line default
            #line hidden
            
            #line 85 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEditMotherBoard_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 97 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AdminCheck_loaded);
            
            #line default
            #line hidden
            
            #line 98 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDelMotherBoard_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 111 "..\..\..\..\Components\MotherBoard\MotherBoardWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

