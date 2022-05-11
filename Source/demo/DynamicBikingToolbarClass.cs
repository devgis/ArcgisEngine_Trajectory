

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace demo
{
	/// <summary>
	/// Summary description for DynamicBikingToolbarClass.
	/// </summary>
	[Guid("b4be4aff-b374-4f26-8683-b7305a440c4a")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("DynamicBiking.DynamicBikingToolbarClass")]
	public sealed class DynamicBikingToolbarClass : BaseToolbar
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
			ControlsToolbars.Register(regKey);
		}
		/// <summary>
		/// Required method for ArcGIS Component Category unregistration -
		/// Do not modify the contents of this method with the code editor.
		/// </summary>
		private static void ArcGISCategoryUnregistration(Type registerType)
		{
			string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
			ControlsToolbars.Unregister(regKey);
		}

		#endregion
		#endregion

		public DynamicBikingToolbarClass()
		{
			AddItem("DynamicBiking.DynamicBikingCmd");
			AddItem("DynamicBiking.BikingTrackModeCmd");
			AddItem("DynamicBiking.DynamicBikingSpeedCmd");
		}

		public override string Caption
		{
			get
			{
				return "Dynamic biking";
			}
		}
		public override string Name
		{
			get
			{
				//TODO: Replace bar ID
				return "DynamicBikingToolbarClass";
			}
		}
	}
}