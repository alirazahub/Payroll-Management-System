﻿#pragma checksum "C:\Users\alira\source\repos\Payroll Management System\Payroll Management System\ChangingDesignation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0A44B99B87F936C99BB98AAD3EFA44A1FC35A7EA99DB5AD5275E4B7C5E1F9FC5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Payroll_Management_System
{
    partial class ChangingDesignation : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ChangingDesignation_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IChangingDesignation_Bindings
        {
            private global::Payroll_Management_System.ChangingDesignation dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj4;
            private global::Windows.UI.Xaml.Controls.ComboBox obj13;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj4ItemsSourceDisabled = false;
            private static bool isobj13ItemsSourceDisabled = false;

            public ChangingDesignation_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 198 && columnNumber == 17)
                {
                    isobj4ItemsSourceDisabled = true;
                }
                else if (lineNumber == 64 && columnNumber == 21)
                {
                    isobj13ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // ChangingDesignation.xaml line 190
                        this.obj4 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 13: // ChangingDesignation.xaml line 57
                        this.obj13 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IChangingDesignation_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Payroll_Management_System.ChangingDesignation)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Payroll_Management_System.ChangingDesignation obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_details(obj.details, phase);
                        this.Update_desigss(obj.desigss, phase);
                    }
                }
            }
            private void Update_details(global::System.Collections.Generic.List<global::Payroll_Management_System.PrevAndNewDetails> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ChangingDesignation.xaml line 190
                    if (!isobj4ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj4, obj, null);
                    }
                }
            }
            private void Update_desigss(global::System.Collections.Generic.List<global::System.String> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // ChangingDesignation.xaml line 57
                    if (!isobj13ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj13, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // ChangingDesignation.xaml line 14
                {
                    this.UpdateToggleTeaching = (global::Microsoft.UI.Xaml.Controls.TeachingTip)(target);
                }
                break;
            case 3: // ChangingDesignation.xaml line 25
                {
                    this.updateDesigContentDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 4: // ChangingDesignation.xaml line 190
                {
                    this.employeesDetails = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 6: // ChangingDesignation.xaml line 107
                {
                    this.empID1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // ChangingDesignation.xaml line 112
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.Button_Click_1;
                }
                break;
            case 8: // ChangingDesignation.xaml line 76
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.Button_Click3;
                }
                break;
            case 10: // ChangingDesignation.xaml line 43
                {
                    this.empName1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // ChangingDesignation.xaml line 48
                {
                    this.empNIC1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // ChangingDesignation.xaml line 53
                {
                    this.currentDesignation = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // ChangingDesignation.xaml line 57
                {
                    this.empDesignation = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // ChangingDesignation.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ChangingDesignation_obj1_Bindings bindings = new ChangingDesignation_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
