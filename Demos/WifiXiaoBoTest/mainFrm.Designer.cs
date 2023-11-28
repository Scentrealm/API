
namespace WifiXiaoBoTest
{
    partial class mainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScentList = new System.Windows.Forms.Button();
            this.btnScentDetail = new System.Windows.Forms.Button();
            this.btnScentSum = new System.Windows.Forms.Button();
            this.txtScents = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnScentList
            // 
            this.btnScentList.Location = new System.Drawing.Point(481, 32);
            this.btnScentList.Name = "btnScentList";
            this.btnScentList.Size = new System.Drawing.Size(94, 33);
            this.btnScentList.TabIndex = 0;
            this.btnScentList.Text = "气味列表";
            this.btnScentList.UseVisualStyleBackColor = true;
            this.btnScentList.Click += new System.EventHandler(this.btnScentList_Click);
            // 
            // btnScentDetail
            // 
            this.btnScentDetail.Location = new System.Drawing.Point(481, 96);
            this.btnScentDetail.Name = "btnScentDetail";
            this.btnScentDetail.Size = new System.Drawing.Size(94, 33);
            this.btnScentDetail.TabIndex = 1;
            this.btnScentDetail.Text = "气味详细信息";
            this.btnScentDetail.UseVisualStyleBackColor = true;
            this.btnScentDetail.Click += new System.EventHandler(this.btnScentDetail_Click);
            // 
            // btnScentSum
            // 
            this.btnScentSum.Location = new System.Drawing.Point(481, 163);
            this.btnScentSum.Name = "btnScentSum";
            this.btnScentSum.Size = new System.Drawing.Size(94, 33);
            this.btnScentSum.TabIndex = 2;
            this.btnScentSum.Text = "气味总列表";
            this.btnScentSum.UseVisualStyleBackColor = true;
            this.btnScentSum.Click += new System.EventHandler(this.btnScentSum_Click);
            // 
            // txtScents
            // 
            this.txtScents.Location = new System.Drawing.Point(167, 39);
            this.txtScents.Name = "txtScents";
            this.txtScents.Size = new System.Drawing.Size(269, 21);
            this.txtScents.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "气味编号(多个以逗号隔开)";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(14, 96);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(422, 255);
            this.txtInfo.TabIndex = 5;
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 400);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScents);
            this.Controls.Add(this.btnScentSum);
            this.Controls.Add(this.btnScentDetail);
            this.Controls.Add(this.btnScentList);
            this.Name = "mainFrm";
            this.Text = "测试Demo";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScentList;
        private System.Windows.Forms.Button btnScentDetail;
        private System.Windows.Forms.Button btnScentSum;
        private System.Windows.Forms.TextBox txtScents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInfo;
    }
}

