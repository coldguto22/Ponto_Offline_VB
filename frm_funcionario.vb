Public Class frm_funcionario
    Private Sub frm_funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PontoOfflineVBDataSet.tb_funcionarios' table. You can move, or remove it, as needed.
        Me.Tb_funcionariosTableAdapter.Fill(Me.PontoOfflineVBDataSet.tb_funcionarios)
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        cad_funcionario.ShowDialog()
    End Sub

    Private Sub dgv_funcionarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_funcionarios.CellContentClick

    End Sub
End Class