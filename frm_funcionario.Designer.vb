<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_funcionario
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_funcionario))
        Me.dgv_funcionarios = New System.Windows.Forms.DataGridView()
        Me.TbfuncionariosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineVBDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineVBDataSet1 = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        Me.TbfuncionariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineVBDataSet = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.Tb_funcionariosTableAdapter = New Ponto_Offline_VB.PontoOfflineVBDataSetTableAdapters.tb_funcionariosTableAdapter()
        Me.NomeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FolhaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CpfDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpresaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbfuncionariosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbfuncionariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_funcionarios
        '
        Me.dgv_funcionarios.AutoGenerateColumns = False
        Me.dgv_funcionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_funcionarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomeDataGridViewTextBoxColumn, Me.FolhaDataGridViewTextBoxColumn, Me.CpfDataGridViewTextBoxColumn, Me.PisDataGridViewTextBoxColumn, Me.EmpresaDataGridViewTextBoxColumn})
        Me.dgv_funcionarios.DataSource = Me.TbfuncionariosBindingSource1
        Me.dgv_funcionarios.Location = New System.Drawing.Point(199, 13)
        Me.dgv_funcionarios.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgv_funcionarios.Name = "dgv_funcionarios"
        Me.dgv_funcionarios.Size = New System.Drawing.Size(880, 486)
        Me.dgv_funcionarios.TabIndex = 0
        '
        'TbfuncionariosBindingSource1
        '
        Me.TbfuncionariosBindingSource1.DataMember = "tb_funcionarios"
        Me.TbfuncionariosBindingSource1.DataSource = Me.PontoOfflineVBDataSet1BindingSource
        '
        'PontoOfflineVBDataSet1BindingSource
        '
        Me.PontoOfflineVBDataSet1BindingSource.DataSource = Me.PontoOfflineVBDataSet1
        Me.PontoOfflineVBDataSet1BindingSource.Position = 0
        '
        'PontoOfflineVBDataSet1
        '
        Me.PontoOfflineVBDataSet1.DataSetName = "PontoOfflineVBDataSet"
        Me.PontoOfflineVBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TbfuncionariosBindingSource
        '
        Me.TbfuncionariosBindingSource.DataMember = "tb_funcionarios"
        Me.TbfuncionariosBindingSource.DataSource = Me.PontoOfflineVBDataSet
        '
        'PontoOfflineVBDataSet
        '
        Me.PontoOfflineVBDataSet.DataSetName = "PontoOfflineVBDataSet"
        Me.PontoOfflineVBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btn_novo
        '
        Me.btn_novo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_novo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_novo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_novo.Location = New System.Drawing.Point(32, 13)
        Me.btn_novo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(134, 28)
        Me.btn_novo.TabIndex = 27
        Me.btn_novo.Text = "ADICIONAR"
        Me.btn_novo.UseVisualStyleBackColor = False
        '
        'Tb_funcionariosTableAdapter
        '
        Me.Tb_funcionariosTableAdapter.ClearBeforeFill = True
        '
        'NomeDataGridViewTextBoxColumn
        '
        Me.NomeDataGridViewTextBoxColumn.DataPropertyName = "nome"
        Me.NomeDataGridViewTextBoxColumn.HeaderText = "Nome"
        Me.NomeDataGridViewTextBoxColumn.Name = "NomeDataGridViewTextBoxColumn"
        Me.NomeDataGridViewTextBoxColumn.Width = 300
        '
        'FolhaDataGridViewTextBoxColumn
        '
        Me.FolhaDataGridViewTextBoxColumn.DataPropertyName = "folha"
        Me.FolhaDataGridViewTextBoxColumn.HeaderText = "Folha"
        Me.FolhaDataGridViewTextBoxColumn.Name = "FolhaDataGridViewTextBoxColumn"
        Me.FolhaDataGridViewTextBoxColumn.Width = 75
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
        Me.PisDataGridViewTextBoxColumn.HeaderText = "PIS/PASEP"
        Me.PisDataGridViewTextBoxColumn.Name = "PisDataGridViewTextBoxColumn"
        '
        'EmpresaDataGridViewTextBoxColumn
        '
        Me.EmpresaDataGridViewTextBoxColumn.DataPropertyName = "empresa"
        Me.EmpresaDataGridViewTextBoxColumn.HeaderText = "Empresa"
        Me.EmpresaDataGridViewTextBoxColumn.Name = "EmpresaDataGridViewTextBoxColumn"
        Me.EmpresaDataGridViewTextBoxColumn.Width = 250
        '
        'frm_funcionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 554)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dgv_funcionarios)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frm_funcionario"
        Me.Text = "LISTAGEM DE FUNCIONÁRIOS"
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbfuncionariosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbfuncionariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_funcionarios As DataGridView
    Friend WithEvents btn_novo As Button
    Friend WithEvents PontoOfflineVBDataSet As PontoOfflineVBDataSet
    Friend WithEvents TbfuncionariosBindingSource As BindingSource
    Friend WithEvents Tb_funcionariosTableAdapter As PontoOfflineVBDataSetTableAdapters.tb_funcionariosTableAdapter
    Friend WithEvents PontoOfflineVBDataSet1BindingSource As BindingSource
    Friend WithEvents PontoOfflineVBDataSet1 As PontoOfflineVBDataSet
    Friend WithEvents TbfuncionariosBindingSource1 As BindingSource
    Friend WithEvents NomeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FolhaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CpfDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PisDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmpresaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
