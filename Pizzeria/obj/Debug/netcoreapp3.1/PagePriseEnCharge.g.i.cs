﻿#pragma checksum "..\..\..\PagePriseEnCharge.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3186385B0E7EDBFE1E101C7EF34F757C58587EF2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Pizzeria;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Pizzeria {
    
    
    /// <summary>
    /// PagePriseEnCharge
    /// </summary>
    public partial class PagePriseEnCharge : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\PagePriseEnCharge.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas CanvasLivreur;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\PagePriseEnCharge.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas SelectLivreur;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\PagePriseEnCharge.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboxBoxLivreur;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\PagePriseEnCharge.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas SelectCommande;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\PagePriseEnCharge.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboxBoxIdCommande;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Pizzeria;component/pagepriseencharge.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PagePriseEnCharge.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CanvasLivreur = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.SelectLivreur = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.ComboxBoxLivreur = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\PagePriseEnCharge.xaml"
            this.ComboxBoxLivreur.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboxBoxLivreur_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\..\PagePriseEnCharge.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CommandePerdu);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SelectCommande = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.ComboxBoxIdCommande = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\PagePriseEnCharge.xaml"
            this.ComboxBoxIdCommande.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboxBoxIdCommande_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 27 "..\..\..\PagePriseEnCharge.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Valider);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

