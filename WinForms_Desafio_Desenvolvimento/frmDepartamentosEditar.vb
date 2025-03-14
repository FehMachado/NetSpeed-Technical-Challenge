
Public Class frmDepartamentosEditar

    Public Sub AbrirDepartamento(ByVal idChamado As Integer)

        Dim drChamado As DataRow = DadosDepartamentos.ObterDepartamento(idChamado)

        Me.txtID.Text = CInt(drChamado("ID")).ToString()
        Me.txtDescricao.Text = CStr(drChamado("Descricao"))

    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        Dim ID As Integer = 0  'Valor Padrão
        Dim Descricao As String = Me.txtDescricao.Text

        If Not String.IsNullOrEmpty(Me.txtID.Text) Then
            ID = Integer.Parse(Me.txtID.Text)

        End If

        Dim sucesso As Boolean = DadosDepartamentos.GravarDepartamento(ID, Descricao)

        If Not sucesso Then

            MessageBox.Show(Me, "Falha ao gravar o departamento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel

        Else

            Me.DialogResult = DialogResult.OK

        End If

        Me.Close()

    End Sub

End Class