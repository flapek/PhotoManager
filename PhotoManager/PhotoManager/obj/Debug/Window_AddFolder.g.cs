﻿#pragma checksum "..\..\Window_AddFolder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9B0E1AD7BC9793A6BD2905CE8F6516B64A746D21"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PhotoManager;
using PhotoManager.Workers;
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


namespace PhotoManager {
    
    
    /// <summary>
    /// Window_AddFolder
    /// </summary>
    public partial class Window_AddFolder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PhotoManager.Window_AddFolder Window;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TopPanel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMinimizeWindow;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCloseWindow;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFolderName;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxParentFolder;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox RichTextBoxFolderDescription;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSaveFolder;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\Window_AddFolder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancelAddingFolder;
        
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
            System.Uri resourceLocater = new System.Uri("/PhotoManager;component/window_addfolder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_AddFolder.xaml"
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
            this.Window = ((PhotoManager.Window_AddFolder)(target));
            
            #line 12 "..\..\Window_AddFolder.xaml"
            this.Window.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\Window_AddFolder.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TopPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ButtonMinimizeWindow = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\Window_AddFolder.xaml"
            this.ButtonMinimizeWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            
            #line 57 "..\..\Window_AddFolder.xaml"
            this.ButtonMinimizeWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonCloseWindow = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\Window_AddFolder.xaml"
            this.ButtonCloseWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            
            #line 63 "..\..\Window_AddFolder.xaml"
            this.ButtonCloseWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxFolderName = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\Window_AddFolder.xaml"
            this.TextBoxFolderName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxFolderName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ComboBoxParentFolder = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.RichTextBoxFolderDescription = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 8:
            this.ButtonSaveFolder = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\Window_AddFolder.xaml"
            this.ButtonSaveFolder.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ButtonSaveFolder_MouseDoubleClickAsync);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonCancelAddingFolder = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\Window_AddFolder.xaml"
            this.ButtonCancelAddingFolder.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCancelAddingFolder_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
