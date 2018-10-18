Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class PatientDocument
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _fileID As Integer
        Private _MRN, _fileName, _fileExtension, _fileDescription As String
        Private _uploadBy As String
        Private _uploadDate As DateTime

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

            cmdToExecute.CommandText = "INSERT INTO [EMRPatientDocument] (MRN, fileName, fileExtension, fileDescription, " & _
                                        "uploadBy, uploadDate) " & _
                                        "VALUES (@MRN, @fileName, @fileExtension, @fileDescription, " & _
                                        "@uploadBy, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@fileName", _fileName)
                cmdToExecute.Parameters.AddWithValue("@fileExtension", _fileExtension)
                cmdToExecute.Parameters.AddWithValue("@fileDescription", _fileDescription)
                cmdToExecute.Parameters.AddWithValue("@uploadBy", _uploadBy)

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
            cmdToExecute.CommandText = "SELECT * FROM [EMRPatientDocument] WHERE fileID=@fileID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EMRPatientDocument")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@fileID", _fileID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _fileID = CType(toReturn.Rows(0)("fileID"), Integer)
                    _MRN = CType(toReturn.Rows(0)("MRN"), String)
                    _fileName = CType(toReturn.Rows(0)("fileName"), String)
                    _fileExtension = CType(toReturn.Rows(0)("fileExtension"), String)
                    _fileDescription = CType(toReturn.Rows(0)("fileDescription"), String)
                    _uploadBy = CType(toReturn.Rows(0)("uploadBy"), String)
                    _uploadDate = CType(toReturn.Rows(0)("uploadDate"), DateTime)                    
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

            cmdToExecute.CommandText = "DELETE FROM [EMRPatientDocument] WHERE fileID=@fileID"
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
        Public Function GetPatientDocumentByMRN() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT pf.*, " + _
                                        "FileUrl = " + _
                                        "CASE " + _
                                        "WHEN(LEN(pf.fileName) > 0) THEN((SELECT [value] FROM CommonCode WHERE groupCode='FILEDIR' AND code='PATIENTDOCDIRAC') + pf.MRN + '/' + pf.[fileName]) " + _
                                        "ELSE('#') " + _
                                        "END, " + _
                                        "UploadByName = (SELECT userName FROM [User] WHERE userID=pf.uploadBy) " + _
                                        "FROM [EMRPatientDocument] pf WHERE pf.MRN=@MRN"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetPatientDocumentByMRN")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)

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

        Public Property [fileID]() As Integer
            Get
                Return _fileID
            End Get
            Set(ByVal Value As Integer)
                _fileID = Value
            End Set
        End Property

        Public Property [MRN]() As String
            Get
                Return _MRN
            End Get
            Set(ByVal Value As String)
                _MRN = Value
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

        Public Property [uploadBy]() As String
            Get
                Return _uploadBy
            End Get
            Set(ByVal Value As String)
                _uploadBy = Value
            End Set
        End Property

        Public Property [uploadDate]() As DateTime
            Get
                Return _uploadDate
            End Get
            Set(ByVal Value As DateTime)
                _uploadDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
