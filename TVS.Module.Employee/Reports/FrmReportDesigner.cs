﻿using System;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using TVS.Module.Employee;
using TVS.Module.Employee.Reports.Commande;

namespace TVS.Module.Employee.Reports
{
    public partial class FrmReportDesigner : Form
    {
        public FrmReportDesigner(CompositionContainer container)
        {
            InitializeComponent();

            reportDesigner1.DesignPanelLoaded += NewDesignPanelLoaded;
            XtraReport.FilterComponentProperties += FilterComponentProperties;
            reportDesigner1.AddCommandHandler(new NewCommandHandler(reportDesigner1, container));
            reportDesigner1.AddCommandHandler(new OpenCommandHandler(reportDesigner1, container));
        }

        private void NewDesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            var panel = sender as XRDesignPanel;
            if (panel == null) return;

            reportDesigner1.AddCommandHandler(new SaveCommandHandler(panel));
        }

        private static void FilterComponentProperties(object sender, FilterComponentPropertiesEventArgs e)
        {
            // The following code hides some properties for a specific report element.
            if (!(sender is XtraReport && e.Component is XtraReport)) return;
            //HideProperty("Tag", e);
        }

        private static void HideProperty(String propertyName, FilterComponentPropertiesEventArgs e)
        {
            var oldPropertyDescriptor = e.Properties[propertyName] as PropertyDescriptor;
            if (oldPropertyDescriptor != null)
            {
                // Substitute the current property descriptor
                // with a custom one with the BrowsableAttribute.No attribute.
                e.Properties[propertyName] = TypeDescriptor.CreateProperty(
                    oldPropertyDescriptor.ComponentType,
                    oldPropertyDescriptor,
                    BrowsableAttribute.No);
            }
            else
            {
                // If the property descriptor can not be substituted,
                // remove it from the Properties collection.
                e.Properties.Remove(propertyName);
            }
        }
    }
}