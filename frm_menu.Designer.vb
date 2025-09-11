<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_menu
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CadastrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorárioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuncionárioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GerenciamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppsÚteisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculadoraDeHorasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrosToolStripMenuItem, Me.GerenciamentoToolStripMenuItem, Me.AppsÚteisToolStripMenuItem, Me.EncerrarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1066, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CadastrosToolStripMenuItem
        '
        Me.CadastrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmpresaToolStripMenuItem, Me.HorárioToolStripMenuItem, Me.FuncionárioToolStripMenuItem})
        Me.CadastrosToolStripMenuItem.Name = "CadastrosToolStripMenuItem"
        Me.CadastrosToolStripMenuItem.Size = New System.Drawing.Size(79, 21)
        Me.CadastrosToolStripMenuItem.Text = "&Cadastros"
        '
        'EmpresaToolStripMenuItem
        '
        Me.EmpresaToolStripMenuItem.Image = CType(resources.GetObject("EmpresaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmpresaToolStripMenuItem.Name = "EmpresaToolStripMenuItem"
        Me.EmpresaToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.EmpresaToolStripMenuItem.Text = "Empresa"
        '
        'HorárioToolStripMenuItem
        '
        Me.HorárioToolStripMenuItem.Name = "HorárioToolStripMenuItem"
        Me.HorárioToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.HorárioToolStripMenuItem.Text = "Horário"
        '
        'FuncionárioToolStripMenuItem
        '
        Me.FuncionárioToolStripMenuItem.Name = "FuncionárioToolStripMenuItem"
        Me.FuncionárioToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.FuncionárioToolStripMenuItem.Text = "Funcionário"
        '
        'GerenciamentoToolStripMenuItem
        '
        Me.GerenciamentoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowsToolStripMenuItem, Me.BatchToolStripMenuItem})
        Me.GerenciamentoToolStripMenuItem.Name = "GerenciamentoToolStripMenuItem"
        Me.GerenciamentoToolStripMenuItem.Size = New System.Drawing.Size(108, 21)
        Me.GerenciamentoToolStripMenuItem.Text = "&Gerenciamento"
        '
        'WindowsToolStripMenuItem
        '
        Me.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem"
        Me.WindowsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.WindowsToolStripMenuItem.Text = "Importar Batidas"
        '
        'BatchToolStripMenuItem
        '
        Me.BatchToolStripMenuItem.Name = "BatchToolStripMenuItem"
        Me.BatchToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BatchToolStripMenuItem.Text = "Gerenciar Pontos"
        '
        'AppsÚteisToolStripMenuItem
        '
        Me.AppsÚteisToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalculadoraDeHorasToolStripMenuItem})
        Me.AppsÚteisToolStripMenuItem.Name = "AppsÚteisToolStripMenuItem"
        Me.AppsÚteisToolStripMenuItem.Size = New System.Drawing.Size(83, 21)
        Me.AppsÚteisToolStripMenuItem.Text = "&Apps Úteis"
        '
        'CalculadoraDeHorasToolStripMenuItem
        '
        Me.CalculadoraDeHorasToolStripMenuItem.Name = "CalculadoraDeHorasToolStripMenuItem"
        Me.CalculadoraDeHorasToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.CalculadoraDeHorasToolStripMenuItem.Text = "Calculadora De Horas"
        '
        'EncerrarToolStripMenuItem
        '
        Me.EncerrarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EncerrarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.EncerrarToolStripMenuItem.Name = "EncerrarToolStripMenuItem"
        Me.EncerrarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.EncerrarToolStripMenuItem.Size = New System.Drawing.Size(69, 21)
        Me.EncerrarToolStripMenuItem.Text = "&Encerrar"
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1066, 554)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frm_menu"
        Me.Text = "PONTO OFFLINE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CadastrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GerenciamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncerrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BatchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FuncionárioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HorárioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppsÚteisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculadoraDeHorasToolStripMenuItem As ToolStripMenuItem
End Class
