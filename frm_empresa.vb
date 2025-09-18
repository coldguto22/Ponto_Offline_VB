Public Class frm_empresa
    ' Similar ao frm_funcionario
    Private Sub AtualizarGrid()
        Try
            Me.Tb_empresasTableAdapter.Fill(Me.PontoOfflineVBDataSet1.tb_empresas)
            Me.Text = $"Empresas - Total: {dgv_empresas.Rows.Count} registros"
        Catch ex As Exception
            MessageBox.Show($"Erro ao atualizar lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        cad_empresa.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub frm_empresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PontoOfflineVBDataSet3.tb_empresas' table. You can move, or remove it, as needed.
        Me.Tb_empresasTableAdapter1.Fill(Me.PontoOfflineVBDataSet3.tb_empresas)
        'TODO: This line of code loads data into the 'PontoOfflineVBDataSet1.tb_empresas' table. You can move, or remove it, as needed.
        Me.Tb_empresasTableAdapter.Fill(Me.PontoOfflineVBDataSet1.tb_empresas)
        AtualizarGrid()
    End Sub

    Private Sub dgv_empresas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_empresas.CellContentClick

    End Sub
End Class
