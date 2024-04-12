
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
            this.btnDevList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.btnDevDetail = new System.Windows.Forms.Button();
            this.btnCapuleInfo = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDevStatus = new System.Windows.Forms.Button();
            this.btnRealTime = new System.Windows.Forms.Button();
            this.btnMixed = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDura = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScentList
            // 
            this.btnScentList.Location = new System.Drawing.Point(481, 25);
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
            this.txtScents.Location = new System.Drawing.Point(167, 32);
            this.txtScents.Name = "txtScents";
            this.txtScents.Size = new System.Drawing.Size(269, 21);
            this.txtScents.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "气味编号(多个以逗号隔开)";
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(3, 17);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(418, 163);
            this.txtInfo.TabIndex = 5;
            // 
            // btnDevList
            // 
            this.btnDevList.Location = new System.Drawing.Point(481, 290);
            this.btnDevList.Name = "btnDevList";
            this.btnDevList.Size = new System.Drawing.Size(88, 30);
            this.btnDevList.TabIndex = 6;
            this.btnDevList.Text = "设备列表";
            this.btnDevList.UseVisualStyleBackColor = true;
            this.btnDevList.Click += new System.EventHandler(this.btnDevList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "设备MAC";
            // 
            // txtMac
            // 
            this.txtMac.Location = new System.Drawing.Point(76, 269);
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(269, 21);
            this.txtMac.TabIndex = 7;
            // 
            // btnDevDetail
            // 
            this.btnDevDetail.Location = new System.Drawing.Point(481, 337);
            this.btnDevDetail.Name = "btnDevDetail";
            this.btnDevDetail.Size = new System.Drawing.Size(88, 30);
            this.btnDevDetail.TabIndex = 9;
            this.btnDevDetail.Text = "设备详细信息";
            this.btnDevDetail.UseVisualStyleBackColor = true;
            this.btnDevDetail.Click += new System.EventHandler(this.btnDevDetail_Click);
            // 
            // btnCapuleInfo
            // 
            this.btnCapuleInfo.Location = new System.Drawing.Point(481, 382);
            this.btnCapuleInfo.Name = "btnCapuleInfo";
            this.btnCapuleInfo.Size = new System.Drawing.Size(88, 30);
            this.btnCapuleInfo.TabIndex = 10;
            this.btnCapuleInfo.Text = "设备胶囊信息";
            this.btnCapuleInfo.UseVisualStyleBackColor = true;
            this.btnCapuleInfo.Click += new System.EventHandler(this.btnCapuleInfo_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(331, 301);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(88, 30);
            this.btnPlay.TabIndex = 11;
            this.btnPlay.Text = "播放气味";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(331, 337);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 30);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止播放气味";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDevStatus
            // 
            this.btnDevStatus.Location = new System.Drawing.Point(14, 382);
            this.btnDevStatus.Name = "btnDevStatus";
            this.btnDevStatus.Size = new System.Drawing.Size(134, 30);
            this.btnDevStatus.TabIndex = 13;
            this.btnDevStatus.Text = "设备在线状态";
            this.btnDevStatus.UseVisualStyleBackColor = true;
            this.btnDevStatus.Click += new System.EventHandler(this.btnDevStatus_Click);
            // 
            // btnRealTime
            // 
            this.btnRealTime.Location = new System.Drawing.Point(167, 382);
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Size = new System.Drawing.Size(134, 30);
            this.btnRealTime.TabIndex = 14;
            this.btnRealTime.Text = "设备实时在线状态";
            this.btnRealTime.UseVisualStyleBackColor = true;
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // btnMixed
            // 
            this.btnMixed.Location = new System.Drawing.Point(331, 382);
            this.btnMixed.Name = "btnMixed";
            this.btnMixed.Size = new System.Drawing.Size(134, 30);
            this.btnMixed.TabIndex = 15;
            this.btnMixed.Text = "多路播放";
            this.btnMixed.UseVisualStyleBackColor = true;
            this.btnMixed.Click += new System.EventHandler(this.btnMixed_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Location = new System.Drawing.Point(14, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 183);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "返回信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "通道编号";
            // 
            // txtChl
            // 
            this.txtChl.Location = new System.Drawing.Point(76, 310);
            this.txtChl.Name = "txtChl";
            this.txtChl.Size = new System.Drawing.Size(166, 21);
            this.txtChl.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "播放时长";
            // 
            // txtDura
            // 
            this.txtDura.Location = new System.Drawing.Point(76, 343);
            this.txtDura.Name = "txtDura";
            this.txtDura.Size = new System.Drawing.Size(166, 21);
            this.txtDura.TabIndex = 19;
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 424);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMixed);
            this.Controls.Add(this.btnRealTime);
            this.Controls.Add(this.btnDevStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnCapuleInfo);
            this.Controls.Add(this.btnDevDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMac);
            this.Controls.Add(this.btnDevList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScents);
            this.Controls.Add(this.btnScentSum);
            this.Controls.Add(this.btnScentDetail);
            this.Controls.Add(this.btnScentList);
            this.Name = "mainFrm";
            this.Text = "测试Demo";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnDevList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Button btnDevDetail;
        private System.Windows.Forms.Button btnCapuleInfo;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnDevStatus;
        private System.Windows.Forms.Button btnRealTime;
        private System.Windows.Forms.Button btnMixed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDura;
    }
}

