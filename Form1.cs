using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace myMemo
{
    public partial class frm_memo : Form
    {
        private string FileName = "無題";
        public frm_memo()
        {
            InitializeComponent();
        }


        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "テキストファイル (*.txt)|*.txt|C# ソース(*.cs)|*.cs|JavaScriptON(*.json)|*.json|全てのファイル (*.*)|*.*";
            dialog.Title = "開く";
            if (dialog.ShowDialog() == DialogResult.OK)
                txt_memo.Text = File.ReadAllText(dialog.FileName);
            Text = Path.GetFileName(dialog.FileName) + "- MEMO";
            FileName = dialog.FileName;

            上書き保存ToolStripMenuItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "テキストファイル(*.txt) | *.txt | C# ソース(*.cs)|*.cs|全てのファイル (*.*)|*.*";
            dialog.Title = "保存";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, txt_memo.Text);
            }
            上書き保存ToolStripMenuItem.Enabled = true;
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("メモ帳を終了します", "終了", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FileName, txt_memo.Text,Encoding.GetEncoding("Shift_JIS"));

        }

        private void コピーCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_memo.SelectedText != "")
                txt_memo.Copy();
        }

        private void 貼り付けVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                txt_memo.Paste();
        }

        private void 元に戻すUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_memo.CanUndo)
            {
                txt_memo.Undo();
                txt_memo.ClearUndo();
            }

        }

        private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("新たにファイルを作成します", "新規作成", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                txt_memo.Text = "";
                Text = "無題 - MEMO";
                上書き保存ToolStripMenuItem.Enabled = false;
            }
        }

        private void SaveFile(string value)
        {
            System.IO.File.WriteAllText(value, txt_memo.Text,
              Encoding.GetEncoding("Shift_JIS"));
            // ファイル名を保持する
            this.FileName = value;
            // ファイル名が判明したため「上書き保存」を有効にする
            上書き保存ToolStripMenuItem.Enabled = true;
        }

        private void 切り取りToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_memo.SelectedText != "") txt_memo.Cut();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
