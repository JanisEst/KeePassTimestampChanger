using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KeePass.Plugins;

namespace KeePassTimestampChanger
{
	public class KeePassTimestampChangerExt : Plugin
	{
		private ToolStripMenuItem ctxItem;

		public const string ShortProductName = "TimestampChanger";

		public override Image SmallIcon
		{
			get { return Properties.Resources.clock_16x16; }
		}

		public override string UpdateUrl
		{
			get { return "https://github.com/KN4CK3R/KeePassTimestampChanger/raw/master/keepass.version"; }
		}

		public override bool Initialize(IPluginHost host)
		{
			if (host == null) { return false; }

			//Debugger.Launch();

			var m_ctxEntryMassModify = host.MainWindow.EntryContextMenu.Items.Find("m_ctxEntryMassModify", false).FirstOrDefault() as ToolStripMenuItem;
			if (m_ctxEntryMassModify != null)
			{
				ctxItem = new ToolStripMenuItem
				{
					Text = "Set Timestamps...",
					Image = Properties.Resources.clock_16x16
				};
				ctxItem.Click += (sender, args) =>
				{
					var entries = host.MainWindow.GetSelectedEntries();
					if (entries != null && entries.Length != 0)
					{
						var firstEntry = entries.First();
						using (var met = new ModifyEntryTimestampsForm(firstEntry.CreationTime, firstEntry.LastModificationTime, firstEntry.LastAccessTime))
						{
							if (met.ShowDialog() == DialogResult.OK)
							{
								if (met.SetCreationTime || met.SetLastModificationTime || met.SetLastAccessTime)
								{
									foreach (var entry in entries)
									{
										if (met.SetCreationTime)
											entry.CreationTime = met.CreationTime;
										if (met.SetLastModificationTime)
											entry.LastModificationTime = met.LastModificationTime;
										if (met.SetLastAccessTime)
											entry.LastAccessTime = met.LastAccessTime;
									}

									host.MainWindow.UpdateUI(false, null, false, null, false, null, true);
								}
							}
						}
					}
				};

				var index = m_ctxEntryMassModify.DropDownItems.IndexOfKey("m_ctxEntryMassSetIcon") + 1;
				m_ctxEntryMassModify.DropDownItems.Insert(index, ctxItem);
			}

			return true;
		}

		public override void Terminate()
		{
			ctxItem.GetCurrentParent().Items.Remove(ctxItem);
			ctxItem.Dispose();
			ctxItem = null;
		}
	}
}
