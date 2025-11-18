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
        Me.PontoOfflineDataSetOracleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineDataSet_Oracle = New Ponto_Offline_VB.PontoOfflineDataSet_Oracle()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.btn_atualizar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.FUNCIONARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FUNCIONARIOTableAdapter = New Ponto_Offline_VB.PontoOfflineDataSet_OracleTableAdapters.FUNCIONARIOTableAdapter()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMPRESAIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineDataSetOracleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineDataSet_Oracle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FUNCIONARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_funcionarios
        '
        Me.dgv_funcionarios.AutoGenerateColumns = False
        Me.dgv_funcionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_funcionarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn4, Me.EMPRESAIDDataGridViewTextBoxColumn})
        Me.dgv_funcionarios.DataSource = Me.FUNCIONARIOBindingSource
        Me.dgv_funcionarios.Location = New System.Drawing.Point(199, 13)
        Me.dgv_funcionarios.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgv_funcionarios.Name = "dgv_funcionarios"
        Me.dgv_funcionarios.Size = New System.Drawing.Size(880, 486)
        Me.dgv_funcionarios.TabIndex = 0
        '
        'PontoOfflineDataSetOracleBindingSource
        '
        Me.PontoOfflineDataSetOracleBindingSource.DataSource = Me.PontoOfflineDataSet_Oracle
        Me.PontoOfflineDataSetOracleBindingSource.Position = 0
        '
        'PontoOfflineDataSet_Oracle
        '
        Me.PontoOfflineDataSet_Oracle.DataSetName = "PontoOfflineDataSet_Oracle"
        Me.PontoOfflineDataSet_Oracle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'btn_atualizar
        '
        Me.btn_atualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_atualizar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_atualizar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_atualizar.Location = New System.Drawing.Point(32, 55)
        Me.btn_atualizar.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_atualizar.Name = "btn_atualizar"
        Me.btn_atualizar.Size = New System.Drawing.Size(134, 28)
        Me.btn_atualizar.TabIndex = 28
        Me.btn_atualizar.Text = "ATUALIZAR"
        Me.btn_atualizar.UseVisualStyleBackColor = False
        '
        'btn_excluir
        '
        Me.btn_excluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_excluir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_excluir.Location = New System.Drawing.Point(32, 97)
        Me.btn_excluir.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(134, 28)
        Me.btn_excluir.TabIndex = 29
        Me.btn_excluir.Text = "EXCLUIR"
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'FUNCIONARIOBindingSource
        '
        Me.FUNCIONARIOBindingSource.DataMember = "FUNCIONARIO"
        Me.FUNCIONARIOBindingSource.DataSource = Me.PontoOfflineDataSetOracleBindingSource
        '
        'FUNCIONARIOTableAdapter
        '
        Me.FUNCIONARIOTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FOLHA"
        Me.DataGridViewTextBoxColumn2.HeaderText = "FOLHA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NOME"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NOME"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CPF"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CPF"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PIS"
        Me.DataGridViewTextBoxColumn4.HeaderText = "PIS"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'EMPRESAIDDataGridViewTextBoxColumn
        '
        Me.EMPRESAIDDataGridViewTextBoxColumn.DataPropertyName = "EMPRESA_ID"
        Me.EMPRESAIDDataGridViewTextBoxColumn.HeaderText = "EMPRESA_ID"
        Me.EMPRESAIDDataGridViewTextBoxColumn.Name = "EMPRESAIDDataGridViewTextBoxColumn"
        '
        'frm_funcionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 554)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_atualizar)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dgv_funcionarios)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frm_funcionario"
        Me.Text = "LISTAGEM DE FUNCIONÁRIOS"
        CType(Me.dgv_funcionarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineDataSetOracleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineDataSet_Oracle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FUNCIONARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_funcionarios As DataGridView
    Friend WithEvents btn_novo As Button
    Friend WithEvents NomeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FolhaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CpfDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PisDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmpresaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents btn_atualizar As Button
    Friend WithEvents btn_excluir As Button
    Friend WithEvents PontoOfflineDataSetOracleBindingSource As BindingSource
    Friend WithEvents PontoOfflineDataSet_Oracle As PontoOfflineDataSet_Oracle
    Friend WithEvents FUNCIONARIOBindingSource As BindingSource
    Friend WithEvents FUNCIONARIOTableAdapter As PontoOfflineDataSet_OracleTableAdapters.FUNCIONARIOTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents EMPRESAIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
