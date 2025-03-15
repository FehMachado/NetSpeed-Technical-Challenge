Public Class ValidacaoChamados
    Public Shared Function Validar(chamado As Chamado) As List(Of String)
        Dim erros As New List(Of String)

        If String.IsNullOrWhiteSpace(chamado.Assunto) Then
            erros.Add("O campo 'Assunto' é obrigatório.")
        End If

        If String.IsNullOrWhiteSpace(chamado.Solicitante) Then
            erros.Add("O campo 'Solicitante' é obrigatório.")
        End If

        If chamado.DataAbertura < DateTime.Today Then
            erros.Add("A 'Data de Abertura' não pode ser anterior à data atual.")
        End If

        Return erros
    End Function

End Class
