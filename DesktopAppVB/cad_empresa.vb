Imports System.IO

Public Class cad_empresa
    Dim logoPath As String = ""

    Private Sub Img_logo_Click(sender As Object, e As EventArgs) Handles img_logo.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.Title = "Selecione o Logo da Empresa"
            ofd.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Logos")

            If ofd.ShowDialog() = DialogResult.OK Then
                Dim logoDir As String = Path.Combine(Application.StartupPath, "Logos")
                If Not Directory.Exists(logoDir) Then
                    Directory.CreateDirectory(logoDir)
                End If
                Dim nomeArquivo As String = $"{txt_cnpj.Text.Replace("/", "").Replace(".", "").Replace("-", "")}_{Path.GetFileName(ofd.FileName)}"
                Dim caminhoDestino As String = Path.Combine(logoDir, nomeArquivo)
                File.Copy(ofd.FileName, caminhoDestino, True)
                img_logo.ImageLocation = caminhoDestino
                logoPath = caminhoDestino
            End If
        Catch ex As Exception
            MsgBox($"Erro ao carregar logo: {ex.Message}", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Function ValidarCNPJ(cnpj As String) As Boolean
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "")
        ' Apenas verifica se está preenchido e tem 14 dígitos
        Return Not String.IsNullOrWhiteSpace(cnpj) AndAlso cnpj.Length = 14 AndAlso IsNumeric(cnpj)
    End Function

    Private Sub Btn_concluir_Click(sender As Object, e As EventArgs) Handles btn_concluir.Click
        Try
            If String.IsNullOrWhiteSpace(txt_cnpj.Text) OrElse ValidarCNPJ(txt_cnpj.Text) Then
                MsgBox("Informe um CNPJ válido.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
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
            Dim logo As String = logoPath

            sql = "SELECT * FROM tb_empresas WHERE cnpj='" & cnpj & "'"
            rs = db.Execute(sql)

            If rs.EOF = True Then
                sql = "INSERT INTO tb_empresas (cnpj, razao_social, nome_fantasia, insc_estadual, endereco, telefone, email, logo) " &
                      "VALUES ('" & cnpj & "', '" & razao & "', '" & fantasia & "', '" & insc & "', '" & endereco & "', '" & telefone & "', '" & email & "', '" & logo & "')"
                rs = db.Execute(UCase(sql))
                Limpar_cadastro()
                img_logo.Image = Nothing
                logoPath = ""
                MsgBox("Empresa cadastrada com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SUCESSO")
            Else
                MsgBox("Empresa Já Cadastrada!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "AVISO")
                txt_cnpj.Focus()
            End If

        Catch ex As Exception
            MsgBox("Erro ao Gravar! " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Public Sub txt_cnpj_LostFocus(sender As Object, e As EventArgs)
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
                If Not IsDBNull(rs.Fields("logo").Value) AndAlso Not String.IsNullOrEmpty(rs.Fields("logo").Value) AndAlso File.Exists(rs.Fields("logo").Value) Then
                    img_logo.ImageLocation = rs.Fields("logo").Value
                    logoPath = rs.Fields("logo").Value
                Else
                    img_logo.Image = Nothing
                    logoPath = ""
                End If
            Else
                txt_razao.Focus()
                img_logo.Image = Nothing
                logoPath = ""
            End If
        Catch ex As Exception
            MsgBox("Erro ao Consultar!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "AVISO")
        End Try
    End Sub

    Private Sub txt_cnpj_DoubleClick(sender As Object, e As EventArgs)
        Limpar_cadastro()
        img_logo.Image = Nothing
        logoPath = ""
    End Sub

    Private Sub txt_cnpj_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Public Sub Limpar_cadastro()
        Try
            txt_cnpj.Clear()
            txt_razao.Clear()
            txt_fantasia.Clear()
            txt_insc.Clear()
            txt_endereco.Clear()
            txt_telefone.Clear()
            txt_email.Clear()
            txt_cnpj.Focus()
            img_logo.Image = Nothing
            logoPath = ""
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
End Class
