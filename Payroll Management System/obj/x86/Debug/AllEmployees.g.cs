﻿#pragma checksum "C:\Users\alira\source\repos\Payroll Management System\Payroll Management System\AllEmployees.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "218E1E9329B4700C38EA9C2DD341B5779109820560C1614745D49083732CEDD8"
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
    partial class AllEmployees : 
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
        private class AllEmployees_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IAllEmployees_Bindings
        {
            private global::Payroll_Management_System.AllEmployees dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj18;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj18ItemsSourceDisabled = false;

            public AllEmployees_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 164 && columnNumber == 17)
                {
                    isobj18ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 18: // AllEmployees.xaml line 160
                        this.obj18 = (global::Windows.UI.Xaml.Controls.ListView)target;
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

            // IAllEmployees_Bindings

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
                    this.dataRoot = (global::Payroll_Management_System.AllEmployees)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Payroll_Management_System.AllEmployees obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_employees(obj.employees, phase);
                    }
                }
            }
            private void Update_employees(global::System.Collections.Generic.List<global::Payroll_Management_System.ReadingEmployees> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // AllEmployees.xaml line 160
                    if (!isobj18ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj18, obj, null);
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
            case 2: // AllEmployees.xaml line 12
                {
                    this.termsOfUseContentDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 3: // AllEmployees.xaml line 226
                {
                    this.editEmployeeDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 5: // AllEmployees.xaml line 288
                {
                    this.gender = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // AllEmployees.xaml line 282
                {
                    this.employeeDepartment = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // AllEmployees.xaml line 284
                {
                    this.employeeDesignation = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // AllEmployees.xaml line 276
                {
                    this.town = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // AllEmployees.xaml line 278
                {
                    this.city = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // AllEmployees.xaml line 270
                {
                    this.houseNo = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // AllEmployees.xaml line 272
                {
                    this.street = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // AllEmployees.xaml line 263
                {
                    this.employeeEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // AllEmployees.xaml line 265
                {
                    this.employeeDOB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // AllEmployees.xaml line 257
                {
                    this.employeeNIC = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // AllEmployees.xaml line 259
                {
                    this.employeeContact = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // AllEmployees.xaml line 248
                {
                    this.employeeID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 17: // AllEmployees.xaml line 253
                {
                    this.employeeName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 20: // AllEmployees.xaml line 59
                {
                    global::Windows.UI.Xaml.Controls.Button element20 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element20).Click += this.Button_Click;
                }
                break;
            case 21: // AllEmployees.xaml line 85
                {
                    this.sortBy = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 22: // AllEmployees.xaml line 73
                {
                    global::Windows.UI.Xaml.Controls.Button element22 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element22).Click += this.Button_Click_1;
                }
                break;
            case 24: // AllEmployees.xaml line 33
                {
                    this.empIDToEdit = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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
            case 1: // AllEmployees.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    AllEmployees_obj1_Bindings bindings = new AllEmployees_obj1_Bindings();
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

