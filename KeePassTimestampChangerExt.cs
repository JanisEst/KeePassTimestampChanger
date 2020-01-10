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
			get { return "https://github.com/JanisEst/KeePassTimestampChanger/raw/master/keepass.version"; }
		}

		public override bool Initialize(IPluginHost host)
		{
			if (host == null) { return false; }

			//Debugger.Launch();
			
			GlobalWindowManager.WindowAdded += WindowAddedHandler;

			var m_ctxEntryMassModify = host.MainWindow.EntryContextMenu.Items.Find("m_ctxEntryEditQuick", false).FirstOrDefault() as ToolStripMenuItem;
			if (m_ctxEntryMassModify != null)
			{
				ctxItem = CreateToolStripItem(() =>
				{
					var entries = Program.MainForm.GetSelectedEntries();
					if (entries != null)
					{
						ShowModifyEntriesDialog(entries);
					}
				});

				var index = m_ctxEntryMassModify.DropDownItems.IndexOfKey("m_ctxEntryMassSetIcon") + 1;
				m_ctxEntryMassModify.DropDownItems.Insert(index, ctxItem);
			}

			return true;
		}

		public override void Terminate()
		{
			GlobalWindowManager.WindowAdded -= WindowAddedHandler;

			ctxItem.GetCurrentParent().Items.Remove(ctxItem);
			ctxItem.Dispose();
			ctxItem = null;
		}

		private void WindowAddedHandler(object sender, GwmWindowEventArgs e)
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

							ShowModifyEntriesDialog(Enumerable.Repeat(entry, 1));
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

		private static void ShowModifyEntriesDialog(IEnumerable<KeePassLib.PwEntry> entries)
		{
			if (entries.Any())
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

							Program.MainForm.UpdateUI(false, null, false, null, false, null, true);
						}
					}
				}
			}
		}
	}
}
