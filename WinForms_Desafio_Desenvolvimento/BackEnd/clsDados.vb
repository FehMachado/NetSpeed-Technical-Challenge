﻿Imports System.Data
Imports System.Data.SQLite

Public Class Dados

    Private Const CONNECTION_STRING As String = "Data Source=Dados\DesafioDB.db;Version=3;"

    Public Shared Function ListarChamados() As DataTable

        Dim dtChamados As New DataTable()

        Using dbConnection As New SQLiteConnection(CONNECTION_STRING)

            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()

                dbCommand.CommandText = "SELECT chamados.ID, " +
                                        "       Assunto, " +
                                        "       Solicitante, " +
                                        "       departamentos.Descricao AS Departamento, " +
                                        "       DataAbertura " +
                                        "FROM chamados " +
                                        "INNER JOIN departamentos " +
                                        "   ON chamados.Departamento = departamentos.ID "

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)

                    dbDataAdapter.Fill(dtChamados)

                End Using

            End Using

        End Using

        Return dtChamados

    End Function

    Public Shared Function ListarDepartamentos() As DataTable

        Dim dtDepartamentos As New DataTable()

        Using dbConnection As New SQLiteConnection(CONNECTION_STRING)

            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()

                dbCommand.CommandText = "SELECT * FROM departamentos "

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)

                    dbDataAdapter.Fill(dtDepartamentos)

                End Using

            End Using

        End Using

        Return dtDepartamentos

    End Function

    Public Shared Function ObterChamado(ByVal idChamado As Integer) As DataRow

        Dim drChamado As DataRow = Nothing

        Using dbConnection As New SQLiteConnection(CONNECTION_STRING)

            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()

                dbCommand.CommandText = $"SELECT * FROM chamados WHERE ID = {idChamado}"

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)

                    Dim dtChamados As New DataTable()
                    dbDataAdapter.Fill(dtChamados)
                    drChamado = dtChamados.Rows(0)

                End Using

            End Using

        End Using

        Return drChamado

    End Function

    Public Shared Function GravarChamado(ByVal ID As Integer,
                                         ByVal Assunto As String,
                                         ByVal Solicitante As String,
                                         ByVal Departamento As Integer,
                                         ByVal DataAbertura As DateTime) As Boolean

        Dim regsAfetados As Integer = -1

        Using dbConnection As New SQLiteConnection(CONNECTION_STRING)
            dbConnection.Open()

            Dim transaction As SQLiteTransaction = dbConnection.BeginTransaction()

            Try
                Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                    dbCommand.Transaction = transaction

                    If ID = 0 Then

                        dbCommand.CommandText = "INSERT INTO chamados (Assunto,Solicitante,Departamento,DataAbertura)" +
                                                "VALUES (@Assunto,@Solicitante,@Departamento,@DataAbertura)"

                    Else

                        dbCommand.CommandText = "UPDATE chamados " +
                                                "SET Assunto=@Assunto, " +
                                                "    Solicitante=@Solicitante, " +
                                                "    Departamento=@Departamento, " +
                                                "    DataAbertura=@DataAbertura " +
                                                "WHERE ID=@ID "

                    End If

                    dbCommand.Parameters.AddWithValue("@Assunto", Assunto)
                    dbCommand.Parameters.AddWithValue("@Solicitante", Solicitante)
                    dbCommand.Parameters.AddWithValue("@Departamento", Departamento)
                    dbCommand.Parameters.AddWithValue("@DataAbertura", DataAbertura.ToShortDateString())

                    If ID <> 0 Then
                        dbCommand.Parameters.AddWithValue("@ID", ID)
                    End If


                    'dbConnection.Open()
                    regsAfetados = dbCommand.ExecuteNonQuery()
                    'dbConnection.Close()
                    transaction.Commit()
                End Using
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Erro ao inserir os dados: " & ex.Message)
            Finally
                dbConnection.Close()
            End Try
        End Using

        Return (regsAfetados > 0)

    End Function

    Public Shared Function ExcluirChamado(ByVal idChamado As Integer) As Boolean

        Dim regsAfetados As Integer = -1

        Using dbConnection As New SQLiteConnection(CONNECTION_STRING)

            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()

                dbCommand.CommandText = $"DELETE FROM chamados WHERE ID = {idChamado}"

                dbConnection.Open()
                regsAfetados = dbCommand.ExecuteNonQuery()
                dbConnection.Close()

            End Using

        End Using

        Return (regsAfetados > 0)

    End Function
    'De
    Public Shared Function GravarDepartamento(ByVal ID As Integer,
                                              ByVal Descricao As String) As Boolean

        Dim regsAfetados As Integer = -1

        Using dbConnection As New SQLiteConnection(CONNECTION_STRING)
            dbConnection.Open()

            Dim transaction As SQLiteTransaction = dbConnection.BeginTransaction()

            Try
                Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                    dbCommand.Transaction = transaction

                    If ID = 0 Then

                        dbCommand.CommandText = "INSERT INTO departamentos (Descricao)" +
                                                "VALUES (@Descricao)"

                    Else

                        dbCommand.CommandText = "UPDATE departamentos " +
                                                "SET Descricao=@Descricao, " +
                                                "WHERE ID=@ID "

                    End If

                    dbCommand.Parameters.AddWithValue("@Descricao", Descricao)

                    If ID <> 0 Then
                        dbCommand.Parameters.AddWithValue("@ID", ID)
                    End If


                    'dbConnection.Open()
                    regsAfetados = dbCommand.ExecuteNonQuery()
                    'dbConnection.Close()
                    transaction.Commit()
                End Using
            Catch ex As Exception
                transaction.Rollback()
                'MessageBox.Show("Erro ao Inserir/Atualizar dados: " & ex.Message)
            Finally
                dbConnection.Close()
            End Try
        End Using

        Return (regsAfetados > 0)
    End Function

End Class
