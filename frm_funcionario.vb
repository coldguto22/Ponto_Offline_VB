Public Class frm_funcionario

    ' No frm_funcionario.vb
    Private Sub AtualizarGrid()
        Try
            Me.Tb_funcionariosTableAdapter.Fill(Me.PontoOfflineVBDataSet.tb_funcionarios)
            ' Opcional: Atualizar título do form com contador
            Me.Text = $"Funcionários - Total: {dgv_funcionarios.Rows.Count} registros"
        Catch ex As Exception
            MessageBox.Show($"Erro ao atualizar lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Modificar o evento existente do btn_novo para incluir atualização
    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        cad_funcionario.ShowDialog()
        ' Atualizar grid após fechar o formulário de cadastro
        AtualizarGrid()
    End Sub

    ' Adicionar este método no Form_Load para carregar inicialmente
    Private Sub frm_funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PontoOfflineVBDataSet1.tb_funcionarios' table. You can move, or remove it, as needed.
        Me.Tb_funcionariosTableAdapter.Fill(Me.PontoOfflineVBDataSet1.tb_funcionarios)
        Me.Tb_funcionariosTableAdapter.Fill(Me.PontoOfflineVBDataSet.tb_funcionarios)
        AtualizarGrid() ' Chama para definir o título com contador
    End Sub


End Class