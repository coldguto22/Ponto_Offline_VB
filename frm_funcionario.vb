Public Class frm_funcionario
    Private Sub frm_funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carregar_funcionarios()
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        cad_funcionario.ShowDialog()
        Carregar_funcionarios() ' Atualiza a lista após cadastro
    End Sub

    Sub Carregar_funcionarios()
        Try
            dgv_funcionarios.Rows.Clear()
            sql = "SELECT * FROM tb_funcionarios ORDER BY nome ASC"
            rs = db.Execute(sql)
            Do While rs.EOF = False
                dgv_funcionarios.Rows.Add(
                    rs.Fields("cpf").Value,
                    rs.Fields("nome").Value,
                    rs.Fields("cargo").Value,
                    rs.Fields("empresa").Value
                )
                rs.MoveNext()
            Loop
        Catch ex As Exception
            MsgBox("Erro ao carregar funcionários!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub
End Class