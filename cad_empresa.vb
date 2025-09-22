Imports System.IO

Public Class cad_empresa
    Private Sub Btn_concluir_Click(sender As Object, e As EventArgs) Handles btn_concluir.Click
        Try
            If String.IsNullOrWhiteSpace(txt_cnpj.Text) Then
                MsgBox("Informe o CNPJ.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                txt_cnpj.Focus()
                Exit Sub
            End If

            Dim cnpj As String = txt_cnpj.Text
            Dim razao As String = txt_razao.Text
            Dim fantasia As String = txt_fantasia.Text
            Dim insc As String = txt_insc.Text
            Dim endereco As String = txt_endereco.Text
            Dim telefone As String = txt_telefone.Text
            Dim email As String = txt_email.Text

            sql = "SELECT * FROM tb_empresas WHERE cnpj='" & cnpj & "'"
            rs = db.Execute(sql)

            If rs.EOF = True Then
                sql = "INSERT INTO tb_empresas (cnpj, razao_social, nome_fantasia, insc_estadual, endereco, telefone, email) " &
                      "VALUES ('" & cnpj & "', '" & razao & "', '" & fantasia & "', '" & insc & "', '" & endereco & "', '" & telefone & "', '" & email & "')"
                rs = db.Execute(UCase(sql))
                Limpar_cadastro()
            Else
                MsgBox("Empresa Já Cadastrada!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                txt_cnpj.Focus()
            End If

        Catch ex As Exception
            MsgBox("Erro ao Gravar! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub txt_cnpj_LostFocus(sender As Object, e As EventArgs)
        Try
            sql = $"select * from tb_empresas where cnpj='{txt_cnpj.Text}'"
            rs = db.Execute(sql)
            If rs.EOF = False Then
                txt_razao.Text = rs.Fields("razao_social").Value
                txt_fantasia.Text = rs.Fields("nome_fantasia").Value
                txt_insc.Text = rs.Fields("insc_estadual").Value
                txt_endereco.Text = rs.Fields("endereco").Value
                txt_telefone.Text = rs.Fields("telefone").Value
                txt_email.Text = rs.Fields("email").Value
            Else
                txt_razao.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro ao Consultar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub txt_cnpj_DoubleClick(sender As Object, e As EventArgs)
        Limpar_cadastro()
    End Sub

    Private Sub txt_cnpj_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
