<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_funcionario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgv_funcionarios = New System.Windows.Forms.DataGridView()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.PontoOfflineVBDataSet = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        Me.TbfuncionariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tb_funcionariosTableAdapter = New Ponto_Offline_VB.PontoOfflineVBDataSetTableAdapters.tb_funcionariosTableAdapter()
        Me.FolhaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CpfDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpresaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbfuncionariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_funcionarios
        '
        Me.dgv_funcionarios.AutoGenerateColumns = False
        Me.dgv_funcionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_funcionarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FolhaDataGridViewTextBoxColumn, Me.NomeDataGridViewTextBoxColumn, Me.CpfDataGridViewTextBoxColumn, Me.PisDataGridViewTextBoxColumn, Me.EmpresaDataGridViewTextBoxColumn})
        Me.dgv_funcionarios.DataSource = Me.TbfuncionariosBindingSource
        Me.dgv_funcionarios.Location = New System.Drawing.Point(167, 12)
        Me.dgv_funcionarios.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgv_funcionarios.Name = "dgv_funcionarios"
        Me.dgv_funcionarios.Size = New System.Drawing.Size(770, 426)
        Me.dgv_funcionarios.TabIndex = 0
        '
        'btn_novo
        '
        Me.btn_novo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_novo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_novo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_novo.Location = New System.Drawing.Point(23, 119)
        Me.btn_novo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(117, 23)
        Me.btn_novo.TabIndex = 27
        Me.btn_novo.Text = "ADICIONAR"
        Me.btn_novo.UseVisualStyleBackColor = False
        '
        'PontoOfflineVBDataSet
        '
        Me.PontoOfflineVBDataSet.DataSetName = "PontoOfflineVBDataSet"
        Me.PontoOfflineVBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TbfuncionariosBindingSource
        '
        Me.TbfuncionariosBindingSource.DataMember = "tb_funcionarios"
        Me.TbfuncionariosBindingSource.DataSource = Me.PontoOfflineVBDataSet
        '
        'Tb_funcionariosTableAdapter
        '
        Me.Tb_funcionariosTableAdapter.ClearBeforeFill = True
        '
        'FolhaDataGridViewTextBoxColumn
        '
        Me.FolhaDataGridViewTextBoxColumn.DataPropertyName = "folha"
        Me.FolhaDataGridViewTextBoxColumn.HeaderText = "Nº Folha"
        Me.FolhaDataGridViewTextBoxColumn.Name = "FolhaDataGridViewTextBoxColumn"
        Me.FolhaDataGridViewTextBoxColumn.Width = 70
        '
        'NomeDataGridViewTextBoxColumn
        '
        Me.NomeDataGridViewTextBoxColumn.DataPropertyName = "nome"
        Me.NomeDataGridViewTextBoxColumn.HeaderText = "Nome"
        Me.NomeDataGridViewTextBoxColumn.Name = "NomeDataGridViewTextBoxColumn"
        Me.NomeDataGridViewTextBoxColumn.Width = 250
        '
        'CpfDataGridViewTextBoxColumn
        '
        Me.CpfDataGridViewTextBoxColumn.DataPropertyName = "cpf"
        Me.CpfDataGridViewTextBoxColumn.HeaderText = "CPF"
        Me.CpfDataGridViewTextBoxColumn.Name = "CpfDataGridViewTextBoxColumn"
        '
        'PisDataGridViewTextBoxColumn
        '
        Me.PisDataGridViewTextBoxColumn.DataPropertyName = "pis"
        Me.PisDataGridViewTextBoxColumn.HeaderText = "PIS"
        Me.PisDataGridViewTextBoxColumn.Name = "PisDataGridViewTextBoxColumn"
        '
        'EmpresaDataGridViewTextBoxColumn
        '
        Me.EmpresaDataGridViewTextBoxColumn.DataPropertyName = "empresa"
        Me.EmpresaDataGridViewTextBoxColumn.HeaderText = "Empresa"
        Me.EmpresaDataGridViewTextBoxColumn.Name = "EmpresaDataGridViewTextBoxColumn"
        Me.EmpresaDataGridViewTextBoxColumn.Width = 200
        '
        'frm_funcionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 450)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dgv_funcionarios)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frm_funcionario"
        Me.Text = "frm_funcionario"
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbfuncionariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_funcionarios As DataGridView
    Friend WithEvents btn_novo As Button
    Friend WithEvents PontoOfflineVBDataSet As PontoOfflineVBDataSet
    Friend WithEvents TbfuncionariosBindingSource As BindingSource
    Friend WithEvents Tb_funcionariosTableAdapter As PontoOfflineVBDataSetTableAdapters.tb_funcionariosTableAdapter
    Friend WithEvents FolhaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NomeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CpfDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PisDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmpresaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
