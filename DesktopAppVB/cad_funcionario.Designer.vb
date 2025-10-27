<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cad_funcionario
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cad_funcionario))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_cpf = New System.Windows.Forms.MaskedTextBox()
        Me.cmb_admissao = New System.Windows.Forms.DateTimePicker()
        Me.txt_nome = New System.Windows.Forms.TextBox()
        Me.img_foto = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txt_pis = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_empresa = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_folha = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_cargo = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmb_horario = New System.Windows.Forms.ComboBox()
        Me.cmb_demissao = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmb_nasc = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_concluir = New System.Windows.Forms.Button()
        Me.PontoOfflineVBDataSet1 = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        CType(Me.img_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CPF"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NOME"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(473, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "DATA DE ADMISSÃO"
        '
        'txt_cpf
        '
        Me.txt_cpf.Location = New System.Drawing.Point(29, 146)
        Me.txt_cpf.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cpf.Mask = "999,999,999-99"
        Me.txt_cpf.Name = "txt_cpf"
        Me.txt_cpf.Size = New System.Drawing.Size(114, 22)
        Me.txt_cpf.TabIndex = 5
        Me.txt_cpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_admissao
        '
        Me.cmb_admissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmb_admissao.Location = New System.Drawing.Point(477, 357)
        Me.cmb_admissao.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_admissao.Name = "cmb_admissao"
        Me.cmb_admissao.Size = New System.Drawing.Size(228, 22)
        Me.cmb_admissao.TabIndex = 6
        Me.cmb_admissao.Value = New Date(2025, 8, 12, 0, 0, 0, 0)
        '
        'txt_nome
        '
        Me.txt_nome.Location = New System.Drawing.Point(29, 98)
        Me.txt_nome.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(444, 22)
        Me.txt_nome.TabIndex = 8
        '
        'img_foto
        '
        Me.img_foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.img_foto.Image = CType(resources.GetObject("img_foto.Image"), System.Drawing.Image)
        Me.img_foto.Location = New System.Drawing.Point(495, 24)
        Me.img_foto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.img_foto.Name = "img_foto"
        Me.img_foto.Size = New System.Drawing.Size(203, 243)
        Me.img_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_foto.TabIndex = 10
        Me.img_foto.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txt_pis
        '
        Me.txt_pis.Location = New System.Drawing.Point(29, 194)
        Me.txt_pis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_pis.Name = "txt_pis"
        Me.txt_pis.Size = New System.Drawing.Size(114, 22)
        Me.txt_pis.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "PIS/PASEP"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Location = New System.Drawing.Point(29, 356)
        Me.cmb_empresa.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(330, 24)
        Me.cmb_empresa.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "EMPRESA"
        '
        'txt_folha
        '
        Me.txt_folha.Location = New System.Drawing.Point(29, 50)
        Me.txt_folha.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_folha.Name = "txt_folha"
        Me.txt_folha.Size = New System.Drawing.Size(114, 22)
        Me.txt_folha.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Nº FOLHA"
        '
        'txt_cargo
        '
        Me.txt_cargo.Location = New System.Drawing.Point(29, 405)
        Me.txt_cargo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_cargo.Name = "txt_cargo"
        Me.txt_cargo.Size = New System.Drawing.Size(330, 22)
        Me.txt_cargo.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 385)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "CARGO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 433)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "HORÁRIO"
        '
        'cmb_horario
        '
        Me.cmb_horario.FormattingEnabled = True
        Me.cmb_horario.Location = New System.Drawing.Point(29, 453)
        Me.cmb_horario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_horario.Name = "cmb_horario"
        Me.cmb_horario.Size = New System.Drawing.Size(330, 24)
        Me.cmb_horario.TabIndex = 20
        '
        'cmb_demissao
        '
        Me.cmb_demissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmb_demissao.Location = New System.Drawing.Point(477, 454)
        Me.cmb_demissao.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_demissao.Name = "cmb_demissao"
        Me.cmb_demissao.Size = New System.Drawing.Size(228, 22)
        Me.cmb_demissao.TabIndex = 23
        Me.cmb_demissao.Value = New Date(2025, 9, 10, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(473, 433)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "DATA DE DEMISSÃO"
        '
        'cmb_nasc
        '
        Me.cmb_nasc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmb_nasc.Location = New System.Drawing.Point(29, 244)
        Me.cmb_nasc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_nasc.Name = "cmb_nasc"
        Me.cmb_nasc.Size = New System.Drawing.Size(228, 22)
        Me.cmb_nasc.TabIndex = 25
        Me.cmb_nasc.Value = New Date(2025, 8, 12, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 223)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 16)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "DATA DE NASCIMENTO"
        '
        'btn_concluir
        '
        Me.btn_concluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_concluir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_concluir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_concluir.Location = New System.Drawing.Point(29, 509)
        Me.btn_concluir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_concluir.Name = "btn_concluir"
        Me.btn_concluir.Size = New System.Drawing.Size(114, 28)
        Me.btn_concluir.TabIndex = 26
        Me.btn_concluir.Text = "CONCLUIR"
        Me.btn_concluir.UseVisualStyleBackColor = False
        '
        'PontoOfflineVBDataSet1
        '
        Me.PontoOfflineVBDataSet1.DataSetName = "PontoOfflineVBDataSet"
        Me.PontoOfflineVBDataSet1.Namespace = "http://tempuri.org/PontoOfflineVBDataSet.xsd"
        Me.PontoOfflineVBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Cad_funcionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(744, 555)
        Me.Controls.Add(Me.btn_concluir)
        Me.Controls.Add(Me.cmb_nasc)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmb_demissao)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmb_horario)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_cargo)
        Me.Controls.Add(Me.txt_folha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.txt_pis)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.img_foto)
        Me.Controls.Add(Me.txt_nome)
        Me.Controls.Add(Me.cmb_admissao)
        Me.Controls.Add(Me.txt_cpf)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Cad_funcionario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CADASTRO DE FUNCIONÁRIO"
        CType(Me.img_foto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_cpf As MaskedTextBox
    Friend WithEvents cmb_admissao As DateTimePicker
    Friend WithEvents txt_nome As TextBox
    Friend WithEvents img_foto As PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txt_pis As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmb_empresa As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_folha As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_cargo As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmb_horario As ComboBox
    Friend WithEvents cmb_demissao As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents cmb_nasc As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents btn_concluir As Button
    Friend WithEvents PontoOfflineVBDataSet1 As PontoOfflineVBDataSet
End Class
