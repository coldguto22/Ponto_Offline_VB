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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgv_empresas = New System.Windows.Forms.DataGridView()
        Me.PontoOfflineVBDataSet2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.TbempresasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineVBDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineVBDataSet3 = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        Me.TbempresasBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tb_empresasTableAdapter1 = New Ponto_Offline_VB.PontoOfflineVBDataSetTableAdapters.tb_empresasTableAdapter()
        Me.CnpjDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazaosocialDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomefantasiaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InscestadualDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnderecoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TelefoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_empresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbempresasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbempresasBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_empresas
        '
        Me.dgv_empresas.AllowUserToAddRows = False
        Me.dgv_empresas.AllowUserToDeleteRows = False
        Me.dgv_empresas.AutoGenerateColumns = False
        Me.dgv_empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_empresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CnpjDataGridViewTextBoxColumn, Me.RazaosocialDataGridViewTextBoxColumn, Me.NomefantasiaDataGridViewTextBoxColumn, Me.InscestadualDataGridViewTextBoxColumn, Me.EnderecoDataGridViewTextBoxColumn, Me.TelefoneDataGridViewTextBoxColumn, Me.EmailDataGridViewTextBoxColumn})
        Me.dgv_empresas.DataSource = Me.TbempresasBindingSource1
        Me.dgv_empresas.Location = New System.Drawing.Point(12, 51)
        Me.dgv_empresas.Name = "dgv_empresas"
        Me.dgv_empresas.ReadOnly = True
        Me.dgv_empresas.Size = New System.Drawing.Size(760, 350)
        Me.dgv_empresas.TabIndex = 0
        '
        'btn_novo
        '
        Me.btn_novo.Location = New System.Drawing.Point(12, 12)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(120, 33)
        Me.btn_novo.TabIndex = 1
        Me.btn_novo.Text = "Nova Empresa"
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'TbempresasBindingSource
        '
        Me.TbempresasBindingSource.DataMember = "tb_empresas"
        '
        'PontoOfflineVBDataSet3
        '
        Me.PontoOfflineVBDataSet3.DataSetName = "PontoOfflineVBDataSet"
        Me.PontoOfflineVBDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TbempresasBindingSource1
        '
        Me.TbempresasBindingSource1.DataMember = "tb_empresas"
        Me.TbempresasBindingSource1.DataSource = Me.PontoOfflineVBDataSet3
        '
        'Tb_empresasTableAdapter1
        '
        Me.Tb_empresasTableAdapter1.ClearBeforeFill = True
        '
        'CnpjDataGridViewTextBoxColumn
        '
        Me.CnpjDataGridViewTextBoxColumn.DataPropertyName = "cnpj"
        Me.CnpjDataGridViewTextBoxColumn.HeaderText = "cnpj"
        Me.CnpjDataGridViewTextBoxColumn.Name = "CnpjDataGridViewTextBoxColumn"
        Me.CnpjDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RazaosocialDataGridViewTextBoxColumn
        '
        Me.RazaosocialDataGridViewTextBoxColumn.DataPropertyName = "razao_social"
        Me.RazaosocialDataGridViewTextBoxColumn.HeaderText = "razao_social"
        Me.RazaosocialDataGridViewTextBoxColumn.Name = "RazaosocialDataGridViewTextBoxColumn"
        Me.RazaosocialDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NomefantasiaDataGridViewTextBoxColumn
        '
        Me.NomefantasiaDataGridViewTextBoxColumn.DataPropertyName = "nome_fantasia"
        Me.NomefantasiaDataGridViewTextBoxColumn.HeaderText = "nome_fantasia"
        Me.NomefantasiaDataGridViewTextBoxColumn.Name = "NomefantasiaDataGridViewTextBoxColumn"
        Me.NomefantasiaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InscestadualDataGridViewTextBoxColumn
        '
        Me.InscestadualDataGridViewTextBoxColumn.DataPropertyName = "insc_estadual"
        Me.InscestadualDataGridViewTextBoxColumn.HeaderText = "insc_estadual"
        Me.InscestadualDataGridViewTextBoxColumn.Name = "InscestadualDataGridViewTextBoxColumn"
        Me.InscestadualDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EnderecoDataGridViewTextBoxColumn
        '
        Me.EnderecoDataGridViewTextBoxColumn.DataPropertyName = "endereco"
        Me.EnderecoDataGridViewTextBoxColumn.HeaderText = "endereco"
        Me.EnderecoDataGridViewTextBoxColumn.Name = "EnderecoDataGridViewTextBoxColumn"
        Me.EnderecoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TelefoneDataGridViewTextBoxColumn
        '
        Me.TelefoneDataGridViewTextBoxColumn.DataPropertyName = "telefone"
        Me.TelefoneDataGridViewTextBoxColumn.HeaderText = "telefone"
        Me.TelefoneDataGridViewTextBoxColumn.Name = "TelefoneDataGridViewTextBoxColumn"
        Me.TelefoneDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EmailDataGridViewTextBoxColumn
        '
        Me.EmailDataGridViewTextBoxColumn.DataPropertyName = "email"
        Me.EmailDataGridViewTextBoxColumn.HeaderText = "email"
        Me.EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        Me.EmailDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frm_empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dgv_empresas)
        Me.Name = "frm_empresa"
        Me.Text = "Empresas"
        CType(Me.dgv_empresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbempresasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbempresasBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_empresas As DataGridView
    Friend WithEvents btn_novo As Button
    Friend WithEvents PontoOfflineVBDataSet1 As PontoOfflineVBDataSet
    Friend WithEvents TbempresasBindingSource As BindingSource
    Friend WithEvents Tb_empresasTableAdapter As PontoOfflineVBDataSetTableAdapters.tb_empresasTableAdapter
    Friend WithEvents PontoOfflineVBDataSet As PontoOfflineVBDataSet
    Friend WithEvents PontoOfflineVBDataSetBindingSource As BindingSource
    Friend WithEvents PontoOfflineVBDataSet2 As PontoOfflineVBDataSet
    Friend WithEvents PontoOfflineVBDataSet2BindingSource As BindingSource
    Friend WithEvents PontoOfflineVBDataSet3 As PontoOfflineVBDataSet
    Friend WithEvents TbempresasBindingSource1 As BindingSource
    Friend WithEvents Tb_empresasTableAdapter1 As PontoOfflineVBDataSetTableAdapters.tb_empresasTableAdapter
    Friend WithEvents CnpjDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RazaosocialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NomefantasiaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InscestadualDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EnderecoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TelefoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
