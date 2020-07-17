Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports QIS.Common

Namespace QIS.Web.Secure

    Public Class Documents
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Documents_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                SetRepeaterDocumentTypes()
                DataBind()
            End If
        End Sub

        Protected Sub repDocumentType_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repDocumentType.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repDocuments As Repeater = CType(e.Item.FindControl("repDocuments"), Repeater)

                Dim dtDocuments As DataTable = Me.GetDocumentsByDocumentType(row("code").ToString.Trim)
                If dtDocuments.Rows.Count > 0 Then
                    repDocuments.DataSource = dtDocuments
                    repDocuments.DataBind()
                End If
            End If
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub SetRepeaterDocumentTypes()
            Dim oCC As New Common.BussinessRules.CommonCode
            oCC.GroupCode = Common.Constants.GroupCode.DocumentType_SCode.Trim
            repDocumentType.DataSource = oCC.SelectByGroupCode()
            repDocumentType.DataBind()
            oCC.Dispose()
            oCC = Nothing
        End Sub

        Private Function GetDocumentsByDocumentType(ByVal DocumentTypeSCode As String) As DataTable
            Dim dt As DataTable
            Dim oDoc As New Common.BussinessRules.Documents
            oDoc.documentTypeSCode = DocumentTypeSCode.Trim
            dt = oDoc.GetDocumentsByDocumentType()
            oDoc.Dispose()
            oDoc = Nothing
            Return dt
        End Function
#End Region


#Region " C,R,U,D "
        
#End Region

    End Class

End Namespace