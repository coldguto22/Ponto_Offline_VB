Public Class frm_menu
    ' Menu principal do sistema estilo Secullum Ponto Offline
    Private Sub FuncionárioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuncionárioToolStripMenuItem.Click
        frm_funcionario.Show()
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpresaToolStripMenuItem.Click
        ' Abrir formulário de cadastro de empresas
        frm_empresa.Show()
    End Sub

    Private Sub EncerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncerrarToolStripMenuItem.Click
        If MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub PlataformaWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlataformaWebToolStripMenuItem.Click
        Try
            ' Abrir navegador padrão na plataforma web
            Dim url As String = "http://localhost:8080/index.html"
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show($"Erro ao abrir plataforma web: {ex.Message}" & vbCrLf & vbCrLf & "Certifique-se de que o servidor web está rodando em http://localhost:8080", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class