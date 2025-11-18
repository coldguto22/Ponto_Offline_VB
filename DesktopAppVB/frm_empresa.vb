Imports Oracle.ManagedDataAccess.Client

Public Class frm_empresa

    ' Carrega dados usando Oracle direto - TABELA: EMPRESA
    Private Sub CarregarEmpresas()
        Try
            Dim sql As String = "SELECT CNPJ, RAZAO_SOCIAL FROM EMPRESA ORDER BY RAZAO_SOCIAL"
            Dim dt As New DataTable()
            Dim reader As OracleDataReader = ExecutarConsulta(sql)

            If reader IsNot Nothing Then
                dt.Load(reader)
                dgv_empresas.DataSource = dt
                LimparDataReader(reader)
                ' Configurar aparência das colunas após o binding
                ConfigurarColunas()
            End If

            Me.Text = $"Empresas - Total: {dgv_empresas.Rows.Count} registros"
        Catch ex As Exception
            MessageBox.Show($"Erro ao carregar empresas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Configura a aparência das colunas após o binding
    Private Sub ConfigurarColunas()
        Try
            If dgv_empresas.Columns.Count > 0 Then
                ' Configurar larguras e textos de cabeçalho
                If dgv_empresas.Columns.Contains("CNPJ") Then
                    dgv_empresas.Columns("CNPJ").HeaderText = "CNPJ"
                    dgv_empresas.Columns("CNPJ").Width = 150
                End If

                If dgv_empresas.Columns.Contains("RAZAO_SOCIAL") Then
                    dgv_empresas.Columns("RAZAO_SOCIAL").HeaderText = "RAZÃO SOCIAL"
                    dgv_empresas.Columns("RAZAO_SOCIAL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            End If
        Catch ex As Exception
            ' Ignorar erros de configuração de colunas
        End Try
    End Sub

    ' Atualiza o grid recarregando os dados
    Private Sub AtualizarGrid()
        CarregarEmpresas()
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        cad_empresa.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub frm_empresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Habilitar auto-geração de colunas
        dgv_empresas.AutoGenerateColumns = True

        ' Carrega empresas usando abordagem Oracle direta
        CarregarEmpresas()
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click
        If dgv_empresas.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione uma empresa para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the selected row is the new row placeholder
        If dgv_empresas.SelectedRows(0).IsNewRow Then
            MessageBox.Show("Não é possível editar a linha de novo registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cnpjSelecionado As String = dgv_empresas.SelectedRows(0).Cells("CNPJ").Value.ToString()
        cad_empresa.txt_cnpj.Text = cnpjSelecionado
        cad_empresa.txt_cnpj_LostFocus(Nothing, Nothing)
        cad_empresa.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        If dgv_empresas.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione uma empresa para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the selected row is the new row placeholder
        If dgv_empresas.SelectedRows(0).IsNewRow Then
            MessageBox.Show("Não é possível excluir a linha de novo registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cnpjSelecionado As String = dgv_empresas.SelectedRows(0).Cells("CNPJ").Value.ToString()

        If MessageBox.Show($"Confirma a exclusão da empresa CNPJ: {cnpjSelecionado}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                sql = $"DELETE FROM EMPRESA WHERE CNPJ='{cnpjSelecionado}'"

                If ExecutarComando(sql) Then
                    AtualizarGrid()
                    MessageBox.Show("Empresa excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show($"Erro ao excluir empresa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgv_empresas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_empresas.CellContentClick

    End Sub
End Class
