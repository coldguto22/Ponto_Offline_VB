Public Class cad_funcionario
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
        'Carregar_dados() 'Removido, método não existe mais
        'carregar_campos() 'Removido, método não existe mais
    End Sub

    ' PSEUDOCODE / PLAN (detailed):
    ' 1. Validate required fields (cpf at minimum). If missing, show message and exit.
    ' 2. Sanitize input to avoid SQL syntax issues (escape single quotes).
    ' 3. Query the database to see if a record with the given CPF already exists.
    ' 4. If not found:
    '    a. Build an INSERT statement including cpf, nome, data_nasc, fone, email, foto.
    '    b. Format the date value in an invariant format (yyyy-MM-dd) for SQL.
    '    c. Execute the INSERT on the existing db connection.
    '    d. Optionally call carregar_voz and audio.speak, refresh grid/list and clear fields.
    ' 5. If found: notify user that the client already exists and set focus to cpf.
    ' 6. Handle exceptions: show an error message and do not crash.
    ' 7. Provide a small helper SQLSafe to escape single quotes and handle Nulls.
    '
    ' IMPLEMENTATION: Sub linked to the button's Click event and helper function below.

    Private Sub Btn_concluir_Click(sender As Object, e As EventArgs) Handles btn_concluir.Click
        Try
            If String.IsNullOrWhiteSpace(txt_cpf.Text) Then
                MsgBox("Informe o CPF.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                txt_cpf.Focus()
                Exit Sub
            End If

            Dim cpf As String = SQLSafe(txt_cpf.Text)
            Dim nome As String = SQLSafe(txt_nome.Text)
            Dim dataAdmissao As String = cmb_admissao.Value.ToString("yyyy-MM-dd")
            Dim dataNasc As String = cmb_nasc.Value.ToString("yyyy-MM-dd")
            Dim pis As String = SQLSafe(txt_pis.Text)
            Dim empresa As String = SQLSafe(cmb_empresa.Text)
            Dim folha As String = SQLSafe(txt_folha.Text)
            Dim cargo As String = SQLSafe(txt_cargo.Text)
            Dim horario As String = SQLSafe(cmb_horario.Text)
            Dim dataDemissao As String = cmb_demissao.Value.ToString("yyyy-MM-dd")
            Dim fotoPath As String = SQLSafe(diretorio)

            sql = "SELECT * FROM tb_funcionarios WHERE cpf='" & cpf & "'"
            rs = db.Execute(sql)

            If rs.EOF = True Then
                sql = "INSERT INTO tb_funcionarios (cpf, nome, data_admissao, data_nasc, pis, empresa, folha, cargo, horario, data_demissao, foto) " &
                      "VALUES ('" & cpf & "', '" & nome & "', '" & dataAdmissao & "', '" & dataNasc & "', '" & pis & "', '" & empresa & "', '" & folha & "', '" & cargo & "', '" & horario & "', '" & dataDemissao & "', '" & fotoPath & "')"
                rs = db.Execute(UCase(sql))
                'Carregar_funcionarios() 'Descomente se o DataGridView existir
                Limpar_cadastro()
            Else
                MsgBox("Funcionário Já Cadastrado!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                txt_cpf.Focus()
            End If

        Catch ex As Exception
            MsgBox("Erro ao Gravar! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    ' Helper to escape single quotes for inline SQL usage.
    Private Function SQLSafe(value As String) As String
        If value Is Nothing Then Return ""
        Return value.Replace("'", "''").Trim()
    End Function

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            sql = $"select * from tb_funcionarios where cpf='{txt_cpf.Text}'"
            rs = db.Execute(sql)
            If rs.EOF = False Then
                txt_nome.Text = rs.Fields("nome").Value
                cmb_admissao.Value = rs.Fields("data_admissao").Value
                cmb_nasc.Value = rs.Fields("data_nasc").Value
                txt_pis.Text = rs.Fields("pis").Value
                cmb_empresa.Text = rs.Fields("empresa").Value
                txt_folha.Text = rs.Fields("folha").Value
                txt_cargo.Text = rs.Fields("cargo").Value
                cmb_horario.Text = rs.Fields("horario").Value
                cmb_demissao.Value = rs.Fields("data_demissao").Value
                img_foto.Load(rs.Fields("foto").Value)
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

End Class
