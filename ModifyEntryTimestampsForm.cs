using System;
using System.Windows.Forms;
using KeePass.App;
using KeePass.UI;
using KeePassLib.Utility;

namespace KeePassTimestampChanger
{
	public partial class ModifyEntryTimestampsForm : Form
	{
		private readonly ExpiryControlGroup creationTimeControlGroup;
		private readonly ExpiryControlGroup lastModificationTimeControlGroup;
		private readonly ExpiryControlGroup lastAccessTimeControlGroup;

		public bool SetCreationTime { get { return createdCheckBox.Checked; } }
		public DateTime CreationTime { get { return TimeUtil.ToUtc(createdDateTimePicker.Value, false); } }
		public bool SetLastModificationTime { get { return lastModifiedCheckBox.Checked; } }
		public DateTime LastModificationTime { get { return TimeUtil.ToUtc(lastModifiedDateTimePicker.Value, false); } }
		public bool SetLastAccessTime { get { return lastAccessedCheckBox.Checked; } }
		public DateTime LastAccessTime { get { return TimeUtil.ToUtc(lastAccessedDateTimePicker.Value, false); } }

		public ModifyEntryTimestampsForm(DateTime creationTime, DateTime lastModificationTime, DateTime lastAccessTime)
		{
			InitializeComponent();

			Icon = AppIcons.Default;

			BannerFactory.CreateBannerEx(this, bannerImage, Properties.Resources.clock_48x48, "Timestamps", "Modify the entry timestamps.");

			createdDateTimePicker.Value = TimeUtil.ToLocal(creationTime, true);
			lastModifiedDateTimePicker.Value = TimeUtil.ToLocal(lastModificationTime, true);
			lastAccessedDateTimePicker.Value = TimeUtil.ToLocal(lastAccessTime, true);

			creationTimeControlGroup = new ExpiryControlGroup();
			creationTimeControlGroup.Attach(createdCheckBox, createdDateTimePicker);
			lastModificationTimeControlGroup = new ExpiryControlGroup();
			lastModificationTimeControlGroup.Attach(lastModifiedCheckBox, lastModifiedDateTimePicker);
			lastAccessTimeControlGroup = new ExpiryControlGroup();
			lastAccessTimeControlGroup.Attach(lastAccessedCheckBox, lastAccessedDateTimePicker);
		}

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			creationTimeControlGroup.Release();
			lastModificationTimeControlGroup.Release();
			lastAccessTimeControlGroup.Release();
		}
	}
}
