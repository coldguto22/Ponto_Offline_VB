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
    Private Sub Btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        Cad_funcionario.ShowDialog()
        ' Atualizar grid após fechar o formulário de cadastro
        AtualizarGrid()
    End Sub

    ' Adicionar este método no Form_Load para carregar inicialmente
    Private Sub Frm_funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PontoOfflineVBDataSet1.tb_funcionarios' table. You can move, or remove it, as needed.
        Me.Tb_funcionariosTableAdapter.Fill(Me.PontoOfflineVBDataSet1.tb_funcionarios)
        Me.Tb_funcionariosTableAdapter.Fill(Me.PontoOfflineVBDataSet.tb_funcionarios)
        AtualizarGrid() ' Chama para definir o título com contador
    End Sub

    Private Sub Btn_atualizar_Click(sender As Object, e As EventArgs) Handles btn_atualizar.Click
        If dgv_funcionarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um funcionário para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim cpfSelecionado As String = dgv_funcionarios.SelectedRows(0).Cells("CpfDataGridViewTextBoxColumn").Value.ToString()
        Cad_funcionario.PreencherPorCPF(cpfSelecionado)
        Cad_funcionario.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub Btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        If dgv_funcionarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um funcionário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim cpfSelecionado As String = dgv_funcionarios.SelectedRows(0).Cells("CpfDataGridViewTextBoxColumn").Value.ToString()
        If MessageBox.Show($"Confirma a exclusão do funcionário CPF: {cpfSelecionado}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                sql = $"DELETE FROM tb_funcionarios WHERE cpf='{cpfSelecionado}'"
                db.Execute(sql)
                AtualizarGrid()
                MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show($"Erro ao excluir funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
''``````