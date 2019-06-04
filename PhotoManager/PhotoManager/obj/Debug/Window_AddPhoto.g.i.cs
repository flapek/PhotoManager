﻿#pragma checksum "..\..\Window_AddPhoto.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EC94F44D06194CBD5FBCB604B93194EB4A59740A"
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
    /// Window_AddPhoto
    /// </summary>
    public partial class Window_AddPhoto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PhotoManager.Window_AddPhoto Window;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TopPanel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMinimizeWindow;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCloseWindow;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPathToPhoto;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBrowser;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPhotoName;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox RichTextBoxPhotoDescription;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelPhotoContainer;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSavePhoto;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Window_AddPhoto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/PhotoManager;component/window_addphoto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_AddPhoto.xaml"
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
            this.Window = ((PhotoManager.Window_AddPhoto)(target));
            
            #line 12 "..\..\Window_AddPhoto.xaml"
            this.Window.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\Window_AddPhoto.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TopPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ButtonMinimizeWindow = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\Window_AddPhoto.xaml"
            this.ButtonMinimizeWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            
            #line 57 "..\..\Window_AddPhoto.xaml"
            this.ButtonMinimizeWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimizeWindow_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonCloseWindow = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\Window_AddPhoto.xaml"
            this.ButtonCloseWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            
            #line 63 "..\..\Window_AddPhoto.xaml"
            this.ButtonCloseWindow.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonCloseWindow_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxPathToPhoto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonBrowser = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\Window_AddPhoto.xaml"
            this.ButtonBrowser.Click += new System.Windows.RoutedEventHandler(this.ButtonBrowser_OnClickAsync);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBoxPhotoName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.RichTextBoxPhotoDescription = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 9:
            this.StackPanelPhotoContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.ButtonSavePhoto = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\Window_AddPhoto.xaml"
            this.ButtonSavePhoto.Click += new System.Windows.RoutedEventHandler(this.ButtonSavePhoto_OnClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ButtonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\Window_AddPhoto.xaml"
            this.ButtonCancel.Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_OnMouseClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

