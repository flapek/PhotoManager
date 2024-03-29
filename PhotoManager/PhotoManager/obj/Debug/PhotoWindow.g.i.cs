﻿#pragma checksum "..\..\PhotoWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9A963E3679FD7399CCAEA1C61BE4C5A0054DF0C3"
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
    /// PhotoWindow
    /// </summary>
    public partial class PhotoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PhotoManager.PhotoWindow Window;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TopPanel;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMinimizeWindow;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMaximize;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCloseWindow;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxPhoto;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddPhoto;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDeletePhoto;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridInformaction;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPhotoName;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageHandler;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxParentFolder;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxTag;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddTag;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDeleteTag;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxCanEdit;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\PhotoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSaveChanges;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\PhotoWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/PhotoManager;component/photowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PhotoWindow.xaml"
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
            this.Window = ((PhotoManager.PhotoWindow)(target));
            
            #line 12 "..\..\PhotoWindow.xaml"
            this.Window.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\PhotoWindow.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.PhotoWindow_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TopPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ButtonMinimizeWindow = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\PhotoWindow.xaml"
            this.ButtonMinimizeWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            
            #line 58 "..\..\PhotoWindow.xaml"
            this.ButtonMinimizeWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonMaximize = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\PhotoWindow.xaml"
            this.ButtonMaximize.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMaximizeWindow_Click);
            
            #line default
            #line hidden
            
            #line 64 "..\..\PhotoWindow.xaml"
            this.ButtonMaximize.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMaximizeWindow_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonCloseWindow = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\PhotoWindow.xaml"
            this.ButtonCloseWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            
            #line 70 "..\..\PhotoWindow.xaml"
            this.ButtonCloseWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListBoxPhoto = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.ButtonAddPhoto = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\PhotoWindow.xaml"
            this.ButtonAddPhoto.Click += new System.Windows.RoutedEventHandler(this.ButtonAddPhoto_OnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonDeletePhoto = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\PhotoWindow.xaml"
            this.ButtonDeletePhoto.Click += new System.Windows.RoutedEventHandler(this.ButtonDeletePhoto_OnClickAsync);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GridInformaction = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.TextBoxPhotoName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.ImageHandler = ((System.Windows.Controls.Image)(target));
            return;
            case 12:
            this.ComboBoxParentFolder = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 13:
            this.ListBoxTag = ((System.Windows.Controls.ListBox)(target));
            return;
            case 14:
            this.ButtonAddTag = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.ButtonDeleteTag = ((System.Windows.Controls.Button)(target));
            return;
            case 16:
            this.CheckBoxCanEdit = ((System.Windows.Controls.CheckBox)(target));
            
            #line 193 "..\..\PhotoWindow.xaml"
            this.CheckBoxCanEdit.Checked += new System.Windows.RoutedEventHandler(this.CheckBoxCanEdit_OnChecked);
            
            #line default
            #line hidden
            
            #line 194 "..\..\PhotoWindow.xaml"
            this.CheckBoxCanEdit.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBoxCanEdit_OnUnchecked);
            
            #line default
            #line hidden
            return;
            case 17:
            this.ButtonSaveChanges = ((System.Windows.Controls.Button)(target));
            return;
            case 18:
            this.ButtonCancelChanges = ((System.Windows.Controls.Button)(target));
            
            #line 202 "..\..\PhotoWindow.xaml"
            this.ButtonCancelChanges.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelChanges_OnMouseClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

