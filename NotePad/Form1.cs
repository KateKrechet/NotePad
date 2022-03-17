using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)//окно куда сохраняем
            richTextBox1.SaveFile(saveFileDialog1.FileName,RichTextBoxStreamType.PlainText);//возможность сохранить по выбранному адресу
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            openFileDialog.Filter = "Текст|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Сохранить файл?", "Вопросик",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == DialogResult.Yes)
                сохранитьToolStripMenuItem.PerformClick();
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)//окно куда сохраняем
                //    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);//возможность сохранить по выбранному адресу
        }

        private void изменитьЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {//дмалоговое окно создаем на форме
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = colorDialog1.Color;//изменение цвета всего текста
            //SelectionColor-выделенный фрагмент текста
        }

        private void изменитьШрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();//создание диалогового окна в методе
            if (fontDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fontDialog.Font;
        }
    }
}
