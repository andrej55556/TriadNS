using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TriadPad.Forms
    {
    /// <summary>
    /// ����������� ���� ������� �����
    /// </summary>
    partial class FormMain
        {
        /// <summary>
        /// �������� ������� �����
        /// </summary>
        private const string MainFormText = "������� Triad.NET";
        /// <summary>
        /// �������� ������ �����
        /// </summary>
        private const string NewFileName = "�����.txt";


        //���� - ����� ����
        private void tsmiNewFile_Click( object sender, EventArgs e )
            {
            CreateNewFile();
            }
        

        //���� - ������� ����
        private void tsmiOpenFile_Click( object sender, EventArgs e )
            {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                {
                OpenFile( this.openFileDialog.FileName );
                }
            }        


        //���� - �����
        private void tsmiExit_Click( object sender, EventArgs e )
            {
            this.Close();
            }


        //���� - ���������
        private void tsmiSave_Click( object sender, EventArgs e )
            {
            if ( currFileName != NewFileName )
                {
                this.rtbText.SaveFile( currFileName, RichTextBoxStreamType.PlainText );
                }
            //����� - ��������� ���...
            else
                {
                tsmiSaveAs_Click( this, new EventArgs() );
                }
            }


        //���� - ��������� ���
        private void tsmiSaveAs_Click( object sender, EventArgs e )
            {
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
                {
                SaveFileAs( this.saveFileDialog.FileName );
                }
            }


        //���� - �������������
        private void tsmiTranslate_Click( object sender, EventArgs e )
            {
            Translate();
            }


        //���� - �������������
        private void tsmiCompile_Click( object sender, EventArgs e )
            {
            Compile();
            }


        //���� - ������������� � ���������
        private void tsmiCompileAndRun_Click( object sender, EventArgs e )
            {
            CompileAndRun();
            }


        //���� - ���������
        private void tsmiRun_Click( object sender, EventArgs e )
            {
            RunProgram();
            }


        //���� - � ���������
        private void tsmiAbout_Click( object sender, EventArgs e )
            {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
            }


        //���� - ����� ����������
        private void tsmiOptions_Click( object sender, EventArgs e )
            {
            FormOptions formOptions = new FormOptions();
            formOptions.ShowDialog();
            }


        //���� - �������
        private void tsmiGoTo_Click( object sender, EventArgs e )
            {
            FormGoTo.Instance.Go( this.rtbText );
            }


        //���� - �����
        private void tsmiFind_Click( object sender, EventArgs e )
            {
            FormFind.Instance.Find( this.rtbText );
            }


        //���� - ����� � ��������
        private void tsmiReplace_Click( object sender, EventArgs e )
            {
            FormReplace.Instance.Replace( this.rtbText );
            }


        //���� - ��������
        private void tsmiCut_Click( object sender, EventArgs e )
            {
            this.rtbText.Cut();
            }


        //���� - ����������
        private void tsmiCopy_Click( object sender, EventArgs e )
            {
            if ( this.rtbText.Focused )
                this.rtbText.Copy();
            else if ( this.rtbCode.Focused )
                this.rtbCode.Copy();
            }


        //���� - ��������
        private void tsmiPaste_Click( object sender, EventArgs e )
            {
            this.rtbText.Paste();
            }


        //���� - �������� ���
        private void tsmiSelectAll_Click( object sender, EventArgs e )
            {
            this.rtbText.SelectAll();
            }


        //���� - ��������
        private void tsmiUndo_Click( object sender, EventArgs e )
            {
            this.rtbText.Undo();
            }


        //���� - ����������������
        private void tsmiComment_Click( object sender, EventArgs e )
            {
            this.Comment();
            }


        //���� - ������ �����������
        private void tsmiUncomment_Click( object sender, EventArgs e )
            {
            this.Uncomment();
            }


        //���� - ��������� ������
        private void tsmiIncreaseIndent_Click( object sender, EventArgs e )
            {
            this.IncreaseIndent();
            }


        //���� - ��������� ������
        private void tsmiDecreaseIndent_Click( object sender, EventArgs e )
            {
            this.DecreaseIndent();
            }


        //���� - �������� ������� ������
        private void tsmiCutCurrentLine_Click( object sender, EventArgs e )
            {
            this.rtbText.CutCurrentLine();
            }


        //���� - ��������� � ������� �������
        private void tsmiToUpper_Click( object sender, EventArgs e )
            {
            this.SetSelectedTextToUpper();
            }


        //���� - ��������� � ������ �������
        private void tsmiToLower_Click( object sender, EventArgs e )
            {
            this.SetSelectedTextToLower();
            }


        //���� - ������ �����
        private void параметрыToolStripMenuItem_Click( object sender, EventArgs e )
            {
            FormOptions formOptions = new FormOptions();
            formOptions.ShowDialog();
            }


        //���� - ������� �����
        private void tsmiExportOptions_Click( object sender, EventArgs e )
            {
            if ( this.saveOptionDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.SaveToFile( this.saveOptionDialog.FileName );
                }
            }


        //���� - ������ �����
        private void tsmiImportOptions_Click( object sender, EventArgs e )
            {
            if ( this.openOptionDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.OpenFromFile( this.openOptionDialog.FileName );
                }
            }


        //���� - ���������� ����� �� ���������
        private void tsmiSetOptionDefaultValue_Click( object sender, EventArgs e )
            {
            Options.Instance.SetDefaultValues();
            }


        //���� - ������� ������
        private void tsmiQuickPrint_Click( object sender, EventArgs e )
            {
            this.rtbText.PrintRichTextContents();
            }

        //���� - ��������� ������
        private void tsmiPrintSetup_Click( object sender, EventArgs e )
            {
            SetPrintParameters();
            }

        //���� - ������
        private void tsmiPrint_Click( object sender, EventArgs e )
            {
            PrintCurrentDocument();
            }

        //���� - ��������������� ��������
        private void tsmiPrintPreview_Click( object sender, EventArgs e )
            {
            PrintPreviewDocument();
            }


        }
    }
