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
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.PontoOfflineDataSet_Oracle = New Ponto_Offline_VB.PontoOfflineDataSet_Oracle()
        Me.PontoOfflineDataSetOracleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgv_empresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineDataSet_Oracle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PontoOfflineDataSetOracleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgv_empresas.DataSource = Me.PontoOfflineDataSetOracleBindingSource
        Me.dgv_empresas.Location = New System.Drawing.Point(12, 51)
        Me.dgv_empresas.Name = "dgv_empresas"
        Me.dgv_empresas.ReadOnly = True
        Me.dgv_empresas.Size = New System.Drawing.Size(760, 350)
        Me.dgv_empresas.TabIndex = 0
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
        'PontoOfflineDataSet_Oracle
        '
        Me.PontoOfflineDataSet_Oracle.DataSetName = "PontoOfflineDataSet_Oracle"
        Me.PontoOfflineDataSet_Oracle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PontoOfflineDataSetOracleBindingSource
        '
        Me.PontoOfflineDataSetOracleBindingSource.DataSource = Me.PontoOfflineDataSet_Oracle
        Me.PontoOfflineDataSetOracleBindingSource.Position = 0
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
        CType(Me.PontoOfflineDataSet_Oracle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PontoOfflineDataSetOracleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
