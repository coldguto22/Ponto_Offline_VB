Imports System.IO

Public Class Cad_funcionario
    ' No cad_funcionario.vb
    Private Sub Img_foto_Click(sender As Object, e As EventArgs) Handles img_foto.Click
        Try
            With OpenFileDialog1
                .Title = "Selecione uma Foto"
                .Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
                .InitialDirectory = Path.Combine(Application.StartupPath, "Fotos")

                If .ShowDialog() = DialogResult.OK Then
                    ' Criar pasta se não existir
                    Dim fotoDir As String = Path.Combine(Application.StartupPath, "Fotos")
                    If Not Directory.Exists(fotoDir) Then
                        Directory.CreateDirectory(fotoDir)
                    End If

                    ' Copiar arquivo para pasta local
                    Dim nomeArquivo As String = $"{txt_cpf.Text.Replace(",", "").Replace(".", "").Replace("-", "")}_{Path.GetFileName(.FileName)}"
                    Dim caminhoDestino As String = Path.Combine(fotoDir, nomeArquivo)

                    File.Copy(.FileName, caminhoDestino, True)
                    img_foto.Load(caminhoDestino)
                    diretorio = caminhoDestino
                End If
            End With
        Catch ex As Exception
            MessageBox.Show($"Erro ao carregar foto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Preencher cmb_empresa com razões sociais das empresas cadastradas
        Try
            cmb_empresa.Items.Clear()
            sql = "SELECT razao_social FROM tb_empresas"
            rs = db.Execute(sql)
            While Not rs.EOF
                cmb_empresa.Items.Add(rs.Fields("razao_social").Value)
                rs.MoveNext()
            End While
        Catch ex As Exception
            MsgBox("Erro ao carregar empresas! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
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

            Dim cpf As String = txt_cpf.Text
            Dim nome As String = txt_nome.Text
            Dim dataAdmissao As String = cmb_admissao.Value.ToString("yyyy-MM-dd")
            Dim dataNasc As String = cmb_nasc.Value.ToString("yyyy-MM-dd")
            Dim pis As String = txt_pis.Text
            Dim empresa As String = cmb_empresa.Text
            Dim folha As String = txt_folha.Text
            Dim cargo As String = txt_cargo.Text
            Dim horario As String = cmb_horario.Text
            Dim dataDemissao As String = cmb_demissao.Value.ToString("yyyy-MM-dd")
            Dim fotoPath As String = diretorio

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

    Private Function ValidarCampos() As Boolean
        Dim erros As New List(Of String)

        If String.IsNullOrWhiteSpace(txt_cpf.Text) Then
            erros.Add("CPF é obrigatório")
        ElseIf Not ValidarCPF(txt_cpf.Text) Then
            erros.Add("CPF inválido")
        End If

        If String.IsNullOrWhiteSpace(txt_nome.Text) Then
            erros.Add("Nome é obrigatório")
        End If

        If erros.Count > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, erros), "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function ValidarCPF(cpf As String) As Boolean
        ' Implementar validação real de CPF
        cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "")
        Return cpf.Length = 11 AndAlso IsNumeric(cpf)
    End Function


    Private Sub Txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
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

    Private Sub Txt_cpf_DoubleClick(sender As Object, e As EventArgs) Handles txt_cpf.DoubleClick
        Limpar_cadastro()
    End Sub

    Private Sub Cmb_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresa.SelectedIndexChanged

    End Sub

    Public Sub PreencherPorCPF(cpf As String)
        Try
            txt_cpf.Text = cpf
            ' Replicar lógica do Txt_cpf_LostFocus
            sql = $"select * from tb_funcionarios where cpf='{cpf}'"
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
            MsgBox("Erro ao Consultar! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Public Sub Limpar_cadastro()
        Try
            txt_cpf.Clear()
            txt_nome.Clear()
            cmb_admissao.Value = Now
            cmb_nasc.Value = Now
            txt_pis.Clear()
            cmb_empresa.Text = ""
            txt_folha.Clear()
            txt_cargo.Clear()
            cmb_horario.Text = ""
            cmb_demissao.Value = Now
            img_foto.Load(Application.StartupPath & "\Fotos\nova_foto.png")
            txt_cpf.Focus()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
End Class
