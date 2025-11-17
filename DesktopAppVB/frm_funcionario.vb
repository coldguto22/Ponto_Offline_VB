Imports Oracle.ManagedDataAccess.Client

Public Class frm_funcionario

    ' Unifica a atualização do grid usando Oracle
    Private Sub CarregarFuncionarios()
        Try
            Dim sql As String = "SELECT cpf, nome, email, cargo, ativo, data_cadastro FROM tb_funcionarios ORDER BY nome"
            Dim dt As New DataTable()
            Dim reader As OracleDataReader = ExecutarConsulta(sql)

            If reader IsNot Nothing Then
                dt.Load(reader)
                dgv_funcionarios.DataSource = dt
                LimparDataReader(reader)
            End If

            Me.Text = $"Funcionários - Total: {dgv_funcionarios.Rows.Count} registros"
        Catch ex As Exception
            MessageBox.Show($"Erro ao carregar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' AtualizarGrid agora apenas chama CarregarFuncionarios
    Private Sub AtualizarGrid()
        CarregarFuncionarios()
    End Sub

    Private Sub Btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        Cad_funcionario.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub Frm_funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarFuncionarios()
    End Sub

    Private Sub Btn_atualizar_Click(sender As Object, e As EventArgs) Handles btn_atualizar.Click
        If dgv_funcionarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um funcionário para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cpfSelecionado As String = dgv_funcionarios.SelectedRows(0).Cells("cpf").Value.ToString()
        Cad_funcionario.PreencherPorCPF(cpfSelecionado)
        Cad_funcionario.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub Btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        If dgv_funcionarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um funcionário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cpfSelecionado As String = dgv_funcionarios.SelectedRows(0).Cells("cpf").Value.ToString()

        If MessageBox.Show($"Confirma a exclusão do funcionário CPF: {cpfSelecionado}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                sql = $"DELETE FROM tb_funcionarios WHERE cpf='{cpfSelecionado}'"

                If ExecutarComando(sql) Then
                    AtualizarGrid()
                    MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show($"Erro ao excluir funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PontoOfflineDataSetOracleBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles PontoOfflineDataSetOracleBindingSource.CurrentChanged

    End Sub
End Class