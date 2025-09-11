Public Class frm_menu
    ' Menu principal do sistema estilo Secullum Ponto Offline
    Private Sub FuncionárioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuncionárioToolStripMenuItem.Click
        frm_funcionario.Show()
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpresaToolStripMenuItem.Click
        ' Abrir formulário de cadastro de empresas
        'frm_empresa.ShowDialog()
    End Sub

    Private Sub HorárioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HorárioToolStripMenuItem.Click
        ' Abrir formulário de horários
        'frm_horario.ShowDialog()
    End Sub

    Private Sub EncerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncerrarToolStripMenuItem.Click
        If MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class