using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificateUpdator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddContextMenu();
            AddExcelHeadersToContextMenu();
        }

        /// <summary>
        /// Read headers from excel and add to context menu
        /// </summary>
        private void AddExcelHeadersToContextMenu()
        {
            excelContextMenu.Items.Add("Name");
            excelContextMenu.Items.Add("Phone Number");
            excelContextMenu.Items.Add("Image");

        }

        /// <summary>
        /// Add controls to context menu
        /// </summary>
        private void AddContextMenu()
        {
            ToolStripMenuItem Item = new ToolStripMenuItem("Text Box", Image.FromFile(@"..\..\images\text-box.png"));
            Item.Click += TextBoxClicked;
            ctrlContextMenu.Items.Add(Item);

            Item = new ToolStripMenuItem("Image", Image.FromFile(@"..\..\images\text-box.png"));
            Item.Click += ImageClicked;
            ctrlContextMenu.Items.Add(Item);
        }


        /// <summary>
        /// Context menu image is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageClicked(object sender, EventArgs e)
        {
            PictureBox picBx = new PictureBox();
            picBx.BackColor = System.Drawing.SystemColors.ControlDark;
            ControlExtension.Draggable(picBx,true);
            pnlBackground.Controls.Add(picBx);
            AddExcelContextMenu(picBx);
        }

        /// <summary>
        /// Context menu Text box is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxClicked(object sender, EventArgs e)
        {
            TextBox txtBx = new TextBox();
            ControlExtension.Draggable(txtBx, true);
            pnlBackground.Controls.Add(txtBx);
            AddExcelContextMenu(txtBx);

        }

        /// <summary>
        /// Add background Image to panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackground_Click(object sender, EventArgs e)
        {
            DialogResult result =  openFile.ShowDialog();
            if(result == DialogResult.OK)
            {
                pnlBackground.BackgroundImageLayout = ImageLayout.Zoom;
                pnlBackground.BackgroundImage = Image.FromFile(openFile.FileName);
            }
        }

        /// <summary>
        /// Add context menu to controls
        /// </summary>
        /// <param name="ctrl"></param>
        private void AddExcelContextMenu(Control ctrl)
        {
            ctrl.ContextMenuStrip = excelContextMenu;
        }
    }
}
