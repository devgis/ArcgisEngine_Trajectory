// ���г��켣��ʾģʽ---������
// 

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace demo
{
	/// <summary>
	/// Summary description for BikingTrackModeCmd.
	/// </summary>
	[Guid("5a26e262-9e4c-498f-b77c-a6fdeee0dd4b")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("DynamicBiking.BikingTrackModeCmd")]
	public sealed class VehicleTrackModeCmd : BaseCommand
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

		private IHookHelper m_hookHelper = null;

		private DynamicDisplayCmd m_dynamicDisplayCmd = null;

		public VehicleTrackModeCmd()
		{
            base.m_category = "HaborManagements";
			base.m_caption = "Dynamic Vehicle track Mode";
            base.m_message = "Dynamic Vehicle track mode";
            base.m_toolTip = "Dynamic Vehicle track mode";
            base.m_name = "Dynamic Vehicle track mod";

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
			if (m_dynamicDisplayCmd != null)
			{
				m_dynamicDisplayCmd.TrackMode = !m_dynamicDisplayCmd.TrackMode;
			}
		}

		public override bool Enabled
		{
			get
			{
				m_dynamicDisplayCmd = GetBikingCmd();
				if (m_dynamicDisplayCmd != null)
					return m_dynamicDisplayCmd.IsPlaying;

				return false;
			}
		}

		public override bool Checked
		{
			get
			{
				if (m_dynamicDisplayCmd != null)
				{
					return m_dynamicDisplayCmd.TrackMode;
				}
				return false;
			}
		}

		#endregion

        private DynamicDisplayCmd GetBikingCmd()
		{
			if (m_hookHelper.Hook == null)
				return null;

			DynamicDisplayCmd dynamicBikingCmd = null;
			if (m_hookHelper.Hook is IToolbarControl2)
			{
				IToolbarControl2 toolbarCtrl = (IToolbarControl2)m_hookHelper.Hook;
				ICommandPool2 commandPool = toolbarCtrl.CommandPool as ICommandPool2;
				int commantCount = commandPool.Count;
				ICommand command = null;
				for (int i = 0; i < commantCount; i++)
				{
					command = commandPool.get_Command(i);
					if (command is DynamicDisplayCmd)
					{
						dynamicBikingCmd = (DynamicDisplayCmd)command;
					}
				}
			}

			return dynamicBikingCmd;
		}
	}
}
