Public Class Chamado

    Public Property Id As Integer
    Public Property Assunto As String
    Public Property Solicitante As String
    Public Property DataAbertura As DateTime

    Public Sub New(assunto As String, solicitante As String, dataAbertura As DateTime)
        Me.Assunto = assunto
        Me.Solicitante = solicitante
        Me.DataAbertura = dataAbertura
    End Sub

End Class
