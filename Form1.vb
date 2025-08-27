Public Class Form1
    Private Sub Img_foto_Click(sender As Object, e As EventArgs) Handles img_foto.Click
        Try
            With OpenFileDialog1
                .Title = "Selecione uma Foto"
                .InitialDirectory = Application.StartupPath & "\Fotos\"
                .ShowDialog()
                diretorio = .FileName
                img_foto.Load(diretorio)
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conecta_banco()
        Carregar_dados()
        carregar_campos()
    End Sub

    Private Sub btn_gravar_Click(sender As Object, e As EventArgs) Handles btn_gravar.Click
        Try
            sql = $"select * from tb_clientes where 
                  cpf='{txt_cpf.Text}'"
            rs = db.Execute(sql)
            If rs.EOF = True Then 'Se não existir o cpf na tabela
                sql = $"insert into tb_clientes (cpf,nome,data_nasc,fone,email,foto)
                       values ('{txt_cpf.Text}','{txt_nome.Text}',
                               '{cmb_data.Value.ToShortDateString}',
                               '{txt_fone.Text}','{txt_email.Text}',
                               '{diretorio}')"
                rs = db.Execute(UCase(sql))
                carregar_voz()
                audio.speak("Cliente " & txt_nome.Text & " gravado com sucesso")
                'MsgBox("Cliente Cadastrado!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AVISO")
                Carregar_dados()
                Limpar_cadastro()
            Else
                MsgBox("Cliente Já Cadastrado!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                txt_cpf.Focus()
            End If


        Catch ex As Exception
            MsgBox("Erro ao Gravar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            sql = $"select * from tb_clientes 
                 where cpf='{txt_cpf.Text}'"
            rs = db.Execute(sql)
            If rs.EOF = False Then
                txt_nome.Text = rs.Fields(2).Value
                cmb_data.Value = rs.Fields(3).Value
                txt_fone.Text = rs.Fields(4).Value
                txt_email.Text = rs.Fields(5).Value
                img_foto.Load(rs.Fields(6).Value)
            Else
                txt_nome.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro ao Consultar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub txt_cpf_DoubleClick(sender As Object, e As EventArgs) Handles txt_cpf.DoubleClick
        Limpar_cadastro()
    End Sub

    Private Sub txt_busca_TextChanged(sender As Object, e As EventArgs) Handles txt_busca.TextChanged
        Try
            With dgv_dados
                sql = $"select * from tb_clientes where {cmb_campo.Text} 
                        like '{txt_busca.Text}%' order by nome asc"
                rs = db.Execute(sql)
                cont = 0
                .Rows.Clear()
                Do While rs.EOF = False
                    cont = cont + 1
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, Nothing, Nothing)
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


End Class
