Imports Oracle.ManagedDataAccess.Client

Public Class frm_funcionario

    ' Carrega dados usando Oracle direto - TABELA: FUNCIONARIO
    Private Sub CarregarFuncionarios()
        Try
            ' TABELA: FUNCIONARIO, COLUNAS: CPF, NOME, CARGO
            ' Nota: Removido EMAIL (não existe na tabela FUNCIONARIO) e DATA_CADASTRO
            ' Adicionado ATIVO se necessário
            Dim sql As String = "SELECT CPF, NOME, CARGO FROM FUNCIONARIO ORDER BY NOME"
            Dim dt As New DataTable()
            Dim reader As OracleDataReader = ExecutarConsulta(sql)

            If reader IsNot Nothing Then
                dt.Load(reader)
                dgv_funcionarios.DataSource = dt
                LimparDataReader(reader)

                ' Configurar aparência das colunas após o binding
                ConfigurarColunas()
            End If

            Me.Text = $"Funcionários - Total: {dgv_funcionarios.Rows.Count} registros"
        Catch ex As Exception
            MessageBox.Show($"Erro ao carregar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Configura a aparência das colunas após o binding
    Private Sub ConfigurarColunas()
        Try
            If dgv_funcionarios.Columns.Count > 0 Then
                ' Configurar larguras e textos de cabeçalho
                If dgv_funcionarios.Columns.Contains("CPF") Then
                    dgv_funcionarios.Columns("CPF").HeaderText = "CPF"
                    dgv_funcionarios.Columns("CPF").Width = 150
                End If

                If dgv_funcionarios.Columns.Contains("NOME") Then
                    dgv_funcionarios.Columns("NOME").HeaderText = "NOME"
                    dgv_funcionarios.Columns("NOME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

                If dgv_funcionarios.Columns.Contains("CARGO") Then
                    dgv_funcionarios.Columns("CARGO").HeaderText = "CARGO"
                    dgv_funcionarios.Columns("CARGO").Width = 150
                End If
            End If
        Catch ex As Exception
            ' Ignorar erros de configuração de colunas
        End Try
    End Sub

    ' Atualiza o grid recarregando os dados
    Private Sub AtualizarGrid()
        CarregarFuncionarios()
    End Sub

    Private Sub Btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        Cad_funcionario.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub Frm_funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Limpar colunas do designer e habilitar auto-geração
        dgv_funcionarios.Columns.Clear()
        dgv_funcionarios.AutoGenerateColumns = True

        ' Carrega funcionários usando abordagem Oracle direta
        CarregarFuncionarios()
    End Sub

    Private Sub Btn_atualizar_Click(sender As Object, e As EventArgs) Handles btn_atualizar.Click
        If dgv_funcionarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um funcionário para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the selected row is the new row placeholder
        If dgv_funcionarios.SelectedRows(0).IsNewRow Then
            MessageBox.Show("Não é possível atualizar a linha de novo registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cpfSelecionado As String = dgv_funcionarios.SelectedRows(0).Cells("CPF").Value.ToString()
        Cad_funcionario.PreencherPorCPF(cpfSelecionado)
        Cad_funcionario.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub Btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        If dgv_funcionarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um funcionário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the selected row is the new row placeholder
        If dgv_funcionarios.SelectedRows(0).IsNewRow Then
            MessageBox.Show("Não é possível excluir a linha de novo registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cpfSelecionado As String = dgv_funcionarios.SelectedRows(0).Cells("CPF").Value.ToString()

        If MessageBox.Show($"Confirma a exclusão do funcionário CPF: {cpfSelecionado}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                ' TABELA: FUNCIONARIO
                sql = $"DELETE FROM FUNCIONARIO WHERE CPF='{cpfSelecionado}'"

                If ExecutarComando(sql) Then
                    AtualizarGrid()
                    MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show($"Erro ao excluir funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class