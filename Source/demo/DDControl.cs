
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace demo
{
    /// <summary>
    /// Summary description for DDControl.
    /// </summary>
    [Guid("8b116ad4-f30e-4397-8791-297f00624d27")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("HaborManagement.DDControl")]
    public sealed class DDControl : BaseCommand
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper;

        public DDControl()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "HaborManagements"; //localizable text
            base.m_caption = "OFF";  //localizable text
            base.m_message = "Enable or Disable Dynamic Display";  //localizable text 
            base.m_toolTip = "Enable or Disable Dynamic Display";  //localizable text 
            base.m_name = "HaborManagements_EDDynamicDisplay";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;

     
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // turn on and off Dynamic Display
            // cast the dynamic map from the focus map.
            IDynamicMap dynamicMap = m_hookHelper.FocusMap as IDynamicMap;
            // make sure to switch into dynamic mode.
            if (!dynamicMap.DynamicMapEnabled)
            {
                dynamicMap.DynamicMapEnabled = true;
                // set the DynamicDrawRate to 15 milliseconds.  It just makes it look better for this application.
                //这里调节这里的参数可以保证到地图的刷新，根据不同的情况可以自定义设置
                dynamicMap.DynamicDrawRate = 20;
                m_caption = "ON";
            }
            else

            {
                dynamicMap.DynamicMapEnabled = false;
                m_caption = "OFF";
            }
        }

        #endregion
    }
}
