﻿#pragma checksum "..\..\FolderWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "297680995A37856CB4CD8DEA960D0A13023CE455"
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
    /// FolderWindow
    /// </summary>
    public partial class FolderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PhotoManager.FolderWindow Window;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TopPanel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMinimizeWindow;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCloseWindow;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView FolderView;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonRefresh;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddFolder;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDeleteFolder;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFolderName;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxParentFolder;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox RichTextBoxFolderDescription;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxCanEdit;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSaveChanges;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\FolderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancelChanges;
        
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
            System.Uri resourceLocater = new System.Uri("/PhotoManager;component/folderwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FolderWindow.xaml"
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
            this.Window = ((PhotoManager.FolderWindow)(target));
            
            #line 12 "..\..\FolderWindow.xaml"
            this.Window.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\FolderWindow.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TopPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ButtonMinimizeWindow = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\FolderWindow.xaml"
            this.ButtonMinimizeWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            
            #line 57 "..\..\FolderWindow.xaml"
            this.ButtonMinimizeWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonCloseWindow = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\FolderWindow.xaml"
            this.ButtonCloseWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            
            #line 63 "..\..\FolderWindow.xaml"
            this.ButtonCloseWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FolderView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 6:
            this.ButtonRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\FolderWindow.xaml"
            this.ButtonRefresh.Click += new System.Windows.RoutedEventHandler(this.ButtonRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonAddFolder = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\FolderWindow.xaml"
            this.ButtonAddFolder.Click += new System.Windows.RoutedEventHandler(this.ButtonAddFolder_MouseClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonDeleteFolder = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\FolderWindow.xaml"
            this.ButtonDeleteFolder.Click += new System.Windows.RoutedEventHandler(this.ButtonDeleteFolder_MouseClickAsync);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TextBoxFolderName = ((System.Windows.Controls.TextBox)(target));
            
            #line 131 "..\..\FolderWindow.xaml"
            this.TextBoxFolderName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxFolderName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ComboBoxParentFolder = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.RichTextBoxFolderDescription = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 141 "..\..\FolderWindow.xaml"
            this.RichTextBoxFolderDescription.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.RichTextBoxFolderDescription_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CheckBoxCanEdit = ((System.Windows.Controls.CheckBox)(target));
            
            #line 153 "..\..\FolderWindow.xaml"
            this.CheckBoxCanEdit.Checked += new System.Windows.RoutedEventHandler(this.CheckBoxCanEdit_Checked);
            
            #line default
            #line hidden
            
            #line 154 "..\..\FolderWindow.xaml"
            this.CheckBoxCanEdit.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBoxCanEdit_Unchecked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ButtonSaveChanges = ((System.Windows.Controls.Button)(target));
            return;
            case 14:
            this.ButtonCancelChanges = ((System.Windows.Controls.Button)(target));
            
            #line 162 "..\..\FolderWindow.xaml"
            this.ButtonCancelChanges.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelChanges_MouseClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

