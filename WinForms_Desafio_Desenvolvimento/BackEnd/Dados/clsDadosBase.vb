Imports System.Data.SQLite
Imports System.IO

Public MustInherit Class DadosBase

    Protected Shared ReadOnly Property CONNECTION_STRING As String
        Get
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory

            Dim databasePath As String = Path.Combine(baseDirectory, "..\..\BackEnd\Dados\DesafioDB.db")

            Return $"Data Source={databasePath};Version=3;"
        End Get
    End Property

    Public Shared Function ObterConexao() As SQLiteConnection
        Return New SQLiteConnection(CONNECTION_STRING)
    End Function
End Class
