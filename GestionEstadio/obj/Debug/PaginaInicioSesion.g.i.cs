﻿#pragma checksum "..\..\PaginaInicioSesion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A304EC4AEADD5435D521BFA8E625085FEFA033B8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using GestionEstadio;
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


namespace GestionEstadio {
    
    
    /// <summary>
    /// PaginaInicioSesion
    /// </summary>
    public partial class PaginaInicioSesion : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\PaginaInicioSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsuario;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\PaginaInicioSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelUsuario;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PaginaInicioSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelContraseña;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\PaginaInicioSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTitulo;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\PaginaInicioSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistrar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\PaginaInicioSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEntrar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\PaginaInicioSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbContraseña;
        
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
            System.Uri resourceLocater = new System.Uri("/GestionEstadio;component/paginainiciosesion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PaginaInicioSesion.xaml"
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
            this.txtUsuario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.labelUsuario = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.labelContraseña = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.labelTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.btnRegistrar = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\PaginaInicioSesion.xaml"
            this.btnRegistrar.Click += new System.Windows.RoutedEventHandler(this.btnRegistrar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEntrar = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\PaginaInicioSesion.xaml"
            this.btnEntrar.Click += new System.Windows.RoutedEventHandler(this.BtnEntrar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.pbContraseña = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

