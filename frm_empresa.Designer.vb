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
        Me.CnpjDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazaosocialDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TbempresasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PontoOfflineVBDataSet = New Ponto_Offline_VB.PontoOfflineVBDataSet()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.Tb_empresasTableAdapter = New Ponto_Offline_VB.PontoOfflineVBDataSetTableAdapters.tb_empresasTableAdapter()
        CType(Me.dgv_empresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbempresasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_empresas
        '
        Me.dgv_empresas.AllowUserToAddRows = False
        Me.dgv_empresas.AllowUserToDeleteRows = False
        Me.dgv_empresas.AllowUserToResizeColumns = False
        Me.dgv_empresas.AllowUserToResizeRows = False
        Me.dgv_empresas.AutoGenerateColumns = False
        Me.dgv_empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_empresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CnpjDataGridViewTextBoxColumn, Me.RazaosocialDataGridViewTextBoxColumn})
        Me.dgv_empresas.DataSource = Me.TbempresasBindingSource
        Me.dgv_empresas.Location = New System.Drawing.Point(12, 51)
        Me.dgv_empresas.Name = "dgv_empresas"
        Me.dgv_empresas.ReadOnly = True
        Me.dgv_empresas.Size = New System.Drawing.Size(760, 350)
        Me.dgv_empresas.TabIndex = 0
        '
        'CnpjDataGridViewTextBoxColumn
        '
        Me.CnpjDataGridViewTextBoxColumn.DataPropertyName = "cnpj"
        Me.CnpjDataGridViewTextBoxColumn.HeaderText = "CNPJ"
        Me.CnpjDataGridViewTextBoxColumn.Name = "CnpjDataGridViewTextBoxColumn"
        Me.CnpjDataGridViewTextBoxColumn.ReadOnly = True
        Me.CnpjDataGridViewTextBoxColumn.Width = 200
        '
        'RazaosocialDataGridViewTextBoxColumn
        '
        Me.RazaosocialDataGridViewTextBoxColumn.DataPropertyName = "razao_social"
        Me.RazaosocialDataGridViewTextBoxColumn.HeaderText = "RAZÃO SOCIAL"
        Me.RazaosocialDataGridViewTextBoxColumn.Name = "RazaosocialDataGridViewTextBoxColumn"
        Me.RazaosocialDataGridViewTextBoxColumn.ReadOnly = True
        Me.RazaosocialDataGridViewTextBoxColumn.Width = 450
        '
        'TbempresasBindingSource
        '
        Me.TbempresasBindingSource.DataMember = "tb_empresas"
        Me.TbempresasBindingSource.DataSource = Me.PontoOfflineVBDataSet
        '
        'PontoOfflineVBDataSet
        '
        Me.PontoOfflineVBDataSet.DataSetName = "PontoOfflineVBDataSet"
        Me.PontoOfflineVBDataSet.Namespace = "http://tempuri.org/PontoOfflineVBDataSet.xsd"
        Me.PontoOfflineVBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'btn_editar
        '
        Me.btn_editar.Location = New System.Drawing.Point(154, 17)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(134, 28)
        Me.btn_editar.TabIndex = 28
        Me.btn_editar.Text = "EDITAR"
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Location = New System.Drawing.Point(319, 17)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(134, 28)
        Me.btn_excluir.TabIndex = 29
        Me.btn_excluir.Text = "EXCLUIR"
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'Tb_empresasTableAdapter
        '
        Me.Tb_empresasTableAdapter.ClearBeforeFill = True
        '
        'frm_empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_editar)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dgv_empresas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_empresa"
        Me.Text = "Empresas"
        CType(Me.dgv_empresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbempresasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineVBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_empresas As DataGridView
    Friend WithEvents btn_novo As Button
    Friend WithEvents PontoOfflineVBDataSet As Ponto_Offline_VB.PontoOfflineVBDataSet
    Friend WithEvents TbempresasBindingSource As BindingSource
    Friend WithEvents Tb_empresasTableAdapter As Ponto_Offline_VB.PontoOfflineVBDataSetTableAdapters.tb_empresasTableAdapter
    Friend WithEvents CnpjDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RazaosocialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents btn_editar As Button
    Friend WithEvents btn_excluir As Button
End Class
