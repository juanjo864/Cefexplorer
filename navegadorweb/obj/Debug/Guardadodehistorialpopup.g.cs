﻿#pragma checksum "..\..\Guardadodehistorialpopup.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D0D4E47F7F9545CD028503BA29947D1A9462C4FFB2FB798E52087CA1974A773F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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
using navegadorweb;


namespace navegadorweb {
    
    
    /// <summary>
    /// Guardadodehistorialpopup
    /// </summary>
    public partial class Guardadodehistorialpopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Guardadodehistorialpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button guardados;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Guardadodehistorialpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cerrado;
        
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
            System.Uri resourceLocater = new System.Uri("/navegadorweb;component/guardadodehistorialpopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Guardadodehistorialpopup.xaml"
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
            this.guardados = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\Guardadodehistorialpopup.xaml"
            this.guardados.Click += new System.Windows.RoutedEventHandler(this.guardadohistorial);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cerrado = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Guardadodehistorialpopup.xaml"
            this.cerrado.Click += new System.Windows.RoutedEventHandler(this.guardadohistorial);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

