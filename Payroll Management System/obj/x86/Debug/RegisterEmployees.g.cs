﻿#pragma checksum "C:\Users\alira\source\repos\Payroll Management System\Payroll Management System\RegisterEmployees.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF0A4BAED36EF3DE7C4E5233B12214FAAEB75741E4041F21CFB93A2EB9981E87"
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
    partial class RegisterEmployees : 
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
        private class RegisterEmployees_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IRegisterEmployees_Bindings
        {
            private global::Payroll_Management_System.RegisterEmployees dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ComboBox obj5;
            private global::Windows.UI.Xaml.Controls.ComboBox obj6;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj5ItemsSourceDisabled = false;
            private static bool isobj6ItemsSourceDisabled = false;

            public RegisterEmployees_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 139 && columnNumber == 21)
                {
                    isobj5ItemsSourceDisabled = true;
                }
                else if (lineNumber == 150 && columnNumber == 21)
                {
                    isobj6ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 5: // RegisterEmployees.xaml line 132
                        this.obj5 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        break;
                    case 6: // RegisterEmployees.xaml line 143
                        this.obj6 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
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

            // IRegisterEmployees_Bindings

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
                    this.dataRoot = (global::Payroll_Management_System.RegisterEmployees)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Payroll_Management_System.RegisterEmployees obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_departs(obj.departs, phase);
                        this.Update_desigss(obj.desigss, phase);
                    }
                }
            }
            private void Update_departs(global::System.Collections.Generic.List<global::System.String> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // RegisterEmployees.xaml line 132
                    if (!isobj5ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj5, obj, null);
                    }
                }
            }
            private void Update_desigss(global::System.Collections.Generic.List<global::System.String> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // RegisterEmployees.xaml line 143
                    if (!isobj6ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj6, obj, null);
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
            case 2: // RegisterEmployees.xaml line 179
                {
                    this.RegisterToggleTeaching = (global::Microsoft.UI.Xaml.Controls.TeachingTip)(target);
                }
                break;
            case 3: // RegisterEmployees.xaml line 189
                {
                    this.FailToggleTeaching = (global::Microsoft.UI.Xaml.Controls.TeachingTip)(target);
                }
                break;
            case 4: // RegisterEmployees.xaml line 165
                {
                    this.registerEmployee = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.registerEmployee).Click += this.registerEmployee_Click;
                }
                break;
            case 5: // RegisterEmployees.xaml line 132
                {
                    this.empDepartments = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 6: // RegisterEmployees.xaml line 143
                {
                    this.empDesignation = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7: // RegisterEmployees.xaml line 154
                {
                    this.joiningDate = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                }
                break;
            case 8: // RegisterEmployees.xaml line 96
                {
                    this.houseNo = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // RegisterEmployees.xaml line 102
                {
                    this.street = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // RegisterEmployees.xaml line 108
                {
                    this.town = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // RegisterEmployees.xaml line 114
                {
                    this.city = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // RegisterEmployees.xaml line 61
                {
                    this.employeeEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // RegisterEmployees.xaml line 67
                {
                    this.employeeDOB = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                }
                break;
            case 14: // RegisterEmployees.xaml line 74
                {
                    this.gender = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 15: // RegisterEmployees.xaml line 36
                {
                    this.employeeName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // RegisterEmployees.xaml line 42
                {
                    this.employeeNIC = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 17: // RegisterEmployees.xaml line 49
                {
                    this.employeeContact = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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
            case 1: // RegisterEmployees.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    RegisterEmployees_obj1_Bindings bindings = new RegisterEmployees_obj1_Bindings();
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

