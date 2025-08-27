Public Class frm_menu
    Private Sub GereciamentoDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GereciamentoDeClientesToolStripMenuItem.Click

    End Sub

    Private Sub CadastroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastroToolStripMenuItem.Click
        Try
            Form1.ShowDialog()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculadoraToolStripMenuItem.Click
        Try
            Process.Start("calc.exe")
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcelToolStripMenuItem.Click
        Try
            Process.Start("excel.exe")
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub BlocoDeNotasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlocoDeNotasToolStripMenuItem.Click
        Try
            Process.Start("notepad.exe")
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub SairDoProgramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairDoProgramaToolStripMenuItem.Click
        Try
            resp = MsgBox("Deseja Sair?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "AVISO")
            If resp = MsgBoxResult.Yes Then
                Application.Exit()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub GerenciarListaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GerenciarListaToolStripMenuItem.Click
        Try
            Process.Start(Application.StartupPath & "\bat\cadastro.bat")
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
End Class