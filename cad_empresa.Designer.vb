<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cad_empresa
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cad_empresa))
        Me.txt_razao = New System.Windows.Forms.TextBox()
        Me.txt_fantasia = New System.Windows.Forms.TextBox()
        Me.txt_insc = New System.Windows.Forms.TextBox()
        Me.txt_endereco = New System.Windows.Forms.TextBox()
        Me.txt_telefone = New System.Windows.Forms.TextBox()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.lbl_cnpj = New System.Windows.Forms.Label()
        Me.lbl_razao = New System.Windows.Forms.Label()
        Me.lbl_fantasia = New System.Windows.Forms.Label()
        Me.lbl_insc = New System.Windows.Forms.Label()
        Me.lbl_endereco = New System.Windows.Forms.Label()
        Me.lbl_telefone = New System.Windows.Forms.Label()
        Me.lbl_email = New System.Windows.Forms.Label()
        Me.btn_concluir = New System.Windows.Forms.Button()
        Me.txt_cnpj = New System.Windows.Forms.MaskedTextBox()
        Me.SuspendLayout()
        '
        'txt_razao
        '
        Me.txt_razao.Location = New System.Drawing.Point(160, 55)
        Me.txt_razao.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_razao.Name = "txt_razao"
        Me.txt_razao.Size = New System.Drawing.Size(399, 22)
        Me.txt_razao.TabIndex = 1
        '
        'txt_fantasia
        '
        Me.txt_fantasia.Location = New System.Drawing.Point(160, 92)
        Me.txt_fantasia.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_fantasia.Name = "txt_fantasia"
        Me.txt_fantasia.Size = New System.Drawing.Size(399, 22)
        Me.txt_fantasia.TabIndex = 2
        '
        'txt_insc
        '
        Me.txt_insc.Location = New System.Drawing.Point(160, 129)
        Me.txt_insc.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_insc.Name = "txt_insc"
        Me.txt_insc.Size = New System.Drawing.Size(265, 22)
        Me.txt_insc.TabIndex = 3
        '
        'txt_endereco
        '
        Me.txt_endereco.Location = New System.Drawing.Point(160, 166)
        Me.txt_endereco.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_endereco.Name = "txt_endereco"
        Me.txt_endereco.Size = New System.Drawing.Size(532, 22)
        Me.txt_endereco.TabIndex = 4
        '
        'txt_telefone
        '
        Me.txt_telefone.Location = New System.Drawing.Point(160, 203)
        Me.txt_telefone.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_telefone.Name = "txt_telefone"
        Me.txt_telefone.Size = New System.Drawing.Size(265, 22)
        Me.txt_telefone.TabIndex = 5
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(160, 240)
        Me.txt_email.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(399, 22)
        Me.txt_email.TabIndex = 6
        '
        'lbl_cnpj
        '
        Me.lbl_cnpj.AutoSize = True
        Me.lbl_cnpj.Location = New System.Drawing.Point(27, 22)
        Me.lbl_cnpj.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_cnpj.Name = "lbl_cnpj"
        Me.lbl_cnpj.Size = New System.Drawing.Size(43, 16)
        Me.lbl_cnpj.TabIndex = 7
        Me.lbl_cnpj.Text = "CNPJ"
        '
        'lbl_razao
        '
        Me.lbl_razao.AutoSize = True
        Me.lbl_razao.Location = New System.Drawing.Point(27, 59)
        Me.lbl_razao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_razao.Name = "lbl_razao"
        Me.lbl_razao.Size = New System.Drawing.Size(89, 16)
        Me.lbl_razao.TabIndex = 8
        Me.lbl_razao.Text = "Razão Social"
        '
        'lbl_fantasia
        '
        Me.lbl_fantasia.AutoSize = True
        Me.lbl_fantasia.Location = New System.Drawing.Point(27, 96)
        Me.lbl_fantasia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_fantasia.Name = "lbl_fantasia"
        Me.lbl_fantasia.Size = New System.Drawing.Size(100, 16)
        Me.lbl_fantasia.TabIndex = 9
        Me.lbl_fantasia.Text = "Nome Fantasia"
        '
        'lbl_insc
        '
        Me.lbl_insc.AutoSize = True
        Me.lbl_insc.Location = New System.Drawing.Point(27, 133)
        Me.lbl_insc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_insc.Name = "lbl_insc"
        Me.lbl_insc.Size = New System.Drawing.Size(91, 16)
        Me.lbl_insc.TabIndex = 10
        Me.lbl_insc.Text = "Insc. Estadual"
        '
        'lbl_endereco
        '
        Me.lbl_endereco.AutoSize = True
        Me.lbl_endereco.Location = New System.Drawing.Point(27, 170)
        Me.lbl_endereco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_endereco.Name = "lbl_endereco"
        Me.lbl_endereco.Size = New System.Drawing.Size(67, 16)
        Me.lbl_endereco.TabIndex = 11
        Me.lbl_endereco.Text = "Endereço"
        '
        'lbl_telefone
        '
        Me.lbl_telefone.AutoSize = True
        Me.lbl_telefone.Location = New System.Drawing.Point(27, 207)
        Me.lbl_telefone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_telefone.Name = "lbl_telefone"
        Me.lbl_telefone.Size = New System.Drawing.Size(62, 16)
        Me.lbl_telefone.TabIndex = 12
        Me.lbl_telefone.Text = "Telefone"
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Location = New System.Drawing.Point(27, 244)
        Me.lbl_email.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(42, 16)
        Me.lbl_email.TabIndex = 13
        Me.lbl_email.Text = "Email"
        '
        'btn_concluir
        '
        Me.btn_concluir.Location = New System.Drawing.Point(160, 283)
        Me.btn_concluir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_concluir.Name = "btn_concluir"
        Me.btn_concluir.Size = New System.Drawing.Size(160, 41)
        Me.btn_concluir.TabIndex = 14
        Me.btn_concluir.Text = "Concluir"
        Me.btn_concluir.UseVisualStyleBackColor = True
        '
        'txt_cnpj
        '
        Me.txt_cnpj.Location = New System.Drawing.Point(160, 22)
        Me.txt_cnpj.Mask = "99.999.999/9999-99"
        Me.txt_cnpj.Name = "txt_cnpj"
        Me.txt_cnpj.Size = New System.Drawing.Size(121, 22)
        Me.txt_cnpj.TabIndex = 15
        '
        'cad_empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 346)
        Me.Controls.Add(Me.txt_cnpj)
        Me.Controls.Add(Me.btn_concluir)
        Me.Controls.Add(Me.lbl_email)
        Me.Controls.Add(Me.lbl_telefone)
        Me.Controls.Add(Me.lbl_endereco)
        Me.Controls.Add(Me.lbl_insc)
        Me.Controls.Add(Me.lbl_fantasia)
        Me.Controls.Add(Me.lbl_razao)
        Me.Controls.Add(Me.lbl_cnpj)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_telefone)
        Me.Controls.Add(Me.txt_endereco)
        Me.Controls.Add(Me.txt_insc)
        Me.Controls.Add(Me.txt_fantasia)
        Me.Controls.Add(Me.txt_razao)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "cad_empresa"
        Me.Text = "Cadastro de Empresa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_razao As TextBox
    Friend WithEvents txt_fantasia As TextBox
    Friend WithEvents txt_insc As TextBox
    Friend WithEvents txt_endereco As TextBox
    Friend WithEvents txt_telefone As TextBox
    Friend WithEvents txt_email As TextBox
    Friend WithEvents lbl_cnpj As Label
    Friend WithEvents lbl_razao As Label
    Friend WithEvents lbl_fantasia As Label
    Friend WithEvents lbl_insc As Label
    Friend WithEvents lbl_endereco As Label
    Friend WithEvents lbl_telefone As Label
    Friend WithEvents lbl_email As Label
    Friend WithEvents btn_concluir As Button
    Friend WithEvents txt_cnpj As MaskedTextBox
End Class
