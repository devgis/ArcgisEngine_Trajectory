// ���г��ٶȿ��� ---������
// 

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;

namespace demo
{
	/// <summary>
	/// Summary description for DynamicBikingSpeedCmd.
	/// </summary>
	[Guid("bbf77b3c-a5c1-4911-90ca-78961238fef0")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("DynamicBiking.DynamicBikingSpeedCmd")]
	public sealed class SpeedControlCmd : BaseCommand, IToolControl
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
		private DynamicBikingSpeedCtrl m_bikingSpeedCtrl = null;
        private DynamicDisplayCmd m_dynamicDisplayCmd = null;

		public SpeedControlCmd()
		{
			base.m_category = ".NET Samples";
			base.m_caption = "Dynamic Biking Speed";
			base.m_message = "Dynamic Biking Speed";
			base.m_toolTip = "Dynamic Biking Speed";
			base.m_name = "DynamicBiking_DynamicBikingSpeedCmd";

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

			//make sure that the usercontrol has been initialized
      if (null == m_bikingSpeedCtrl)
      {
        m_bikingSpeedCtrl = new DynamicBikingSpeedCtrl();
        m_bikingSpeedCtrl.CreateControl();
      }
		}

		/// <summary>
		/// Occurs when this command is clicked
		/// </summary>
		public override void OnClick()
		{
	
		}

		public override bool Enabled
		{
			get
			{
				m_dynamicDisplayCmd = GetDisplayModCmd();
				if (m_dynamicDisplayCmd != null)
				{
					bool bEnabled = m_dynamicDisplayCmd.IsPlaying;
					m_bikingSpeedCtrl.Enabled = bEnabled;
					m_bikingSpeedCtrl.SetDynamicBikingCmd(m_dynamicDisplayCmd);

					return bEnabled;
				}

				return false;
			}
		}

		#endregion

		#region IToolControl Members

		public bool OnDrop(esriCmdBarType barType)
		{
			return true;
		}

		public void OnFocus(ICompletionNotify complete)
		{
			
		}

		public int hWnd
		{
			get 
			{
				//pass the handle of the usercontrol
				if (null == m_bikingSpeedCtrl)
				{
					m_bikingSpeedCtrl = new DynamicBikingSpeedCtrl();
					m_bikingSpeedCtrl.CreateControl();
				}

				return m_bikingSpeedCtrl.Handle.ToInt32();
			}
		}

		#endregion

        private DynamicDisplayCmd GetDisplayModCmd()
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
