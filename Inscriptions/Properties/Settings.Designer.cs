﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18052
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inscriptions.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("IXTAPA")]
        public string plantel {
            get {
                return ((string)(this["plantel"]));
            }
            set {
                this["plantel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("a470930b7e19172703769387b93c761e")]
        public string token {
            get {
                return ((string)(this["token"]));
            }
            set {
                this["token"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\\\Users\\\\ELEARNING\\\\Desktop\\\\extracciones\\\\")]
        public string outputpath {
            get {
                return ((string)(this["outputpath"]));
            }
            set {
                this["outputpath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ServerType=0;User=SYSDBA;Password=masterkey;Size=4096;Dialect=3;Pooling=FALSE;dat" +
            "abase=localhost:c:\\\\escolar\\\\DATOS.GDB")]
        public string FbConnectionstring {
            get {
                return ((string)(this["FbConnectionstring"]));
            }
            set {
                this["FbConnectionstring"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ServerType=0;User=SYSDBA;Password=masterkey;Size=4096;Dialect=3;Pooling=FALSE;dat" +
            "abase=localhost:C:\\\\Users\\\\ELEARNING\\\\Desktop\\\\extracciones\\\\TRACKING.GDB")]
        public string TrackingConnection {
            get {
                return ((string)(this["TrackingConnection"]));
            }
            set {
                this["TrackingConnection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("usuarios")]
        public string usertype {
            get {
                return ((string)(this["usertype"]));
            }
            set {
                this["usertype"] = value;
            }
        }
    }
}
