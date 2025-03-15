Imports System.Data
Imports System.Data.SQLite

Public MustInherit Class DadosBase
    Protected Const CONNECTION_STRING As String = "Data Source=C:\Users\Felip\source\repos\WinForms_Desafio_Desenvolvimento\WinForms_Desafio_Desenvolvimento\BackEnd\Dados\DesafioDB.db;Version=3;"

    Public Shared Function ObterConexao() As SQLiteConnection
        Return New SQLiteConnection(CONNECTION_STRING)
    End Function
End Class
