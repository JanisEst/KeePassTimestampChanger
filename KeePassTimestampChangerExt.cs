using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KeePass;
using KeePass.Forms;
using KeePass.Plugins;
using KeePass.UI;
using KeePassLib;

namespace KeePassTimestampChanger
{
	public class KeePassTimestampChangerExt : Plugin
	{
		public const string ShortProductName = "TimestampChanger";

		public override Image SmallIcon
		{
			get { return Properties.Resources.clock_16x16; }
		}

		public override string UpdateUrl
		{
			get { return "https://github.com/JanisEst/KeePassTimestampChanger/raw/master/keepass.version"; }
		}

		public override bool Initialize(IPluginHost host)
		{
			if (host == null) { return false; }

			//Debugger.Launch();
			
			GlobalWindowManager.WindowAdded += WindowAddedHandler;

			return true;
		}

		public override void Terminate()
		{
			GlobalWindowManager.WindowAdded -= WindowAddedHandler;
		}

		public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
		{
			if (t == PluginMenuType.Entry)
			{
				return CreateToolStripItem(() =>
				{
					var entries = Program.MainForm.GetSelectedEntries();
					if (entries != null)
					{
						ShowModifyEntriesDialog(entries);
					}
				});
			}
			return null;
		}

		private static void WindowAddedHandler(object sender, GwmWindowEventArgs e)
		{
			var entryForm = e.Form as PwEntryForm;
			if (entryForm != null)
			{
				entryForm.Shown += (sender2, e2) =>
				{
					var m_lvHistory = entryForm.Controls.Find("m_lvHistory", true).FirstOrDefault() as CustomListViewEx;
					if (m_lvHistory != null)
					{
						if (m_lvHistory.ContextMenuStrip == null)
						{
							m_lvHistory.ContextMenuStrip = new ContextMenuStrip();
						}

						m_lvHistory.ContextMenuStrip.Opening += (o, args) => args.Cancel = m_lvHistory.SelectedIndices.Count != 1;
						m_lvHistory.ContextMenuStrip.Items.Add(CreateToolStripItem(() =>
						{
							var indices = m_lvHistory.SelectedIndices;
							if (indices.Count != 1)
							{
								Debug.Assert(false);
								return;
							}

							var entry = entryForm.EntryRef.History.GetAt((uint)indices[0]);

							ShowModifyEntriesDialog(new PwEntry[] { entry });
						}));
					}
				};
			}
		}

		private static ToolStripMenuItem CreateToolStripItem(Action onClick)
		{
			var item = new ToolStripMenuItem
			{
				Text = "Set Timestamps...",
				Image = Properties.Resources.clock_16x16
			};
			item.Click += (sender, args) => onClick();
			return item;
		}

		private static void ShowModifyEntriesDialog(ICollection<PwEntry> entries)
		{
			var firstEntry = entries.FirstOrDefault();
			if (firstEntry == null)
			{
				return;
			}

			using (var met = new ModifyEntryTimestampsForm(firstEntry.CreationTime, firstEntry.LastModificationTime, firstEntry.LastAccessTime))
			{
				if (met.ShowDialog() != DialogResult.OK)
				{
					return;
				}

				if (!met.SetCreationTime && !met.SetLastModificationTime && !met.SetLastAccessTime)
				{
					return;
				}

				foreach (var entry in entries)
				{
					if (met.SetCreationTime)
						entry.CreationTime = met.CreationTime;
					if (met.SetLastModificationTime)
						entry.LastModificationTime = met.LastModificationTime;
					if (met.SetLastAccessTime)
						entry.LastAccessTime = met.LastAccessTime;
				}

				Program.MainForm.UpdateUI(false, null, false, null, false, null, true);
			}
		}
	}
}
