using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace FindFileDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.Columns.Add("파일 명");
            listView1.Columns.Add("전체경로");
            listView1.Columns.Add("크기");
            listView1.Columns.Add("확장자");
            listView1.Columns.Add("수정 날짜");
        }

        #region 파일선택창
        private void SetPath(object sender, EventArgs e)
        {
            // 외부 api 사용함
            var dir = new CommonOpenFileDialog();       // 선언 var는 좀 더 공부해야 함

            dir.IsFolderPicker = true;  // 폴더선택 허용
                       
            if (dir.ShowDialog() == CommonFileDialogResult.Ok)      // 폴더만 선택 한다면
            {
                 System.Diagnostics.Debug.Print("폴더만 눌렀음");
                System.Diagnostics.Debug.Print(dir.FileName);
                txtPath.Text = dir.FileName;    // 선택한 path 넣어줌
            }
            else // 취소하거나 esc했을 경우?
            {
                return;
            }
            txtKeyword.Focus();
        }

        #endregion

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtKeyword.Text.Trim().Equals(""))  // 입력 된 검색어가 없다면
            {
                MessageBox.Show("검색어를 입력해주세요.", "lee.sunbae", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPath.Text.Trim().Equals(""))
            {
                MessageBox.Show("경로를 지정해주세요.", "lee.sunbae", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FindFiles(txtPath.Text, txtKeyword.Text);

        }

        private void FindFiles(string dir, string keyword)
        {
            // 경로 저장
            string[] files = System.IO.Directory.GetFiles(dir, keyword);

            // 결과 표시
            if (files.Length > 0)   // 검색 결과가 있다면
            {
                laResult.Text = "검색 결과 : " + files.Length + " 건이 검색되었습니다.";
            }
            else
            {
                laResult.Text = "검색 결과 : " + " 검색 결과가 없습니다.";
            }

            for (int i = 0; i < files.Length; i++)
            {
                System.IO.FileInfo flinfo = new System.IO.FileInfo(files[i]);

                ListViewItem item = new ListViewItem(flinfo.Name, 0);
 
                item.SubItems.Add(flinfo.FullName.ToString());
                item.SubItems.Add(flinfo.Length.ToString());        // 파일 크기
                item.SubItems.Add(flinfo.Extension.ToString());     // 파일 종류 (확장자)
                item.SubItems.Add(flinfo.FullName.ToString());      // 파일 마지막 수정날짜

                listView1.Items.Add(item);
            }


        }


    }
}
