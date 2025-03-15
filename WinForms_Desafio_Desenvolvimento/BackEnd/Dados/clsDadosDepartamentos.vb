Imports System.Data.SQLite

Public Class DadosDepartamentos
    Inherits DadosBase

#Region "Listar Departamentos"
    Public Shared Function ListarDepartamentos() As DataTable
        Dim dtDepartamentos As New DataTable()

        Using dbConnection As SQLiteConnection = ObterConexao()
            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                dbCommand.CommandText = "SELECT * FROM departamentos"

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)
                    dbDataAdapter.Fill(dtDepartamentos)
                End Using
            End Using
        End Using

        Return dtDepartamentos
    End Function
#End Region

#Region "Gravar/Atualizar Departamento"
    Public Shared Function GravarDepartamento(ID As Integer, Descricao As String) As Boolean
        Dim regsAfetados As Integer = -1

        Using dbConnection As SQLiteConnection = ObterConexao()
            dbConnection.Open()
            Dim transaction As SQLiteTransaction = dbConnection.BeginTransaction()

            Try
                Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                    dbCommand.Transaction = transaction

                    If ID = 0 Then
                        dbCommand.CommandText = "INSERT INTO departamentos (Descricao) VALUES (@Descricao)"
                    Else
                        dbCommand.CommandText = "UPDATE departamentos SET Descricao=@Descricao WHERE ID=@ID"
                    End If

                    dbCommand.Parameters.AddWithValue("@Descricao", Descricao)

                    If ID <> 0 Then
                        dbCommand.Parameters.AddWithValue("@ID", ID)
                    End If

                    regsAfetados = dbCommand.ExecuteNonQuery()
                    transaction.Commit()
                End Using
            Catch ex As Exception
                transaction.Rollback()
                Return False
            Finally
                dbConnection.Close()
            End Try
        End Using

        Return (regsAfetados > 0)
    End Function
#End Region

#Region "Obter Departamento"
    Public Shared Function ObterDepartamento(idDepartamento As Integer) As DataRow
        Dim drDepartamentos As DataRow = Nothing

        Using dbConnection As SQLiteConnection = ObterConexao()
            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                dbCommand.CommandText = $"SELECT * FROM departamentos WHERE ID = {idDepartamento}"

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)
                    Dim dtChamados As New DataTable()
                    dbDataAdapter.Fill(dtChamados)
                    If dtChamados.Rows.Count > 0 Then
                        drDepartamentos = dtChamados.Rows(0)
                    End If
                End Using
            End Using
        End Using

        Return drDepartamentos
    End Function
#End Region

#Region "Excluir Departamento"
    Public Shared Function ExcluirDepartamento(idDepartamento As Integer) As Boolean

        Dim regsAfetados As Integer = -1

        Using dbConnection As SQLiteConnection = ObterConexao()
            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                dbCommand.CommandText = $"DELETE FROM departamentos WHERE ID = {idDepartamento}"
                dbConnection.Open()
                regsAfetados = dbCommand.ExecuteNonQuery()
                dbConnection.Close()
            End Using
        End Using

        Return (regsAfetados > 0)
    End Function
#End Region

End Class
