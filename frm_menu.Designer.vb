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
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HoráriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuncionáriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrosToolStripMenuItem, Me.GerenciamentoToolStripMenuItem, Me.AppsÚteisToolStripMenuItem, Me.EncerrarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(933, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CadastrosToolStripMenuItem
        '
        Me.CadastrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroToolStripMenuItem, Me.HoráriosToolStripMenuItem, Me.FuncionáriosToolStripMenuItem})
        Me.CadastrosToolStripMenuItem.Name = "CadastrosToolStripMenuItem"
        Me.CadastrosToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.CadastrosToolStripMenuItem.Text = "&Cadastros"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.Image = CType(resources.GetObject("CadastroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.CadastroToolStripMenuItem.Text = "Empresa"
        '
        'HoráriosToolStripMenuItem
        '
        Me.HoráriosToolStripMenuItem.Name = "HoráriosToolStripMenuItem"
        Me.HoráriosToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.HoráriosToolStripMenuItem.Text = "Horários"
        '
        'FuncionáriosToolStripMenuItem
        '
        Me.FuncionáriosToolStripMenuItem.Name = "FuncionáriosToolStripMenuItem"
        Me.FuncionáriosToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.FuncionáriosToolStripMenuItem.Text = "Funcionários"
        '
        'GerenciamentoToolStripMenuItem
        '
        Me.GerenciamentoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowsToolStripMenuItem, Me.BatchToolStripMenuItem})
        Me.GerenciamentoToolStripMenuItem.Name = "GerenciamentoToolStripMenuItem"
        Me.GerenciamentoToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
        Me.GerenciamentoToolStripMenuItem.Text = "&Gerenciamento"
        '
        'WindowsToolStripMenuItem
        '
        Me.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem"
        Me.WindowsToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.WindowsToolStripMenuItem.Text = "Importar Batidas"
        '
        'BatchToolStripMenuItem
        '
        Me.BatchToolStripMenuItem.Name = "BatchToolStripMenuItem"
        Me.BatchToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.BatchToolStripMenuItem.Text = "Gerenciar Pontos"
        '
        'AppsÚteisToolStripMenuItem
        '
        Me.AppsÚteisToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalculadoraDeHorasToolStripMenuItem})
        Me.AppsÚteisToolStripMenuItem.Name = "AppsÚteisToolStripMenuItem"
        Me.AppsÚteisToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.AppsÚteisToolStripMenuItem.Text = "&Apps Úteis"
        '
        'CalculadoraDeHorasToolStripMenuItem
        '
        Me.CalculadoraDeHorasToolStripMenuItem.Name = "CalculadoraDeHorasToolStripMenuItem"
        Me.CalculadoraDeHorasToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CalculadoraDeHorasToolStripMenuItem.Text = "Calculadora De Horas"
        '
        'EncerrarToolStripMenuItem
        '
        Me.EncerrarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EncerrarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.EncerrarToolStripMenuItem.Name = "EncerrarToolStripMenuItem"
        Me.EncerrarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.EncerrarToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.EncerrarToolStripMenuItem.Text = "&Encerrar"
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(933, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
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
    Friend WithEvents CadastroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GerenciamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncerrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BatchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FuncionáriosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HoráriosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppsÚteisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculadoraDeHorasToolStripMenuItem As ToolStripMenuItem
End Class
