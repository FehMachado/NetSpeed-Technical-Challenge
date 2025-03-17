
Public Class frmDepartamentosEditar

    Public Sub AbrirDepartamento(ByVal idDepartamento As Integer)

        Dim drChamado As DataRow = DadosDepartamentos.ObterDepartamento(idDepartamento)

        Me.txtID.Text = CInt(drChamado("ID")).ToString()
        Me.txtDescricao.Text = CStr(drChamado("Descricao"))

    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        Dim ID As Integer = If(String.IsNullOrEmpty(txtID.Text), 0, Integer.Parse(txtID.Text))
        Dim Descricao As String = Me.txtDescricao.Text

        Dim departamento As New Departamento(descricao)

        If Not ValidarDepartamento(departamento) Then
            Exit Sub
        End If

        Dim sucesso As Boolean = DadosDepartamentos.GravarDepartamento(ID, descricao)

        If sucesso Then
            Me.DialogResult = DialogResult.OK
        Else
            MessageBox.Show(Me, $"Falha ao gravar o departamento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
        End If

        Me.Close()

    End Sub

    Private Function ValidarDepartamento(departamento As Departamento) As Boolean

        Dim erros = ValidacaoDepartamento.Validar(departamento)

        If erros.Any() Then
            MessageBox.Show(String.Join(vbCrLf, erros), "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

End Class