﻿#pragma checksum "C:\Users\alira\source\repos\Payroll Management System\Payroll Management System\HomePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4DDA39FA40E47D935D177874D73DBFD6E8B6271D8C50343DE82E82BA2903CC23"
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
    partial class HomePage : 
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
        private class HomePage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IHomePage_Bindings
        {
            private global::Payroll_Management_System.HomePage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj2;
            private global::Windows.UI.Xaml.Controls.ListView obj4;
            private global::Windows.UI.Xaml.Controls.ListView obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;
            private static bool isobj4ItemsSourceDisabled = false;
            private static bool isobj7ItemsSourceDisabled = false;

            public HomePage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 362 && columnNumber == 29)
                {
                    isobj2ItemsSourceDisabled = true;
                }
                else if (lineNumber == 262 && columnNumber == 29)
                {
                    isobj4ItemsSourceDisabled = true;
                }
                else if (lineNumber == 150 && columnNumber == 29)
                {
                    isobj7ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // HomePage.xaml line 355
                        this.obj2 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 4: // HomePage.xaml line 255
                        this.obj4 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 7: // HomePage.xaml line 141
                        this.obj7 = (global::Windows.UI.Xaml.Controls.ListView)target;
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

            // IHomePage_Bindings

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
                    this.dataRoot = (global::Payroll_Management_System.HomePage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Payroll_Management_System.HomePage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_todo(obj.todo, phase);
                        this.Update_directors(obj.directors, phase);
                        this.Update_empByDeparts(obj.empByDeparts, phase);
                    }
                }
            }
            private void Update_todo(global::System.Collections.Generic.List<global::Payroll_Management_System.ToDoList> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // HomePage.xaml line 355
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
            private void Update_directors(global::System.Collections.Generic.List<global::Payroll_Management_System.ReadingEmployees> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // HomePage.xaml line 255
                    if (!isobj4ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj4, obj, null);
                    }
                }
            }
            private void Update_empByDeparts(global::System.Collections.Generic.List<global::Payroll_Management_System.ReadingEmployees> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // HomePage.xaml line 141
                    if (!isobj7ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj7, obj, null);
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
            case 6: // HomePage.xaml line 80
                {
                    this.empDepart = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.empDepart).SelectionChanged += this.empDepart_SelectionChanged;
                }
                break;
            case 7: // HomePage.xaml line 141
                {
                    this.empByDepart = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 9: // HomePage.xaml line 27
                {
                    this.displayName = (global::Windows.UI.Xaml.Controls.PersonPicture)(target);
                }
                break;
            case 10: // HomePage.xaml line 57
                {
                    this.Userusername = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // HomePage.xaml line 49
                {
                    this.UserEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // HomePage.xaml line 33
                {
                    this.UserName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            case 1: // HomePage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    HomePage_obj1_Bindings bindings = new HomePage_obj1_Bindings();
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

