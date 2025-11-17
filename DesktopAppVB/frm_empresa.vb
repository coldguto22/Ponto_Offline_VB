Imports Oracle.ManagedDataAccess.Client

Public Class frm_empresa
    ' Carrega dados usando Oracle
    Private Sub CarregarEmpresas()
        Try
            Dim sql As String = "SELECT cnpj, razao_social FROM tb_empresas ORDER BY razao_social"
            Dim dt As New DataTable()
            Dim reader As OracleDataReader = ExecutarConsulta(sql)

            If reader IsNot Nothing Then
                dt.Load(reader)
                dgv_empresas.DataSource = dt
                LimparDataReader(reader)
            End If

            Me.Text = $"Empresas - Total: {dgv_empresas.Rows.Count} registros"
        Catch ex As Exception
            MessageBox.Show($"Erro ao atualizar lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AtualizarGrid()
        CarregarEmpresas()
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        cad_empresa.ShowDialog()
        AtualizarGrid()
    End Sub

    Private Sub frm_empresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarEmpresas()
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click
        If dgv_empresas.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione uma empresa para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cnpjSelecionado As String = dgv_empresas.SelectedRows(0).Cells("cnpj").Value.ToString()
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

        Dim cnpjSelecionado As String = dgv_empresas.SelectedRows(0).Cells("cnpj").Value.ToString()

        If MessageBox.Show($"Confirma a exclusão da empresa CNPJ: {cnpjSelecionado}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                sql = $"DELETE FROM tb_empresas WHERE cnpj='{cnpjSelecionado}'"

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
