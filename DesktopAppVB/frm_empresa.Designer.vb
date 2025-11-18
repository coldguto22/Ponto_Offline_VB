<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_empresa
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_empresa))
        Me.dgv_empresas = New System.Windows.Forms.DataGridView()
        Me.EMPRESABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineDataSetOracleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineDataSet_Oracle = New Ponto_Offline_VB.PontoOfflineDataSet_Oracle()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.EMPRESATableAdapter = New Ponto_Offline_VB.PontoOfflineDataSet_OracleTableAdapters.EMPRESATableAdapter()
        Me.CNPJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOME_FANTASIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAZAO_SOCIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INSC_ESTADUAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_empresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineDataSetOracleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineDataSet_Oracle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_empresas
        '
        Me.dgv_empresas.AllowUserToAddRows = False
        Me.dgv_empresas.AllowUserToDeleteRows = False
        Me.dgv_empresas.AllowUserToResizeColumns = False
        Me.dgv_empresas.AllowUserToResizeRows = False
        Me.dgv_empresas.AutoGenerateColumns = False
        Me.dgv_empresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgv_empresas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgv_empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_empresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CNPJ, Me.NOME_FANTASIA, Me.RAZAO_SOCIAL, Me.INSC_ESTADUAL})
        Me.dgv_empresas.DataSource = Me.EMPRESABindingSource
        Me.dgv_empresas.Location = New System.Drawing.Point(12, 51)
        Me.dgv_empresas.Name = "dgv_empresas"
        Me.dgv_empresas.ReadOnly = True
        Me.dgv_empresas.Size = New System.Drawing.Size(760, 350)
        Me.dgv_empresas.TabIndex = 0
        '
        'EMPRESABindingSource
        '
        Me.EMPRESABindingSource.DataMember = "EMPRESA"
        Me.EMPRESABindingSource.DataSource = Me.PontoOfflineDataSetOracleBindingSource
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
        Me.btn_novo.Location = New System.Drawing.Point(12, 13)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(120, 28)
        Me.btn_novo.TabIndex = 1
        Me.btn_novo.Text = "ADICIONAR"
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'btn_editar
        '
        Me.btn_editar.Location = New System.Drawing.Point(154, 13)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(134, 28)
        Me.btn_editar.TabIndex = 28
        Me.btn_editar.Text = "EDITAR"
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Location = New System.Drawing.Point(319, 14)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(134, 28)
        Me.btn_excluir.TabIndex = 29
        Me.btn_excluir.Text = "EXCLUIR"
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'EMPRESATableAdapter
        '
        Me.EMPRESATableAdapter.ClearBeforeFill = True
        '
        'CNPJ
        '
        Me.CNPJ.DataPropertyName = "CNPJ"
        Me.CNPJ.HeaderText = "CNPJ"
        Me.CNPJ.Name = "CNPJ"
        Me.CNPJ.ReadOnly = True
        Me.CNPJ.Width = 59
        '
        'NOME_FANTASIA
        '
        Me.NOME_FANTASIA.DataPropertyName = "NOME_FANTASIA"
        Me.NOME_FANTASIA.HeaderText = "NOME_FANTASIA"
        Me.NOME_FANTASIA.Name = "NOME_FANTASIA"
        Me.NOME_FANTASIA.ReadOnly = True
        Me.NOME_FANTASIA.Width = 122
        '
        'RAZAO_SOCIAL
        '
        Me.RAZAO_SOCIAL.DataPropertyName = "RAZAO_SOCIAL"
        Me.RAZAO_SOCIAL.HeaderText = "RAZAO_SOCIAL"
        Me.RAZAO_SOCIAL.Name = "RAZAO_SOCIAL"
        Me.RAZAO_SOCIAL.ReadOnly = True
        Me.RAZAO_SOCIAL.Width = 113
        '
        'INSC_ESTADUAL
        '
        Me.INSC_ESTADUAL.DataPropertyName = "INSC_ESTADUAL"
        Me.INSC_ESTADUAL.HeaderText = "INSC_ESTADUAL"
        Me.INSC_ESTADUAL.Name = "INSC_ESTADUAL"
        Me.INSC_ESTADUAL.ReadOnly = True
        Me.INSC_ESTADUAL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.INSC_ESTADUAL.Width = 120
        '
        'frm_empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 422)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_editar)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dgv_empresas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_empresa"
        Me.Text = "LISTAGEM DE EMPRESAS"
        CType(Me.dgv_empresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineDataSetOracleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineDataSet_Oracle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_empresas As DataGridView
    Friend WithEvents btn_novo As Button
    Friend WithEvents CnpjDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RazaosocialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents btn_editar As Button
    Friend WithEvents btn_excluir As Button
    Friend WithEvents PontoOfflineDataSetOracleBindingSource As BindingSource
    Friend WithEvents PontoOfflineDataSet_Oracle As PontoOfflineDataSet_Oracle
    Friend WithEvents EMPRESABindingSource As BindingSource
    Friend WithEvents EMPRESATableAdapter As PontoOfflineDataSet_OracleTableAdapters.EMPRESATableAdapter
    Friend WithEvents CNPJ As DataGridViewTextBoxColumn
    Friend WithEvents NOME_FANTASIA As DataGridViewTextBoxColumn
    Friend WithEvents RAZAO_SOCIAL As DataGridViewTextBoxColumn
    Friend WithEvents INSC_ESTADUAL As DataGridViewTextBoxColumn
End Class
