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
        Me.dgv_funcionarios = New System.Windows.Forms.DataGridView()
        Me.TbfuncionariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineVBDataSet = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.Tb_funcionariosTableAdapter = New Ponto_Offline_VB.PontoOfflineVBDataSetTableAdapters.tb_funcionariosTableAdapter()
        Me.PontoOfflineVBDataSet1 = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        Me.PontoOfflineVBDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TbfuncionariosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.CpfDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataadmissaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpresaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FolhaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CargoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HorarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatademissaoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FotoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatanascDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbfuncionariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbfuncionariosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_funcionarios
        '
        Me.dgv_funcionarios.AutoGenerateColumns = False
        Me.dgv_funcionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_funcionarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CpfDataGridViewTextBoxColumn, Me.NomeDataGridViewTextBoxColumn, Me.DataadmissaoDataGridViewTextBoxColumn, Me.PisDataGridViewTextBoxColumn, Me.EmpresaDataGridViewTextBoxColumn, Me.FolhaDataGridViewTextBoxColumn, Me.CargoDataGridViewTextBoxColumn, Me.HorarioDataGridViewTextBoxColumn, Me.DatademissaoDataGridViewTextBoxColumn, Me.FotoDataGridViewTextBoxColumn, Me.DatanascDataGridViewTextBoxColumn})
        Me.dgv_funcionarios.DataSource = Me.TbfuncionariosBindingSource1
        Me.dgv_funcionarios.Location = New System.Drawing.Point(199, 13)
        Me.dgv_funcionarios.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgv_funcionarios.Name = "dgv_funcionarios"
        Me.dgv_funcionarios.Size = New System.Drawing.Size(880, 486)
        Me.dgv_funcionarios.TabIndex = 0
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
        'PontoOfflineVBDataSet1
        '
        Me.PontoOfflineVBDataSet1.DataSetName = "PontoOfflineVBDataSet"
        Me.PontoOfflineVBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PontoOfflineVBDataSet1BindingSource
        '
        Me.PontoOfflineVBDataSet1BindingSource.DataSource = Me.PontoOfflineVBDataSet1
        Me.PontoOfflineVBDataSet1BindingSource.Position = 0
        '
        'TbfuncionariosBindingSource1
        '
        Me.TbfuncionariosBindingSource1.DataMember = "tb_funcionarios"
        Me.TbfuncionariosBindingSource1.DataSource = Me.PontoOfflineVBDataSet1BindingSource
        '
        'CpfDataGridViewTextBoxColumn
        '
        Me.CpfDataGridViewTextBoxColumn.DataPropertyName = "cpf"
        Me.CpfDataGridViewTextBoxColumn.HeaderText = "cpf"
        Me.CpfDataGridViewTextBoxColumn.Name = "CpfDataGridViewTextBoxColumn"
        '
        'NomeDataGridViewTextBoxColumn
        '
        Me.NomeDataGridViewTextBoxColumn.DataPropertyName = "nome"
        Me.NomeDataGridViewTextBoxColumn.HeaderText = "nome"
        Me.NomeDataGridViewTextBoxColumn.Name = "NomeDataGridViewTextBoxColumn"
        '
        'DataadmissaoDataGridViewTextBoxColumn
        '
        Me.DataadmissaoDataGridViewTextBoxColumn.DataPropertyName = "data_admissao"
        Me.DataadmissaoDataGridViewTextBoxColumn.HeaderText = "data_admissao"
        Me.DataadmissaoDataGridViewTextBoxColumn.Name = "DataadmissaoDataGridViewTextBoxColumn"
        '
        'PisDataGridViewTextBoxColumn
        '
        Me.PisDataGridViewTextBoxColumn.DataPropertyName = "pis"
        Me.PisDataGridViewTextBoxColumn.HeaderText = "pis"
        Me.PisDataGridViewTextBoxColumn.Name = "PisDataGridViewTextBoxColumn"
        '
        'EmpresaDataGridViewTextBoxColumn
        '
        Me.EmpresaDataGridViewTextBoxColumn.DataPropertyName = "empresa"
        Me.EmpresaDataGridViewTextBoxColumn.HeaderText = "empresa"
        Me.EmpresaDataGridViewTextBoxColumn.Name = "EmpresaDataGridViewTextBoxColumn"
        '
        'FolhaDataGridViewTextBoxColumn
        '
        Me.FolhaDataGridViewTextBoxColumn.DataPropertyName = "folha"
        Me.FolhaDataGridViewTextBoxColumn.HeaderText = "folha"
        Me.FolhaDataGridViewTextBoxColumn.Name = "FolhaDataGridViewTextBoxColumn"
        '
        'CargoDataGridViewTextBoxColumn
        '
        Me.CargoDataGridViewTextBoxColumn.DataPropertyName = "cargo"
        Me.CargoDataGridViewTextBoxColumn.HeaderText = "cargo"
        Me.CargoDataGridViewTextBoxColumn.Name = "CargoDataGridViewTextBoxColumn"
        '
        'HorarioDataGridViewTextBoxColumn
        '
        Me.HorarioDataGridViewTextBoxColumn.DataPropertyName = "horario"
        Me.HorarioDataGridViewTextBoxColumn.HeaderText = "horario"
        Me.HorarioDataGridViewTextBoxColumn.Name = "HorarioDataGridViewTextBoxColumn"
        '
        'DatademissaoDataGridViewTextBoxColumn
        '
        Me.DatademissaoDataGridViewTextBoxColumn.DataPropertyName = "data_demissao"
        Me.DatademissaoDataGridViewTextBoxColumn.HeaderText = "data_demissao"
        Me.DatademissaoDataGridViewTextBoxColumn.Name = "DatademissaoDataGridViewTextBoxColumn"
        '
        'FotoDataGridViewTextBoxColumn
        '
        Me.FotoDataGridViewTextBoxColumn.DataPropertyName = "foto"
        Me.FotoDataGridViewTextBoxColumn.HeaderText = "foto"
        Me.FotoDataGridViewTextBoxColumn.Name = "FotoDataGridViewTextBoxColumn"
        '
        'DatanascDataGridViewTextBoxColumn
        '
        Me.DatanascDataGridViewTextBoxColumn.DataPropertyName = "data_nasc"
        Me.DatanascDataGridViewTextBoxColumn.HeaderText = "data_nasc"
        Me.DatanascDataGridViewTextBoxColumn.Name = "DatanascDataGridViewTextBoxColumn"
        '
        'frm_funcionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 554)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dgv_funcionarios)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frm_funcionario"
        Me.Text = "LISTAGEM DE FUNCIONÁRIOS"
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbfuncionariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbfuncionariosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CpfDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NomeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataadmissaoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PisDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmpresaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FolhaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CargoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HorarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DatademissaoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FotoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DatanascDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
