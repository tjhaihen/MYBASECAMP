Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Documents
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _documentID, _documentTypeSCode, _directory, _fileName, _fileExtension, _documentDescription As String
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
        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT d.*, cc.caption AS documentTypeName FROM [documents] d " + _
                                        "INNER JOIN commonCode cc ON d.documentTypeSCode = cc.code AND cc.groupCode='DOCTYPE' " + _
                                        "ORDER BY d.documentTypeSCode, d.fileName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("documents")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM [documents] WHERE documentID=@documentID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("documents")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@documentID", _documentID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _documentID = CType(toReturn.Rows(0)("documentID"), String)
                    _directory = CType(toReturn.Rows(0)("directory"), String)
                    _fileName = CType(toReturn.Rows(0)("fileName"), String)
                    _fileExtension = CType(toReturn.Rows(0)("fileExtension"), String)
                    _documentDescription = CType(toReturn.Rows(0)("documentDescription"), String)
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
#End Region

#Region " Custom Functions "
        Public Function GetDocumentsByDocumentType() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT d.*, " + _
                                        "fileUrl = " + _
                                        "CASE " + _
                                        "WHEN(LEN(d.fileName) > 0) THEN((SELECT [value] FROM CommonCode WHERE groupCode='FILEDIR' AND code='DOCFILEDIR') + d.directory + d.[fileName]) " + _
                                        "ELSE('#') " + _
                                        "END, " + _
                                        "userName = (SELECT userName FROM [User] WHERE userID=d.userIDinsert), " + _
                                        "firstName = (SELECT firstName FROM Person WHERE personID = (SELECT personID FROM [User] WHERE userID=d.userIDinsert)) " + _
                                        "FROM [documents] d " + _
                                        "WHERE d.documentTypeSCode = @documentTypeSCode " + _
                                        "ORDER BY d.documentTypeSCode, d.fileName"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetDocumentsAll")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@documentTypeSCode", _documentTypeSCode)

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

        Public Property [documentID]() As String
            Get
                Return _documentID
            End Get
            Set(ByVal Value As String)
                _documentID = Value
            End Set
        End Property

        Public Property [documentTypeSCode]() As String
            Get
                Return _documentTypeSCode
            End Get
            Set(ByVal Value As String)
                _documentTypeSCode = Value
            End Set
        End Property

        Public Property [directory]() As String
            Get
                Return _directory
            End Get
            Set(ByVal Value As String)
                _directory = Value
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

        Public Property [documentDescription]() As String
            Get
                Return _documentDescription
            End Get
            Set(ByVal Value As String)
                _documentDescription = Value
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
