//-改变自行车行车速度-----工具条窗体设计
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace demo
{
	public partial class DynamicBikingSpeedCtrl : UserControl
	{
		private DynamicDisplayCmd m_dynamicDisplayCmd = null;
		
		public DynamicBikingSpeedCtrl()
		{
			InitializeComponent();
		}

        public void SetDynamicBikingCmd(DynamicDisplayCmd dynamicDisplayCmd)
		{
			m_dynamicDisplayCmd = dynamicDisplayCmd; 
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			if (m_dynamicDisplayCmd != null)
			{
                m_dynamicDisplayCmd.PlaybackSpeed = trackBar1.Value;
				toolTip1.ToolTipTitle = Convert.ToString(trackBar1.Value);
			}
		}
	}
}
