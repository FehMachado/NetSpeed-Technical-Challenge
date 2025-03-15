Public Class ValidacaoDepartamento
    Public Shared Function Validar(departamento As Departamento) As List(Of String)
        Dim erros As New List(Of String)

        If String.IsNullOrWhiteSpace(departamento.Descricao) Then
            erros.Add("O campo 'Descrição' é obrigatório.")
        End If

        Return erros
    End Function
End Class
