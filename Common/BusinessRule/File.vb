Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class File
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _fileID, _referenceID, _tableName, _fileName, _fileExtension, _fileDescription As String
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub


        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO [File] (fileID, referenceID, tableName, fileName, fileExtension, fileDescription, " & _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " & _
                                        "VALUES (@fileID, @referenceID, @tableName, @fileName, @fileExtension, @fileDescription, " & _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("[File]", "fileID")

            Try
                cmdToExecute.Parameters.AddWithValue("@fileID", strID)
                cmdToExecute.Parameters.AddWithValue("@referenceID", _referenceID)
                cmdToExecute.Parameters.AddWithValue("@tableName", _tableName)
                cmdToExecute.Parameters.AddWithValue("@fileName", _fileName)
                cmdToExecute.Parameters.AddWithValue("@fileExtension", _fileExtension)
                cmdToExecute.Parameters.AddWithValue("@fileDescription", _fileDescription)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "UPDATE [File] " & _
                                        "SET fileDescription=@fileDescription, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE fileID=@fileID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@fileID", _fileID)
                cmdToExecute.Parameters.AddWithValue("@fileDescription", _fileDescription)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM [File] WHERE fileID=@fileID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("File")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@fileID", _fileID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _fileID = CType(toReturn.Rows(0)("fileID"), String)
                    _referenceID = CType(toReturn.Rows(0)("referenceID"), String)
                    _tableName = CType(toReturn.Rows(0)("tableName"), String)
                    _fileName = CType(toReturn.Rows(0)("fileName"), String)
                    _fileExtension = CType(toReturn.Rows(0)("fileExtension"), String)
                    _fileDescription = CType(toReturn.Rows(0)("fileDescription"), String)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                End If
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM [File] WHERE fileID=@fileID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@fileID", _fileID)

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Custom Functions "
        Public Function GetFileByReferenceID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT pf.*, " + _
                                        "fileUrl = " + _
                                        "CASE " + _
                                        "WHEN(LEN(pf.fileName) > 0) THEN((SELECT [value] FROM CommonCode WHERE groupCode='FILEDIR' AND code='ISSUEUPLDIRACC') + pf.tableName + '_' + pf.ReferenceID + '\' + pf.[fileName]) " + _
                                        "ELSE('#') " + _
                                        "END, " + _
                                        "userName = (SELECT userName FROM [User] WHERE userID=pf.userIDinsert), " + _
                                        "firstName = (SELECT firstName FROM Person WHERE personID = (SELECT personID FROM [User] WHERE userID=pf.userIDinsert)) " + _
                                        "FROM [File] pf WHERE pf.referenceID=@referenceID AND pf.tableName=@tableName"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetFileByReferenceID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@referenceID", _referenceID)
                cmdToExecute.Parameters.AddWithValue("@tableName", _tableName)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "

        Public Property [fileID]() As String
            Get
                Return _fileID
            End Get
            Set(ByVal Value As String)
                _fileID = Value
            End Set
        End Property

        Public Property [referenceID]() As String
            Get
                Return _referenceID
            End Get
            Set(ByVal Value As String)
                _referenceID = Value
            End Set
        End Property

        Public Property [tableName]() As String
            Get
                Return _tableName
            End Get
            Set(ByVal Value As String)
                _tableName = Value
            End Set
        End Property

        Public Property [fileName]() As String
            Get
                Return _fileName
            End Get
            Set(ByVal Value As String)
                _fileName = Value
            End Set
        End Property

        Public Property [fileExtension]() As String
            Get
                Return _fileExtension
            End Get
            Set(ByVal Value As String)
                _fileExtension = Value
            End Set
        End Property

        Public Property [fileDescription]() As String
            Get
                Return _fileDescription
            End Get
            Set(ByVal Value As String)
                _fileDescription = Value
            End Set
        End Property

        Public Property [UserIDInsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property

        Public Property [UserIDUpdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
            End Set
        End Property

        Public Property [InsertDate]() As DateTime
            Get
                Return _insertDate
            End Get
            Set(ByVal Value As DateTime)
                _insertDate = Value
            End Set
        End Property

        Public Property [UpdateDate]() As DateTime
            Get
                Return _updateDate
            End Get
            Set(ByVal Value As DateTime)
                _updateDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
